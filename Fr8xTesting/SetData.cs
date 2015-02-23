using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using BKSystem.IO;

namespace Fr8xTesting
{
    internal class SetData
    {

        public List<Chunk> Chunks;
 
        public SetData(String fileName)
        {
            byte[] theFile;
            Chunks = new List<Chunk>();
            // Load all the binary data into memory to make searching faster
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    theFile = ms.ToArray();
                }
            }

            // Decode as ASCII to search for preamble
            Encoding ascii = Encoding.ASCII;
            var strFile = ascii.GetString(theFile);

            // Find the preamble
            int preambleStart = strFile.IndexOf("<Roland_Fr_Set>", StringComparison.Ordinal);
            int preambleEnd = strFile.IndexOf("</Roland_Fr_Set>", StringComparison.Ordinal);
            preambleEnd += 17;

            string preamble = strFile.Substring(preambleStart, preambleEnd - preambleStart);

            XmlParserContext xpc = new XmlParserContext(new NameTable(), null, "en", XmlSpace.Preserve,
                Encoding.ASCII);

            XmlReader preambleReader = new XmlTextReader(preamble, XmlNodeType.Element, xpc);
            preambleReader.Read();
            Console.Write(preambleReader.Name);
            while (preambleReader.NodeType != XmlNodeType.EndElement)
            {
                preambleReader.Read();
                if (preambleReader.NodeType == XmlNodeType.Element)
                {
                    if (Constants.decoders.ContainsKey(preambleReader.Name))
                    {
                        int offset = Convert.ToUInt16(preambleReader.GetAttribute("offset"));
                        int size = Convert.ToUInt16(preambleReader.GetAttribute("size"));
                        int blocks = Convert.ToUInt16(preambleReader.GetAttribute("number"));
                        Type decoderType = Constants.decoders[preambleReader.Name];
                        MemoryStream mems = new MemoryStream(theFile);
                        BitStream bms = mems;
                        using (bms)
                        {
                            for (int block = 0; block < blocks; block++)
                            {
                                int sevenBitSize = size*8/7;
                                var buffer = new byte[sevenBitSize];
                                bms.Position = (preambleEnd + offset + (block*size))*8;
                                
                                for (int x = 0; x < size; x++)
                                {
                                    bms.Read(out buffer[x], 0, 7);
                                }
                                Chunks.Add((Chunk)Activator.CreateInstance(decoderType, buffer));                                
                            }
                        }
                    }
                }
            }            
        }

    }



}
        
                
  