namespace Anone
{
    partial class TargetDialog
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TargetDialog));
            this.picUser1 = new System.Windows.Forms.Label();
            this.picUser2 = new System.Windows.Forms.Label();
            this.picUser3 = new System.Windows.Forms.Label();
            this.picExit = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // picUser1
            // 
            this.picUser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picUser1.BackColor = System.Drawing.Color.Transparent;
            this.picUser1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUser1.Location = new System.Drawing.Point(344, 752);
            this.picUser1.Name = "picUser1";
            this.picUser1.Size = new System.Drawing.Size(703, 696);
            this.picUser1.TabIndex = 3;
            this.picUser1.Tag = "papa";
            this.picUser1.Click += new System.EventHandler(this.UserButton_Click);
            // 
            // picUser2
            // 
            this.picUser2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picUser2.BackColor = System.Drawing.Color.Transparent;
            this.picUser2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUser2.Location = new System.Drawing.Point(1149, 752);
            this.picUser2.Name = "picUser2";
            this.picUser2.Size = new System.Drawing.Size(698, 696);
            this.picUser2.TabIndex = 3;
            this.picUser2.Tag = "mama";
            this.picUser2.Click += new System.EventHandler(this.UserButton_Click);
            // 
            // picUser3
            // 
            this.picUser3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picUser3.BackColor = System.Drawing.Color.Transparent;
            this.picUser3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUser3.Location = new System.Drawing.Point(1954, 752);
            this.picUser3.Name = "picUser3";
            this.picUser3.Size = new System.Drawing.Size(701, 696);
            this.picUser3.TabIndex = 3;
            this.picUser3.Tag = "granpa";
            this.picUser3.Click += new System.EventHandler(this.UserButton_Click);
            // 
            // picExit
            // 
            this.picExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.Location = new System.Drawing.Point(2375, 93);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(542, 116);
            this.picExit.TabIndex = 3;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 800;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TargetDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2990, 1990);
            this.ControlBox = false;
            this.Controls.Add(this.picExit);
            this.Controls.Add(this.picUser3);
            this.Controls.Add(this.picUser2);
            this.Controls.Add(this.picUser1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "TargetDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TargetDialog";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label picUser1;
        private System.Windows.Forms.Label picUser2;
        private System.Windows.Forms.Label picUser3;
        private System.Windows.Forms.Label picExit;
        private System.Windows.Forms.Timer timer1;
    }
}

