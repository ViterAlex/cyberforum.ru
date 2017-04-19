using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ShowWavFile
{
    struct WavHeader
    {
        public byte[] RiffId;
        public uint Size;  // 
        public byte[] WavId;
        public byte[] FmtId;
        public uint FmtSize;
        public ushort Format;
        public ushort Channels;
        public uint SampleRate;
        public uint BytePerSec;
        public ushort BlockSize;
        public ushort Bit;
        public byte[] DataId;
        public uint DataSize;
        public List<short> LeftChannel;
        public List<short> RightChannel;

        public void ReadChannels(BinaryReader br)
        {
            LeftChannel = new List<short>();
            RightChannel = new List<short>();
            for (int i = 0; i < DataSize / BlockSize; i++)
            {
                LeftChannel.Add((short)br.ReadUInt16());
                RightChannel.Add((short)br.ReadUInt16());
            }
        }
    }
}
