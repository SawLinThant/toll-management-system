namespace Tollgate_Project
{
    partial class HIKIPCam
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
            this.picbx_ipcam = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picbx_ipcam)).BeginInit();
            this.SuspendLayout();
            // 
            // picbx_ipcam
            // 
            this.picbx_ipcam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbx_ipcam.Location = new System.Drawing.Point(0, 0);
            this.picbx_ipcam.Name = "picbx_ipcam";
            this.picbx_ipcam.Size = new System.Drawing.Size(800, 484);
            this.picbx_ipcam.TabIndex = 0;
            this.picbx_ipcam.TabStop = false;
            // 
            // HIKIPCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 484);
            this.Controls.Add(this.picbx_ipcam);
            this.Name = "HIKIPCam";
            this.Text = "HIKIPCam";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HIKIPCam_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picbx_ipcam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picbx_ipcam;
    }
}