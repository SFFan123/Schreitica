namespace Schreitica
{
    partial class HueWizard
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_HueIp = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_Ping = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Add_Hue_user = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHueUser = new System.Windows.Forms.TextBox();
            this.checkBoxShowPW = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.checkbox_ignoreSSLCertError = new System.Windows.Forms.CheckBox();
            this.check_HueTest = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_HueIp);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btn_Ping);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hue Bridge info";
            // 
            // txt_HueIp
            // 
            this.txt_HueIp.Location = new System.Drawing.Point(57, 19);
            this.txt_HueIp.Name = "txt_HueIp";
            this.txt_HueIp.Size = new System.Drawing.Size(127, 20);
            this.txt_HueIp.TabIndex = 5;
            this.txt_HueIp.Text = "philips-hue-hub";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(271, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(47, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Ping";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btn_Ping
            // 
            this.btn_Ping.Location = new System.Drawing.Point(190, 16);
            this.btn_Ping.Name = "btn_Ping";
            this.btn_Ping.Size = new System.Drawing.Size(75, 23);
            this.btn_Ping.TabIndex = 3;
            this.btn_Ping.Text = "Ping";
            this.btn_Ping.UseVisualStyleBackColor = true;
            this.btn_Ping.Click += new System.EventHandler(this.Ping_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adresse";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.check_HueTest);
            this.groupBox2.Controls.Add(this.checkbox_ignoreSSLCertError);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.checkBoxShowPW);
            this.groupBox2.Controls.Add(this.txtHueUser);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btn_Add_Hue_user);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 117);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hue User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hue Link button drüken";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "--->";
            // 
            // btn_Add_Hue_user
            // 
            this.btn_Add_Hue_user.Location = new System.Drawing.Point(159, 14);
            this.btn_Add_Hue_user.Name = "btn_Add_Hue_user";
            this.btn_Add_Hue_user.Size = new System.Drawing.Size(84, 23);
            this.btn_Add_Hue_user.TabIndex = 4;
            this.btn_Add_Hue_user.Text = "Add User";
            this.btn_Add_Hue_user.UseVisualStyleBackColor = true;
            this.btn_Add_Hue_user.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Username";
            // 
            // txtHueUser
            // 
            this.txtHueUser.Location = new System.Drawing.Point(67, 56);
            this.txtHueUser.Name = "txtHueUser";
            this.txtHueUser.Size = new System.Drawing.Size(283, 20);
            this.txtHueUser.TabIndex = 6;
            this.txtHueUser.UseSystemPasswordChar = true;
            // 
            // checkBoxShowPW
            // 
            this.checkBoxShowPW.AutoSize = true;
            this.checkBoxShowPW.Location = new System.Drawing.Point(356, 59);
            this.checkBoxShowPW.Name = "checkBoxShowPW";
            this.checkBoxShowPW.Size = new System.Drawing.Size(70, 17);
            this.checkBoxShowPW.TabIndex = 7;
            this.checkBoxShowPW.Text = "Anzeigen";
            this.checkBoxShowPW.UseVisualStyleBackColor = true;
            this.checkBoxShowPW.CheckedChanged += new System.EventHandler(this.CheckChange);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 82);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Test";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(713, 190);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Speichern und Schließen";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkbox_ignoreSSLCertError
            // 
            this.checkbox_ignoreSSLCertError.AutoSize = true;
            this.checkbox_ignoreSSLCertError.Location = new System.Drawing.Point(249, 19);
            this.checkbox_ignoreSSLCertError.Name = "checkbox_ignoreSSLCertError";
            this.checkbox_ignoreSSLCertError.Size = new System.Drawing.Size(126, 17);
            this.checkbox_ignoreSSLCertError.TabIndex = 9;
            this.checkbox_ignoreSSLCertError.Text = "Ignore SSL Cert Error";
            this.checkbox_ignoreSSLCertError.UseVisualStyleBackColor = true;
            // 
            // check_HueTest
            // 
            this.check_HueTest.AutoSize = true;
            this.check_HueTest.Enabled = false;
            this.check_HueTest.Location = new System.Drawing.Point(87, 86);
            this.check_HueTest.Name = "check_HueTest";
            this.check_HueTest.Size = new System.Drawing.Size(47, 17);
            this.check_HueTest.TabIndex = 6;
            this.check_HueTest.Text = "Test";
            this.check_HueTest.UseVisualStyleBackColor = true;
            // 
            // HueWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 229);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "HueWizard";
            this.Text = "HueWizard";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btn_Ping;
        private System.Windows.Forms.TextBox txt_HueIp;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBoxShowPW;
        private System.Windows.Forms.TextBox txtHueUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Add_Hue_user;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkbox_ignoreSSLCertError;
        private System.Windows.Forms.CheckBox check_HueTest;
    }
}