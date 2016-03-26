using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Anone
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Properties.Settings.Default.LastReceived = $@"{DateTimeOffset.Now:yyyy-MM-dd\THH\:mm\:sszzz}";

            Properties.Settings.Default.LastReceived = $@"{DateTimeOffset.Now.ToUniversalTime():yyyy-MM-dd\THH\:mm\:sszzz}";
            Properties.Settings.Default.Save();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TargetDialog());
        }
    }
}
