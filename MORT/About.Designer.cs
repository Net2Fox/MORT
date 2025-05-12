namespace MORT
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            lbVersion = new System.Windows.Forms.Label();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            lbCreator = new System.Windows.Forms.Label();
            lbLogo = new System.Windows.Forms.Label();
            lbDicversion = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            linkLabel3 = new System.Windows.Forms.LinkLabel();
            label11 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            lbAbout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbVersion
            // 
            lbVersion.AutoSize = true;
            lbVersion.Location = new System.Drawing.Point(17, 460);
            lbVersion.Name = "lbVersion";
            lbVersion.Size = new System.Drawing.Size(175, 20);
            lbVersion.TabIndex = 2;
            lbVersion.Text = "버전 : 1.19dv- 2019 10 05";
            lbVersion.Click += label2_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(110, 700);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(225, 20);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://blog.naver.com/killkimno";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // lbCreator
            // 
            lbCreator.AutoSize = true;
            lbCreator.Location = new System.Drawing.Point(17, 495);
            lbCreator.Name = "lbCreator";
            lbCreator.Size = new System.Drawing.Size(184, 20);
            lbCreator.TabIndex = 3;
            lbCreator.Text = "제작자 : 몽키해드 (김무영)";
            // 
            // lbLogo
            // 
            lbLogo.AutoSize = true;
            lbLogo.Location = new System.Drawing.Point(18, 530);
            lbLogo.Name = "lbLogo";
            lbLogo.Size = new System.Drawing.Size(95, 20);
            lbLogo.TabIndex = 9;
            lbLogo.Text = "로고 : 김마손";
            // 
            // lbDicversion
            // 
            lbDicversion.AutoSize = true;
            lbDicversion.Location = new System.Drawing.Point(18, 648);
            lbDicversion.Name = "lbDicversion";
            lbDicversion.Size = new System.Drawing.Size(114, 20);
            lbDicversion.TabIndex = 10;
            lbDicversion.Text = "교정사전 버전 : ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(18, 700);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(80, 20);
            label8.TabIndex = 11;
            label8.Text = "몽키해드 : ";
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox1.Image = Properties.Resources.about;
            pictureBox1.Location = new System.Drawing.Point(-1, 0);
            pictureBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(540, 380);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Location = new System.Drawing.Point(110, 735);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new System.Drawing.Size(231, 20);
            linkLabel3.TabIndex = 16;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "http://blog.naver.com/sabon2000";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(18, 735);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(61, 20);
            label11.TabIndex = 15;
            label11.Text = "김마손 :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(18, 613);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(249, 20);
            label2.TabIndex = 17;
            label2.Text = "OCR : TesseractOCR 5.2v, NHocr 0.21";
            // 
            // lbAbout
            // 
            lbAbout.AutoSize = true;
            lbAbout.Location = new System.Drawing.Point(18, 565);
            lbAbout.Name = "lbAbout";
            lbAbout.Size = new System.Drawing.Size(119, 20);
            lbAbout.TabIndex = 18;
            lbAbout.Text = "About : irismisha";
            // 
            // About
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Window;
            ClientSize = new System.Drawing.Size(616, 807);
            Controls.Add(lbAbout);
            Controls.Add(label2);
            Controls.Add(linkLabel3);
            Controls.Add(label11);
            Controls.Add(label8);
            Controls.Add(lbDicversion);
            Controls.Add(lbLogo);
            Controls.Add(linkLabel1);
            Controls.Add(lbCreator);
            Controls.Add(lbVersion);
            Controls.Add(pictureBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            Name = "About";
            Text = "About";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lbCreator;
        private System.Windows.Forms.Label lbLogo;
        private System.Windows.Forms.Label lbDicversion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbAbout;
    }
}