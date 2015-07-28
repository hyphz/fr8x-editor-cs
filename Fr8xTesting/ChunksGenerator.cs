

namespace Fr8xTesting {
    public partial class TrebleRegister : Chunk {

        public TrebleRegister(byte[] data) : base(data) {}

        public string Name { get { return GetAscii(0, 8); } set { PutAscii(value,0,8); } }
        public bool OrchestralMode { get { return GetBoolean(68); } set { PutBoolean(value,68); } }
        public byte OrchestralToneNum { get { return Data[69]; } set { Data[69] = value; } }
        public byte MusetteDetune { get { return Data[70]; } set { Data[70] = value; } }
        public byte ReverbSend { get { return Data[71]; } set { Data[71] = value; } }
        public byte ChorusSend { get { return Data[72]; } set { Data[72] = value; } }
        public byte DelaySend { get { return Data[73]; } set { Data[73] = value; } }
        public byte BellowPitchDetune { get { return Data[74]; } set { Data[74] = value; } }
        public byte Octave { get { return Data[75]; } set { Data[75] = value; } }
        public bool ValveNoiseEnabled { get { return GetBoolean(76); } set { PutBoolean(value,76); } }
        public byte ValveNoiseVolume { get { return Data[77]; } set { Data[77] = value; } }
        public MidiVoice ValveNoiseVoice { get { return GetMidiVoice(78); } set { PutMidiVoice(value,78); } }
        public byte LinkBassR { get { return Data[81]; } set { Data[81] = value; } }
        public byte LinkOrchBassR { get { return Data[82]; } set { Data[82] = value; } }
        public byte LinkOrchChordFBR { get { return Data[83]; } set { Data[83] = value; } }
        public byte AftertouchPitchDown { get { return Data[84]; } set { Data[84] = value; } }
        public byte NoteTXFilter { get { return Data[85]; } set { Data[85] = value; } }
        public byte NoteOnVelocity { get { return Data[86]; } set { Data[86] = value; } }
        public byte MidiOctave { get { return Data[87]; } set { Data[87] = value; } }

	}
	    public partial class SetCommon : Chunk {

        public SetCommon(byte[] data) : base(data) {}

        public string Creator { get { return GetAscii(0, 4); } set { PutAscii(value,0,4); } }
        public string Type { get { return GetAscii(4, 8); } set { PutAscii(value,4,8); } }
        public string Ver { get { return GetAscii(8, 12); } set { PutAscii(value,8,12); } }
        public string Num { get { return GetAscii(12, 16); } set { PutAscii(value,12,16); } }
        public string Name { get { return GetAscii(16, 24); } set { PutAscii(value,16,24); } }
        public byte ReverbCharacter { get { return Data[24]; } set { Data[24] = value; } }
        public byte ReverbPreLPF { get { return Data[25]; } set { Data[25] = value; } }
        public byte ReverbTime { get { return Data[26]; } set { Data[26] = value; } }
        public byte ReverbDelay { get { return Data[27]; } set { Data[27] = value; } }
        public byte ReverbPredelay { get { return Data[28]; } set { Data[28] = value; } }
        public byte ReverbLevel { get { return Data[29]; } set { Data[29] = value; } }
        public byte ReverbSelected { get { return Data[30]; } set { Data[30] = value; } }
        public byte ChorusPreLPF { get { return Data[31]; } set { Data[31] = value; } }
        public byte ChorusFeedback { get { return Data[32]; } set { Data[32] = value; } }
        public byte ChorusDelay { get { return Data[33]; } set { Data[33] = value; } }
        public byte ChorusRate { get { return Data[34]; } set { Data[34] = value; } }
        public byte ChorusDepth { get { return Data[35]; } set { Data[35] = value; } }

	}
	
}


