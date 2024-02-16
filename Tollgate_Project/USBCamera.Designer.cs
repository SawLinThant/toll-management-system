namespace Tollgate_Project
{
    partial class USBCamera
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_streamonoff = new System.Windows.Forms.Button();
            this.cbx_camsource = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 594);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(850, 594);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_streamonoff
            // 
            this.btn_streamonoff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(171)))), ((int)(((byte)(23)))));
            this.btn_streamonoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_streamonoff.Location = new System.Drawing.Point(12, 606);
            this.btn_streamonoff.Name = "btn_streamonoff";
            this.btn_streamonoff.Size = new System.Drawing.Size(111, 68);
            this.btn_streamonoff.TabIndex = 1;
            this.btn_streamonoff.Text = "On/Off";
            this.btn_streamonoff.UseVisualStyleBackColor = false;
            this.btn_streamonoff.Click += new System.EventHandler(this.btn_streamonoff_Click);
            // 
            // cbx_camsource
            // 
            this.cbx_camsource.FormattingEnabled = true;
            this.cbx_camsource.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cbx_camsource.Location = new System.Drawing.Point(129, 611);
            this.cbx_camsource.Name = "cbx_camsource";
            this.cbx_camsource.Size = new System.Drawing.Size(121, 24);
            this.cbx_camsource.TabIndex = 2;
            // 
            // USBCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(850, 701);
            this.Controls.Add(this.cbx_camsource);
            this.Controls.Add(this.btn_streamonoff);
            this.Controls.Add(this.panel1);
            this.Name = "USBCamera";
            this.Text = "USBCamera";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_streamonoff;
        private System.Windows.Forms.ComboBox cbx_camsource;
    }
}