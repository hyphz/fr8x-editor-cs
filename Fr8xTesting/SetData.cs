using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Xml;
using BKSystem.IO;

namespace Fr8xTesting
{
    internal class SetData
    {
        public List<TrebleRegister> TrebleRegisters;
        public List<OrchestraRightRegister> OrchestraRightRegisters;
        public Dictionary<String, List<byte[]>> UnknownChunks;
 
        private static readonly List<String> ChunkTypes = new List<string>() { "SC", "O_R", "OB_R", "OBC_R", "OFB_R", "TR", "BR", "BCR", "ORR", "OBR", "OBCR", "OFBR", "ORCH1", "ORCH2", "SC2" };

        public void WriteToFile(String fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                var preamble =
                    Assembly.GetExecutingAssembly().GetManifestResourceStream("Fr8xTesting.standard.preamble");
                using (preamble)
                {
                    preamble.CopyTo(fs);
                }
                foreach (var chunkType in ChunkTypes)
                {
                    
                    int count;
                    Func<int, byte[]> fetcher;

                    switch (chunkType)
                    {
                        case "TR":
                            count = TrebleRegisters.Count;
                            fetcher = i => TrebleRegisters[i].GetRawData();
                            break;
                        case "O_R":
                            count = OrchestraRightRegisters.Count;
                            fetcher = i => OrchestraRightRegisters[i].GetRawData();
                            break;
                        default:
                            count = UnknownChunks[chunkType].Count;
                            var dontScrewUpMyLambda = chunkType;
                            fetcher = i => UnknownChunks[dontScrewUpMyLambda][i];
                            break;
                    }
                    for (int block = 0; block < count; block++)
                    {
                        var theBlock = fetcher(block);
                        BitStream bms = new BitStream();
                        using (bms)
                        {
                            for (int t = 0; t < theBlock.Length - 1; t++) {
                                bms.Write(theBlock[t], 0, 7);
                            }
                            var ms = (MemoryStream) bms;
                            ms.WriteTo(fs);
                        }

                      
                    }
                }
            }
            Console.Write("Saving done");
        }
        public SetData(String fileName)
        {
            byte[] theFile;
            TrebleRegisters = new List<TrebleRegister>();
            OrchestraRightRegisters = new List<OrchestraRightRegister>();
            UnknownChunks = new Dictionary<string, List<byte[]>>();

            // Load all the binary data into memory to make extraction faster
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    theFile = ms.ToArray();
                }
            }

            // Decode as ASCII to search for preamble
            var ascii = Encoding.ASCII;
            var strFile = ascii.GetString(theFile);

            // Find the preamble
            var preambleStart = strFile.IndexOf("<Roland_Fr_Set>", StringComparison.Ordinal);
            var preambleEnd = strFile.IndexOf("</Roland_Fr_Set>", StringComparison.Ordinal);
            preambleEnd += 17;

            // Extract the preamble and parse it
            var preamble = strFile.Substring(preambleStart, preambleEnd - preambleStart);
            var xpc = new XmlParserContext(new NameTable(), null, "en", XmlSpace.Preserve,
                Encoding.ASCII);
            XmlReader preambleReader = new XmlTextReader(preamble, XmlNodeType.Element, xpc);
            preambleReader.Read();
            while (preambleReader.NodeType != XmlNodeType.EndElement)
            {
                preambleReader.Read();
                if (preambleReader.NodeType != XmlNodeType.Element) continue;
                if (!ChunkTypes.Contains(preambleReader.Name)) continue;
                int offset = Convert.ToUInt16(preambleReader.GetAttribute("offset"));
                int size = Convert.ToUInt16(preambleReader.GetAttribute("size"));
                int blocks = Convert.ToUInt16(preambleReader.GetAttribute("number"));
                var mems = new MemoryStream(theFile);
                BitStream bms = mems;
                var sevenBitSize = (size * 8 / 7)+1;
                using (bms)
                {
                    for (var block = 0; block < blocks; block++)
                    {
                        var buffer = new byte[sevenBitSize];
                        bms.Position = (preambleEnd + offset + (block*size))*8;
                        for (var x = 0; x < sevenBitSize; x++)
                        {
                            bms.Read(out buffer[x], 0, 7);
                        }
                        
                        switch (preambleReader.Name)
                        {
                            case "TR":
                                TrebleRegisters.Add(new TrebleRegister(buffer));
                                break;
                            case "O_R":
                                OrchestraRightRegisters.Add(new OrchestraRightRegister(buffer));
                                break;
                            default:
                                if (UnknownChunks.ContainsKey(preambleReader.Name))
                                {
                                    UnknownChunks[preambleReader.Name].Add(buffer);
                                }
                                else
                                {
                                    UnknownChunks.Add(preambleReader.Name, new List<byte[]>() { buffer });    
                                }
                                break;
                        }
                   }
                }
            }
        }
    }
}