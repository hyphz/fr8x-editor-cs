using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Fr8xTesting
{
    public class TrebleRegister : Chunk 
    {
       
        public TrebleRegister(byte[] data) { Data = data; }

        public String name {
            get { return GetAscii(0, 8); }
            set { PutAscii(value, 0, 8); } 
        }

        public TrebleVoice GetTrebleVoice(int voice)
        {
            MidiVoice thePatch = new MidiVoice() { Cc00 = Data[8+voice], Cc32 = Data[18+voice], Pc = Data[28+voice] };
            TrebleVoice tv = new TrebleVoice()
                             {
                                 patch = thePatch, 
                                 enabled = GetBoolean(38+voice),
                                 cassotto = GetBoolean(48+voice),
                                 volume = Data[58+voice]
                             };
            return tv;
        }

        public void SetTrebleVoice(int voice, TrebleVoice input)
        {
            Data[8 + voice] = (byte) input.patch.Cc00;
            Data[18 + voice] = (byte) input.patch.Cc32;
            Data[28 + voice] = (byte) input.patch.Pc;
            PutBoolean(input.enabled, 38 + voice);
            PutBoolean(input.cassotto, 48 + voice);
            Data[58 + voice] = (byte) input.volume;
        }

        public bool OrchestralMode { get { return GetBoolean(68); } set { PutBoolean(value, 68); } }
        public byte OrchestralToneNum { get { return Data[69]; } set { Data[69] = value; } } 
        public byte MusetteDetune { get { return Data[70]; } set { Data[70] = value; } }
        public byte ReverbSend { get { return Data[71]; } set { Data[71] = value; } }
        public byte ChorusSend { get { return Data[72]; } set { Data[72] = value; } }
        public byte DelaySend { get { return Data[73]; } set { Data[73] = value; } }
        public byte BellowPitchDetune { get { return Data[74]; } set { Data[74] = value; } }
        public byte Octave { get { return Data[75]; } set { Data[75] = value; } }
        public bool ValveNoiseEnabled { get { return GetBoolean(76); } set { PutBoolean(value, 76); } }
        public byte ValveNoiseVolume { get { return Data[77]; } set { Data[77] = value; } }
        public MidiVoice ValveNoiseVoice { get { return GetMidiVoice(78); } set { PutMidiVoice(value, 78); } }
    }

    class OrchestraRightRegister : Chunk
    {
        
        public OrchestraRightRegister(byte[] data) { Data = data; }

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
