using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anone
{
    public partial class ReceiverDialog : Form
    {
        public ReceiverDialog()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                picStamp.Image = null;
            }
        }

        public ReceiverDialog(string url)
            : this()
        {
            // "http://13.71.156.156:4567/api/messages/59.png"
            this.Shown += delegate 
            {
                try
                {
                    picStamp.LoadAsync(url);
                }
                catch (Exception)
                {
                }
            };
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
