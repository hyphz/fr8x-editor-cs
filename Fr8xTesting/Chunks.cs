using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Fr8xTesting
{
    public partial class TrebleRegister : Chunk
    {

        public TrebleVoice this[int x]
        {
            get { return GetTrebleVoice(x); }
            set { SetTrebleVoice(x, value); }
        }

        public TrebleVoice GetTrebleVoice(int voice)
        {
            MidiVoice thePatch = new MidiVoice() { Cc00 = Data[8+voice], Cc32 = Data[18+voice], Pc = Data[28+voice] };
            TrebleVoice tv = new TrebleVoice()
                             {
                                 Patch = thePatch, 
                                 Enabled = GetBoolean(38+voice),
                                 Cassotto = GetBoolean(48+voice),
                                 Volume = Data[58+voice]
                             };
            return tv;
        }

        public void SetTrebleVoice(int voice, TrebleVoice input)
        {
            Data[8 + voice] = (byte) input.Patch.Cc00;
            Data[18 + voice] = (byte) input.Patch.Cc32;
            Data[28 + voice] = (byte) input.Patch.Pc;
            PutBoolean(input.Enabled, 38 + voice);
            PutBoolean(input.Cassotto, 48 + voice);
            Data[58 + voice] = input.Volume;
        }
    }

    class OrchestraRightRegister : Chunk
    {
        
        public OrchestraRightRegister(byte[] data) : base(data) { }

        public string name {
            get { return GetAscii(0, 12); } 
            set { PutAscii(value, 0, 12); }
        }

        public MidiVoice patch
        {
            get { return GetMidiVoice(12); }
            set { PutMidiVoice(value, 12); }
        }

        public MidiVoice patch1
        {
            get { return GetMidiVoice(15); }
            set { PutMidiVoice(value, 15); }
        }

        public byte patch1Volume { get { return Data[18]; } set { Data[18] = value; }}
        public byte patch1Octave { get { return Data[19]; } set { Data[19] = value; }}

        public bool dynamicMode { 
            get { return GetBoolean(20); }
            set { PutBoolean(value, 20); }
        }


    }

    
}
