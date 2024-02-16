namespace Tollgate_Project
{
    partial class Setting
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
            this.components = new System.ComponentModel.Container();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_refreshport = new System.Windows.Forms.Button();
            this.cbx_pair = new System.Windows.Forms.ComboBox();
            this.lbl_pa = new System.Windows.Forms.Label();
            this.lbl_baudrate = new System.Windows.Forms.Label();
            this.cbx_baudrate = new System.Windows.Forms.ComboBox();
            this.cbx_databits = new System.Windows.Forms.ComboBox();
            this.lbl_port = new System.Windows.Forms.Label();
            this.cbx_stopbits = new System.Windows.Forms.ComboBox();
            this.cbx_port = new System.Windows.Forms.ComboBox();
            this.lbl_databits = new System.Windows.Forms.Label();
            this.lbl_stopbits = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_barrierport = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IPaddresstxt = new System.Windows.Forms.TextBox();
            this.IPusernametxt = new System.Windows.Forms.TextBox();
            this.IPpasswordtxt = new System.Windows.Forms.TextBox();
            this.pnl_printersetting = new System.Windows.Forms.Panel();
            this.cbx_displayport = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnl_camerasetting = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbx_clouddatabasepassword = new System.Windows.Forms.TextBox();
            this.tbx_clouddatabasename = new System.Windows.Forms.TextBox();
            this.tbx_clouddatabaseuid = new System.Windows.Forms.TextBox();
            this.tbx_clouddatabaseserver = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_listenport = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbx_listenaddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbx_ipcamport = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbx_printername = new System.Windows.Forms.TextBox();
            this.pnl_printersetting.SuspendLayout();
            this.pnl_camerasetting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(171)))), ((int)(((byte)(23)))));
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(254, 562);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(111, 46);
            this.btn_save.TabIndex = 87;
            this.btn_save.Text = "Save Setting";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_refreshport
            // 
            this.btn_refreshport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(171)))), ((int)(((byte)(23)))));
            this.btn_refreshport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_refreshport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refreshport.ForeColor = System.Drawing.Color.White;
            this.btn_refreshport.Location = new System.Drawing.Point(110, 562);
            this.btn_refreshport.Name = "btn_refreshport";
            this.btn_refreshport.Size = new System.Drawing.Size(100, 46);
            this.btn_refreshport.TabIndex = 85;
            this.btn_refreshport.Text = "Refresh Ports";
            this.btn_refreshport.UseVisualStyleBackColor = false;
            this.btn_refreshport.Click += new System.EventHandler(this.btn_refreshport_Click);
            // 
            // cbx_pair
            // 
            this.cbx_pair.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_pair.FormattingEnabled = true;
            this.cbx_pair.Items.AddRange(new object[] {
            "Even",
            "Odd",
            "None"});
            this.cbx_pair.Location = new System.Drawing.Point(244, 490);
            this.cbx_pair.Name = "cbx_pair";
            this.cbx_pair.Size = new System.Drawing.Size(121, 39);
            this.cbx_pair.TabIndex = 84;
            this.cbx_pair.SelectedIndexChanged += new System.EventHandler(this.cbx_pair_SelectedIndexChanged);
            // 
            // lbl_pa
            // 
            this.lbl_pa.AutoSize = true;
            this.lbl_pa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.lbl_pa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pa.ForeColor = System.Drawing.Color.White;
            this.lbl_pa.Location = new System.Drawing.Point(97, 491);
            this.lbl_pa.Name = "lbl_pa";
            this.lbl_pa.Size = new System.Drawing.Size(67, 25);
            this.lbl_pa.TabIndex = 83;
            this.lbl_pa.Text = "Parity";
            // 
            // lbl_baudrate
            // 
            this.lbl_baudrate.AutoSize = true;
            this.lbl_baudrate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.lbl_baudrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_baudrate.ForeColor = System.Drawing.Color.White;
            this.lbl_baudrate.Location = new System.Drawing.Point(97, 287);
            this.lbl_baudrate.Name = "lbl_baudrate";
            this.lbl_baudrate.Size = new System.Drawing.Size(99, 25);
            this.lbl_baudrate.TabIndex = 75;
            this.lbl_baudrate.Text = "Baudrate";
            // 
            // cbx_baudrate
            // 
            this.cbx_baudrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_baudrate.FormattingEnabled = true;
            this.cbx_baudrate.Items.AddRange(new object[] {
            "19200",
            "9600",
            "115200"});
            this.cbx_baudrate.Location = new System.Drawing.Point(244, 288);
            this.cbx_baudrate.Name = "cbx_baudrate";
            this.cbx_baudrate.Size = new System.Drawing.Size(121, 39);
            this.cbx_baudrate.TabIndex = 76;
            this.cbx_baudrate.SelectedIndexChanged += new System.EventHandler(this.cbx_baudrate_SelectedIndexChanged);
            // 
            // cbx_databits
            // 
            this.cbx_databits.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_databits.FormattingEnabled = true;
            this.cbx_databits.Items.AddRange(new object[] {
            "6",
            "7",
            "8"});
            this.cbx_databits.Location = new System.Drawing.Point(244, 423);
            this.cbx_databits.Name = "cbx_databits";
            this.cbx_databits.Size = new System.Drawing.Size(121, 39);
            this.cbx_databits.TabIndex = 82;
            this.cbx_databits.SelectedIndexChanged += new System.EventHandler(this.cbx_databits_SelectedIndexChanged);
            // 
            // lbl_port
            // 
            this.lbl_port.AutoSize = true;
            this.lbl_port.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.lbl_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_port.ForeColor = System.Drawing.Color.White;
            this.lbl_port.Location = new System.Drawing.Point(97, 153);
            this.lbl_port.Name = "lbl_port";
            this.lbl_port.Size = new System.Drawing.Size(120, 25);
            this.lbl_port.TabIndex = 77;
            this.lbl_port.Text = "Printer Port";
            // 
            // cbx_stopbits
            // 
            this.cbx_stopbits.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_stopbits.FormattingEnabled = true;
            this.cbx_stopbits.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbx_stopbits.Location = new System.Drawing.Point(244, 357);
            this.cbx_stopbits.Name = "cbx_stopbits";
            this.cbx_stopbits.Size = new System.Drawing.Size(121, 39);
            this.cbx_stopbits.TabIndex = 81;
            this.cbx_stopbits.SelectedIndexChanged += new System.EventHandler(this.cbx_stopbits_SelectedIndexChanged);
            // 
            // cbx_port
            // 
            this.cbx_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_port.FormattingEnabled = true;
            this.cbx_port.Location = new System.Drawing.Point(244, 153);
            this.cbx_port.Name = "cbx_port";
            this.cbx_port.Size = new System.Drawing.Size(121, 39);
            this.cbx_port.TabIndex = 78;
            this.cbx_port.SelectedIndexChanged += new System.EventHandler(this.cbx_port_SelectedIndexChanged);
            // 
            // lbl_databits
            // 
            this.lbl_databits.AutoSize = true;
            this.lbl_databits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.lbl_databits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_databits.ForeColor = System.Drawing.Color.White;
            this.lbl_databits.Location = new System.Drawing.Point(97, 424);
            this.lbl_databits.Name = "lbl_databits";
            this.lbl_databits.Size = new System.Drawing.Size(91, 25);
            this.lbl_databits.TabIndex = 80;
            this.lbl_databits.Text = "Databits";
            // 
            // lbl_stopbits
            // 
            this.lbl_stopbits.AutoSize = true;
            this.lbl_stopbits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.lbl_stopbits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stopbits.ForeColor = System.Drawing.Color.White;
            this.lbl_stopbits.Location = new System.Drawing.Point(97, 358);
            this.lbl_stopbits.Name = "lbl_stopbits";
            this.lbl_stopbits.Size = new System.Drawing.Size(91, 25);
            this.lbl_stopbits.TabIndex = 79;
            this.lbl_stopbits.Text = "Stopbits";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(97, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 88;
            this.label1.Text = "Barrier Port";
            // 
            // cbx_barrierport
            // 
            this.cbx_barrierport.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_barrierport.FormattingEnabled = true;
            this.cbx_barrierport.Location = new System.Drawing.Point(244, 90);
            this.cbx_barrierport.Name = "cbx_barrierport";
            this.cbx_barrierport.Size = new System.Drawing.Size(121, 39);
            this.cbx_barrierport.TabIndex = 89;
            this.cbx_barrierport.SelectedIndexChanged += new System.EventHandler(this.cbx_barrierport_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(78, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 92;
            this.label2.Text = "IP Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(78, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 25);
            this.label3.TabIndex = 90;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(78, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 25);
            this.label4.TabIndex = 91;
            this.label4.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(122, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 25);
            this.label5.TabIndex = 93;
            this.label5.Text = "IP Camers Setting";
            // 
            // IPaddresstxt
            // 
            this.IPaddresstxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IPaddresstxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPaddresstxt.Location = new System.Drawing.Point(230, 84);
            this.IPaddresstxt.Name = "IPaddresstxt";
            this.IPaddresstxt.Size = new System.Drawing.Size(181, 45);
            this.IPaddresstxt.TabIndex = 94;
            this.IPaddresstxt.Enter += new System.EventHandler(this.IPaddresstxt_Enter);
            this.IPaddresstxt.Leave += new System.EventHandler(this.IPaddresstxt_Leave);
            // 
            // IPusernametxt
            // 
            this.IPusernametxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IPusernametxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPusernametxt.Location = new System.Drawing.Point(230, 163);
            this.IPusernametxt.Name = "IPusernametxt";
            this.IPusernametxt.Size = new System.Drawing.Size(181, 45);
            this.IPusernametxt.TabIndex = 95;
            this.IPusernametxt.Enter += new System.EventHandler(this.IPusernametxt_Enter);
            this.IPusernametxt.Leave += new System.EventHandler(this.IPusernametxt_Leave);
            // 
            // IPpasswordtxt
            // 
            this.IPpasswordtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IPpasswordtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPpasswordtxt.Location = new System.Drawing.Point(230, 241);
            this.IPpasswordtxt.Name = "IPpasswordtxt";
            this.IPpasswordtxt.Size = new System.Drawing.Size(181, 45);
            this.IPpasswordtxt.TabIndex = 96;
            this.IPpasswordtxt.UseSystemPasswordChar = true;
            this.IPpasswordtxt.Enter += new System.EventHandler(this.IPpasswordtxt_Enter);
            this.IPpasswordtxt.Leave += new System.EventHandler(this.IPpasswordtxt_Leave);
            // 
            // pnl_printersetting
            // 
            this.pnl_printersetting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_printersetting.Controls.Add(this.cbx_displayport);
            this.pnl_printersetting.Controls.Add(this.label7);
            this.pnl_printersetting.Controls.Add(this.label6);
            this.pnl_printersetting.Controls.Add(this.cbx_pair);
            this.pnl_printersetting.Controls.Add(this.lbl_stopbits);
            this.pnl_printersetting.Controls.Add(this.lbl_databits);
            this.pnl_printersetting.Controls.Add(this.cbx_port);
            this.pnl_printersetting.Controls.Add(this.cbx_stopbits);
            this.pnl_printersetting.Controls.Add(this.lbl_port);
            this.pnl_printersetting.Controls.Add(this.cbx_databits);
            this.pnl_printersetting.Controls.Add(this.cbx_baudrate);
            this.pnl_printersetting.Controls.Add(this.label1);
            this.pnl_printersetting.Controls.Add(this.lbl_baudrate);
            this.pnl_printersetting.Controls.Add(this.cbx_barrierport);
            this.pnl_printersetting.Controls.Add(this.lbl_pa);
            this.pnl_printersetting.Controls.Add(this.btn_save);
            this.pnl_printersetting.Controls.Add(this.btn_refreshport);
            this.pnl_printersetting.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_printersetting.Location = new System.Drawing.Point(0, 0);
            this.pnl_printersetting.Name = "pnl_printersetting";
            this.pnl_printersetting.Size = new System.Drawing.Size(500, 749);
            this.pnl_printersetting.TabIndex = 97;
            // 
            // cbx_displayport
            // 
            this.cbx_displayport.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_displayport.FormattingEnabled = true;
            this.cbx_displayport.Location = new System.Drawing.Point(244, 217);
            this.cbx_displayport.Name = "cbx_displayport";
            this.cbx_displayport.Size = new System.Drawing.Size(121, 39);
            this.cbx_displayport.TabIndex = 99;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(97, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 25);
            this.label7.TabIndex = 98;
            this.label7.Text = "Display Port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(133, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 25);
            this.label6.TabIndex = 97;
            this.label6.Text = "General Setting";
            // 
            // pnl_camerasetting
            // 
            this.pnl_camerasetting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_camerasetting.Controls.Add(this.groupBox2);
            this.pnl_camerasetting.Controls.Add(this.groupBox1);
            this.pnl_camerasetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_camerasetting.Location = new System.Drawing.Point(500, 0);
            this.pnl_camerasetting.Name = "pnl_camerasetting";
            this.pnl_camerasetting.Size = new System.Drawing.Size(1231, 749);
            this.pnl_camerasetting.TabIndex = 98;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.tbx_clouddatabasepassword);
            this.groupBox2.Controls.Add(this.tbx_clouddatabasename);
            this.groupBox2.Controls.Add(this.tbx_clouddatabaseuid);
            this.groupBox2.Controls.Add(this.tbx_clouddatabaseserver);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(449, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 745);
            this.groupBox2.TabIndex = 106;
            this.groupBox2.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(145, 331);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(274, 25);
            this.label20.TabIndex = 119;
            this.label20.Text = "Cloud Database Password:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(94, 268);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(325, 25);
            this.label19.TabIndex = 118;
            this.label19.Text = "Cloud Database Databasename:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(167, 201);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(252, 25);
            this.label18.TabIndex = 117;
            this.label18.Text = "Cloud Database User ID:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(167, 142);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(244, 25);
            this.label17.TabIndex = 116;
            this.label17.Text = "Cloud Databsae Server:";
            // 
            // tbx_clouddatabasepassword
            // 
            this.tbx_clouddatabasepassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_clouddatabasepassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_clouddatabasepassword.Location = new System.Drawing.Point(464, 319);
            this.tbx_clouddatabasepassword.Name = "tbx_clouddatabasepassword";
            this.tbx_clouddatabasepassword.Size = new System.Drawing.Size(181, 45);
            this.tbx_clouddatabasepassword.TabIndex = 112;
            this.tbx_clouddatabasepassword.Enter += new System.EventHandler(this.tbx_clouddatabasepassword_Enter);
            this.tbx_clouddatabasepassword.Leave += new System.EventHandler(this.tbx_clouddatabasepassword_Leave);
            // 
            // tbx_clouddatabasename
            // 
            this.tbx_clouddatabasename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_clouddatabasename.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_clouddatabasename.Location = new System.Drawing.Point(464, 255);
            this.tbx_clouddatabasename.Name = "tbx_clouddatabasename";
            this.tbx_clouddatabasename.Size = new System.Drawing.Size(181, 45);
            this.tbx_clouddatabasename.TabIndex = 111;
            this.tbx_clouddatabasename.Enter += new System.EventHandler(this.tbx_clouddatabasename_Enter);
            this.tbx_clouddatabasename.Leave += new System.EventHandler(this.tbx_clouddatabasename_Leave);
            // 
            // tbx_clouddatabaseuid
            // 
            this.tbx_clouddatabaseuid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_clouddatabaseuid.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_clouddatabaseuid.Location = new System.Drawing.Point(464, 190);
            this.tbx_clouddatabaseuid.Name = "tbx_clouddatabaseuid";
            this.tbx_clouddatabaseuid.Size = new System.Drawing.Size(181, 45);
            this.tbx_clouddatabaseuid.TabIndex = 110;
            this.tbx_clouddatabaseuid.Enter += new System.EventHandler(this.tbx_clouddatabaseuid_Enter);
            this.tbx_clouddatabaseuid.Leave += new System.EventHandler(this.tbx_clouddatabaseuid_Leave);
            // 
            // tbx_clouddatabaseserver
            // 
            this.tbx_clouddatabaseserver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_clouddatabaseserver.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_clouddatabaseserver.Location = new System.Drawing.Point(464, 124);
            this.tbx_clouddatabaseserver.Name = "tbx_clouddatabaseserver";
            this.tbx_clouddatabaseserver.Size = new System.Drawing.Size(181, 45);
            this.tbx_clouddatabaseserver.TabIndex = 108;
            this.tbx_clouddatabaseserver.Enter += new System.EventHandler(this.tbx_clouddatabaseserver_Enter);
            this.tbx_clouddatabaseserver.Leave += new System.EventHandler(this.tbx_clouddatabaseserver_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(341, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(178, 25);
            this.label12.TabIndex = 105;
            this.label12.Text = "Database Setting";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IPaddresstxt);
            this.groupBox1.Controls.Add(this.tbx_listenport);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbx_listenaddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.IPusernametxt);
            this.groupBox1.Controls.Add(this.tbx_ipcamport);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.IPpasswordtxt);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbx_printername);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 745);
            this.groupBox1.TabIndex = 105;
            this.groupBox1.TabStop = false;
            this.groupBox1.Leave += new System.EventHandler(this.groupBox1_Leave);
            // 
            // tbx_listenport
            // 
            this.tbx_listenport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_listenport.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_listenport.Location = new System.Drawing.Point(230, 472);
            this.tbx_listenport.Name = "tbx_listenport";
            this.tbx_listenport.Size = new System.Drawing.Size(181, 45);
            this.tbx_listenport.TabIndex = 104;
            this.tbx_listenport.Enter += new System.EventHandler(this.tbx_listenport_Enter);
            this.tbx_listenport.Leave += new System.EventHandler(this.tbx_listenport_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 488);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(186, 25);
            this.label11.TabIndex = 103;
            this.label11.Text = "ANPR Listen Port:";
            // 
            // tbx_listenaddress
            // 
            this.tbx_listenaddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_listenaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_listenaddress.Location = new System.Drawing.Point(230, 399);
            this.tbx_listenaddress.Name = "tbx_listenaddress";
            this.tbx_listenaddress.Size = new System.Drawing.Size(181, 45);
            this.tbx_listenaddress.TabIndex = 102;
            this.tbx_listenaddress.Enter += new System.EventHandler(this.tbx_listenaddress_Enter);
            this.tbx_listenaddress.Leave += new System.EventHandler(this.tbx_listenaddress_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(31, 415);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 25);
            this.label10.TabIndex = 101;
            this.label10.Text = "Listen Address:";
            // 
            // tbx_ipcamport
            // 
            this.tbx_ipcamport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_ipcamport.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_ipcamport.Location = new System.Drawing.Point(230, 318);
            this.tbx_ipcamport.Name = "tbx_ipcamport";
            this.tbx_ipcamport.Size = new System.Drawing.Size(181, 45);
            this.tbx_ipcamport.TabIndex = 100;
            this.tbx_ipcamport.Enter += new System.EventHandler(this.tbx_ipcamport_Enter);
            this.tbx_ipcamport.Leave += new System.EventHandler(this.tbx_ipcamport_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(31, 334);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 25);
            this.label9.TabIndex = 99;
            this.label9.Text = "IPCamera Port:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(47, 561);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 25);
            this.label8.TabIndex = 98;
            this.label8.Text = "Printer Name:";
            // 
            // tbx_printername
            // 
            this.tbx_printername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_printername.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_printername.Location = new System.Drawing.Point(230, 545);
            this.tbx_printername.Name = "tbx_printername";
            this.tbx_printername.Size = new System.Drawing.Size(181, 45);
            this.tbx_printername.TabIndex = 97;
            this.tbx_printername.Enter += new System.EventHandler(this.tbx_printername_Enter);
            this.tbx_printername.Leave += new System.EventHandler(this.tbx_printername_Leave);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1731, 749);
            this.Controls.Add(this.pnl_camerasetting);
            this.Controls.Add(this.pnl_printersetting);
            this.MinimizeBox = false;
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Setting_FormClosed);
            this.Load += new System.EventHandler(this.Setting_Load);
            this.pnl_printersetting.ResumeLayout(false);
            this.pnl_printersetting.PerformLayout();
            this.pnl_camerasetting.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_refreshport;
        private System.Windows.Forms.ComboBox cbx_pair;
        private System.Windows.Forms.Label lbl_pa;
        private System.Windows.Forms.Label lbl_baudrate;
        private System.Windows.Forms.ComboBox cbx_baudrate;
        private System.Windows.Forms.ComboBox cbx_databits;
        private System.Windows.Forms.Label lbl_port;
        private System.Windows.Forms.ComboBox cbx_stopbits;
        private System.Windows.Forms.ComboBox cbx_port;
        private System.Windows.Forms.Label lbl_databits;
        private System.Windows.Forms.Label lbl_stopbits;
        private System.IO.Ports.SerialPort serialPort1;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_barrierport;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox IPaddresstxt;
		private System.Windows.Forms.TextBox IPusernametxt;
		private System.Windows.Forms.TextBox IPpasswordtxt;
        private System.Windows.Forms.Panel pnl_printersetting;
        private System.Windows.Forms.Panel pnl_camerasetting;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbx_displayport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbx_printername;
        private System.Windows.Forms.TextBox tbx_ipcamport;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbx_listenaddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbx_listenport;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_clouddatabasepassword;
        private System.Windows.Forms.TextBox tbx_clouddatabasename;
        private System.Windows.Forms.TextBox tbx_clouddatabaseuid;
        private System.Windows.Forms.TextBox tbx_clouddatabaseserver;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
    }
}