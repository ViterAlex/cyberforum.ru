using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowWavFile
{
    public partial class MainForm : Form
    {
        WavHeader wav = new WavHeader();
        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Читаем данные
            using (var fs = new FileStream(@"Alesis-Fusion-Nylon-String-Guitar-C4.wav", FileMode.Open, FileAccess.Read))
            {
                using (var br = new BinaryReader(fs))
                {
                    wav.RiffId = br.ReadBytes(4);
                    wav.Size = br.ReadUInt32();
                    wav.WavId = br.ReadBytes(4);
                    wav.FmtId = br.ReadBytes(4);
                    wav.FmtSize = br.ReadUInt32();
                    wav.Format = br.ReadUInt16();
                    wav.Channels = br.ReadUInt16();
                    wav.SampleRate = br.ReadUInt32();
                    wav.BytePerSec = br.ReadUInt32();
                    wav.BlockSize = br.ReadUInt16();
                    wav.Bit = br.ReadUInt16();
                    wav.DataId = br.ReadBytes(4);
                    wav.DataSize = br.ReadUInt32();
                    //Загружаем каналы
                    wav.ReadChannels(br);
                }
            }
            //Отсчёты времени
            var timestamp = Enumerable.Range(0, wav.LeftChannel.Count).Select(n => n / wav.SampleRate).ToList();
            //Показываем графики
            chart1.Series["LCData"].Points.DataBindXY(timestamp, wav.LeftChannel);
            chart1.Series["RCData"].Points.DataBindXY(timestamp, wav.RightChannel);
        }
    }
}
