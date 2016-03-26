namespace Anone
{
    partial class ReceiverDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiverDialog));
            this.picStamp = new System.Windows.Forms.PictureBox();
            this.lblClose = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picStamp)).BeginInit();
            this.SuspendLayout();
            // 
            // picStamp
            // 
            this.picStamp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picStamp.BackColor = System.Drawing.Color.Transparent;
            this.picStamp.Image = ((System.Drawing.Image)(resources.GetObject("picStamp.Image")));
            this.picStamp.Location = new System.Drawing.Point(1115, 831);
            this.picStamp.Name = "picStamp";
            this.picStamp.Size = new System.Drawing.Size(750, 554);
            this.picStamp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStamp.TabIndex = 0;
            this.picStamp.TabStop = false;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Location = new System.Drawing.Point(1226, 1528);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(538, 161);
            this.lblClose.TabIndex = 1;
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // ReceiverDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(3000, 2000);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.picStamp);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReceiverDialog";
            this.Text = "ReceiverDialog";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picStamp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picStamp;
        private System.Windows.Forms.Label lblClose;
    }
}