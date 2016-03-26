using Anone.Components;
using NAudio.Wave;
using System;
using System.IO;
using System.Speech.Recognition;
using System.Windows.Forms;
using System.Linq;

namespace Anone
{
    public partial class VoiceMessageDialog : Form
    {
        public string From { get; private set; }
        public string To { get; private set; }

        private const double RECORDING_SECONDS = 5.0;
        private string AudioFile;

        private DateTime BeginTime { get; set; }
        private DateTime EndTime { get; set; }

        WaveIn waveSource = null;
        WaveFileWriter waveFile = null;

        public VoiceMessageDialog(string from, string to)
        {
            this.From = from;
            this.To = to;
            InitializeComponent();
            RunCountDown();
        }

        public VoiceMessageDialog()
            : this("child", "papa")
        {
        }

        private void RunCountDown()
        {
            BeginTime = DateTime.Now;
            EndTime = BeginTime.AddSeconds(RECORDING_SECONDS);
            this.pgbCountDown.Value = this.pgbCountDown.Maximum;

            AudioFile = Path.GetTempFileName();
            waveSource = new WaveIn() { WaveFormat = new WaveFormat(44100, 16, 1) };
            waveFile = new WaveFileWriter(AudioFile = Path.GetTempFileName(), waveSource.WaveFormat);
            waveSource.DataAvailable += (sender, e) =>
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            };
            waveSource.RecordingStopped += (sender, e) =>
            {
                waveFile.Close();
                waveFile.Dispose();
                waveFile = null;
                waveSource.Dispose();
                waveSource = null;

                using (var sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("ja-JP")))
                using (var wav = new System.IO.FileStream(AudioFile, System.IO.FileMode.Open))
                {
                    sre.SetInputToAudioStream(wav, new System.Speech.AudioFormat.SpeechAudioFormatInfo(44100, System.Speech.AudioFormat.AudioBitsPerSample.Sixteen, System.Speech.AudioFormat.AudioChannel.Mono));

                    var g = new DictationGrammar();
                    sre.LoadGrammar(g);

                    var ret = sre.Recognize();
                    var msg = new Anone.Components.AudioMessage();
                    msg.AudioStream = wav;
                    msg.Message = ret?.Text ?? "(音声を確認できませんでした)";
                    msg.To = this.To;
                    msg.From = this.From;
                    AnoneRequest.Talk(msg);
                }
                this.Close();
            };

            waveSource.StartRecording();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var ts = EndTime - DateTime.Now;
            if (ts < TimeSpan.Zero) ts = TimeSpan.Zero;
            if (ts == TimeSpan.Zero)
            {
                pgbCountDown.Value = pgbCountDown.Minimum;
                timer1.Stop();
                waveSource.StopRecording();
            }
            else
            {
                pgbCountDown.Value = (int)((pgbCountDown.Maximum - pgbCountDown.Minimum) * (ts.TotalSeconds / RECORDING_SECONDS)) ;
            }
        }

        private void VoiceMessageDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                File.Delete(AudioFile);
            }
            catch (Exception)
            {
                // オーディオファイルを削除できなかったけれども
                // 一時ファイルなので放置
            }
        }
    }
}
