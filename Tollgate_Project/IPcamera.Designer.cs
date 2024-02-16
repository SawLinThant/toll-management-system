namespace Tollgate_Project
{
    partial class IPcamera
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
            this.btn_snapshot = new System.Windows.Forms.Button();
            this.btn_saveto = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbx_ipno = new System.Windows.Forms.TextBox();
            this.tbx_username = new System.Windows.Forms.TextBox();
            this.tbx_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_path = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btn_snapshot
            // 
            this.btn_snapshot.Location = new System.Drawing.Point(343, 610);
            this.btn_snapshot.Name = "btn_snapshot";
            this.btn_snapshot.Size = new System.Drawing.Size(160, 28);
            this.btn_snapshot.TabIndex = 8;
            this.btn_snapshot.Text = "Snapshot";
            this.btn_snapshot.UseVisualStyleBackColor = true;
            this.btn_snapshot.Click += new System.EventHandler(this.btn_snapshot_Click);
            // 
            // btn_saveto
            // 
            this.btn_saveto.Location = new System.Drawing.Point(343, 647);
            this.btn_saveto.Name = "btn_saveto";
            this.btn_saveto.Size = new System.Drawing.Size(160, 28);
            this.btn_saveto.TabIndex = 7;
            this.btn_saveto.Text = "Save To";
            this.btn_saveto.UseVisualStyleBackColor = true;
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(343, 574);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(160, 29);
            this.btn_connect.TabIndex = 6;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 0);
            this.panel1.TabIndex = 5;
            // 
            // tbx_ipno
            // 
            this.tbx_ipno.Location = new System.Drawing.Point(131, 574);
            this.tbx_ipno.Name = "tbx_ipno";
            this.tbx_ipno.Size = new System.Drawing.Size(193, 22);
            this.tbx_ipno.TabIndex = 10;
            this.tbx_ipno.Enter += new System.EventHandler(this.tbx_ipno_Enter);
            this.tbx_ipno.Leave += new System.EventHandler(this.tbx_ipno_Leave);
            // 
            // tbx_username
            // 
            this.tbx_username.Location = new System.Drawing.Point(131, 613);
            this.tbx_username.Name = "tbx_username";
            this.tbx_username.Size = new System.Drawing.Size(193, 22);
            this.tbx_username.TabIndex = 11;
            this.tbx_username.Enter += new System.EventHandler(this.tbx_username_Enter);
            this.tbx_username.Leave += new System.EventHandler(this.tbx_username_Leave);
            // 
            // tbx_password
            // 
            this.tbx_password.Location = new System.Drawing.Point(131, 651);
            this.tbx_password.Name = "tbx_password";
            this.tbx_password.Size = new System.Drawing.Size(193, 22);
            this.tbx_password.TabIndex = 12;
            this.tbx_password.UseSystemPasswordChar = true;
            this.tbx_password.Enter += new System.EventHandler(this.tbx_password_Enter);
            this.tbx_password.Leave += new System.EventHandler(this.tbx_password_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(12, 573);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "IP No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(12, 650);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(12, 613);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Username";
            // 
            // tbx_path
            // 
            this.tbx_path.Location = new System.Drawing.Point(645, 573);
            this.tbx_path.Name = "tbx_path";
            this.tbx_path.Size = new System.Drawing.Size(193, 22);
            this.tbx_path.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(509, 569);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "File directory";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(868, 547);
            this.panel2.TabIndex = 18;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // IPcamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(868, 701);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbx_path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_password);
            this.Controls.Add(this.tbx_username);
            this.Controls.Add(this.tbx_ipno);
            this.Controls.Add(this.btn_snapshot);
            this.Controls.Add(this.btn_saveto);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.panel1);
            this.Name = "IPcamera";
            this.Text = "IPcamera";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IPcamera_FormClosed);
            this.Load += new System.EventHandler(this.IPcamera_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_snapshot;
        private System.Windows.Forms.Button btn_saveto;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbx_ipno;
        private System.Windows.Forms.TextBox tbx_username;
        private System.Windows.Forms.TextBox tbx_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_path;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
    }
}