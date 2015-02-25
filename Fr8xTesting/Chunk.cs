using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fr8xTesting
{
    public class MidiVoice
    {
        public int Cc00 { get; set; }
        public int Cc32 { get; set; }
        public int Pc { get; set; }
    }

    public class TrebleVoice
    {
        public MidiVoice Patch { get; set; }
        public bool Enabled { get; set; }
        public bool Cassotto { get; set; }
        public byte Volume { get; set; }
    }
    public class Chunk
    {
        protected byte[] Data;

        public Chunk(byte[] inData)
        {
            Data = inData;
        }

        public byte[] GetRawData()
        {
            return Data;
        }

        public string GetAscii(int offset, int length)
        {
            byte[] chunkData = new byte[length];
            Array.Copy(Data, 0, chunkData, 0, length);
            return Encoding.ASCII.GetString(chunkData);
        }

        public void PutAscii(string input, int offset, int length)
        {
             byte[] buffer = new byte[length];
             for (int x = 0; x < length; x++)
             {
                 buffer[x] = 0;
             }
             byte[] codedInput = Encoding.ASCII.GetBytes(input);
             Array.Copy(codedInput,buffer,Math.Min(codedInput.Length,length));
             Array.Copy(buffer, 0, Data, offset, length);
        }

        public bool GetBoolean(int offset)
        {
            return (Data[offset] == 1);
        }

        public void PutBoolean(bool input, int offset)
        {
            if (input) Data[offset] = 1;
            else Data[offset] = 0;
        }

        public MidiVoice GetMidiVoice(int offset)
        {
            return new MidiVoice {Cc00 = Data[offset], Cc32 = Data[offset + 1], Pc = Data[offset + 2]};
        }

        public void PutMidiVoice(MidiVoice input, int offset)
        {
            Data[offset] = (byte)input.Cc00;
            Data[offset + 1] = (byte)input.Cc32;
            Data[offset + 2] = (byte)input.Pc;
        }


    }
}
