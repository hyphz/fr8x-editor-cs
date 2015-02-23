using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr8xTesting
{
    public struct MidiVoice
    {
        public int Cc00;
        public int Cc32;
        public int Pc;
    }

    public struct TrebleVoice
    {
        public MidiVoice patch;
        public bool enabled;
        public bool cassotto;
        public byte volume;
    }
    public class Chunk
    {
        protected byte[] Data;

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
