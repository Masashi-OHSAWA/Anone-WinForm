using Anone.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Anone
{
    public partial class TargetDialog : Form
    {
        public TargetDialog()
        {
            InitializeComponent();
            Shown += delegate { timer1.Start(); };
        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            string to = ((Control)sender).Tag?.ToString() ?? "papa";

            using (var dlg = new VoiceMessageDialog("child", to))
            {
                dlg.ShowDialog(this);
                Receive();
            }
            timer1.Start();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Receive()
        {
            foreach (var msg in AnoneRequest.Receive("child", Properties.Settings.Default.LastReceived))
            {
                if (msg.Type == "stamp")
                {
                    // スタンプの URL が未定ならスキップ(同一時刻で再送)
                    if (!string.IsNullOrWhiteSpace(msg.Url))
                    {
                        // スタンプの URL が確定している場合のみ、タイムスタンプを進める
                        Properties.Settings.Default.LastReceived = msg.TimeStamp;
                        Properties.Settings.Default.Save();

                        // 現在の実装では、サーバー側での user 判定が省かれているので、
                        // クライアント側で、自分宛のメッセージか否かを判定する
                        if (msg.To == "child")
                        {
                            // スタンプを表示
                            using (var dlg = new ReceiverDialog(msg.Url))
                            {
                                dlg.ShowDialog(this);
                            }
                        }
                    }
                }
                else
                {
                    // スタンプ以外は表示しない
                    Properties.Settings.Default.LastReceived = msg.TimeStamp;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Receive();
            timer1.Start();
        }
    }
}
