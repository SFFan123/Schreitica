namespace Schreitica.UI
{
    partial class ActionForm
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
            this.comboBox_ActionType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Actions = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Param = new System.Windows.Forms.TextBox();
            this.lbl_ParamInfo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_ActionType
            // 
            this.comboBox_ActionType.FormattingEnabled = true;
            this.comboBox_ActionType.Items.AddRange(new object[] { "OBS", "App", "Hue" });
            this.comboBox_ActionType.Location = new System.Drawing.Point(76, 6);
            this.comboBox_ActionType.Name = "comboBox_ActionType";
            this.comboBox_ActionType.Size = new System.Drawing.Size(176, 21);
            this.comboBox_ActionType.TabIndex = 0;
            this.comboBox_ActionType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aktion Typ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Aktion";
            // 
            // comboBox_Actions
            // 
            this.comboBox_Actions.Enabled = false;
            this.comboBox_Actions.FormattingEnabled = true;
            this.comboBox_Actions.Location = new System.Drawing.Point(76, 52);
            this.comboBox_Actions.Name = "comboBox_Actions";
            this.comboBox_Actions.Size = new System.Drawing.Size(176, 21);
            this.comboBox_Actions.TabIndex = 3;
            this.comboBox_Actions.SelectedIndexChanged += new System.EventHandler(this.comboBox_Actions_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Parameter";
            // 
            // txt_Param
            // 
            this.txt_Param.Enabled = false;
            this.txt_Param.Location = new System.Drawing.Point(76, 97);
            this.txt_Param.Name = "txt_Param";
            this.txt_Param.Size = new System.Drawing.Size(176, 20);
            this.txt_Param.TabIndex = 5;
            // 
            // lbl_ParamInfo
            // 
            this.lbl_ParamInfo.AutoSize = true;
            this.lbl_ParamInfo.Location = new System.Drawing.Point(258, 100);
            this.lbl_ParamInfo.Name = "lbl_ParamInfo";
            this.lbl_ParamInfo.Size = new System.Drawing.Size(0, 13);
            this.lbl_ParamInfo.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(268, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Anwenden";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 175);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_ParamInfo);
            this.Controls.Add(this.txt_Param);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_Actions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_ActionType);
            this.Name = "ActionForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_ActionType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Actions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Param;
        private System.Windows.Forms.Label lbl_ParamInfo;
        private System.Windows.Forms.Button button1;
    }
}