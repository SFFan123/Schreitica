namespace Schreitica
{
    partial class Schreitica
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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("NoiseLevelReached");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schreitica));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolstrip_lbl_Connection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_OBS_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Treshold = new System.Windows.Forms.TextBox();
            this.btn_applyTreshold = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ApplyPolling = new System.Windows.Forms.Button();
            this.grpboxAction = new System.Windows.Forms.GroupBox();
            this.btn_applyActions = new System.Windows.Forms.Button();
            this.btn_removeAction = new System.Windows.Forms.Button();
            this.treeViewActions = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Tree_Add = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.autoConnectRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_OBS_Connect = new System.Windows.Forms.Button();
            this.checkBox_ShowOBSPassword = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_OBS_Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_OBS_URL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_ApplyHue = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txt_Hue_User = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Hue_URL = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numUpDown_PollingRate = new System.Windows.Forms.NumericUpDown();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Test_FireNoiseLevelReached = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Test_FireNoiseLevelBelowThresholdAgain = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.grpboxAction.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_PollingRate)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolstrip_lbl_Connection,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel_OBS_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(96, 17);
            this.toolStripStatusLabel1.Text = "USB Connection:";
            // 
            // toolstrip_lbl_Connection
            // 
            this.toolstrip_lbl_Connection.Name = "toolstrip_lbl_Connection";
            this.toolstrip_lbl_Connection.Size = new System.Drawing.Size(79, 17);
            this.toolstrip_lbl_Connection.Text = "Disconnected";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel2.Text = "OBS Status:";
            // 
            // toolStripStatusLabel_OBS_Status
            // 
            this.toolStripStatusLabel_OBS_Status.Name = "toolStripStatusLabel_OBS_Status";
            this.toolStripStatusLabel_OBS_Status.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabel_OBS_Status.Text = "Disconnected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Schwellwert";
            // 
            // txt_Treshold
            // 
            this.txt_Treshold.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Treshold.Location = new System.Drawing.Point(93, 30);
            this.txt_Treshold.Name = "txt_Treshold";
            this.txt_Treshold.Size = new System.Drawing.Size(100, 20);
            this.txt_Treshold.TabIndex = 3;
            this.txt_Treshold.Text = "30.0";
            // 
            // btn_applyTreshold
            // 
            this.btn_applyTreshold.Location = new System.Drawing.Point(199, 27);
            this.btn_applyTreshold.Name = "btn_applyTreshold";
            this.btn_applyTreshold.Size = new System.Drawing.Size(75, 23);
            this.btn_applyTreshold.TabIndex = 4;
            this.btn_applyTreshold.Text = "Anwenden";
            this.btn_applyTreshold.UseVisualStyleBackColor = true;
            this.btn_applyTreshold.Click += new System.EventHandler(this.btn_applyTreshold_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(188, 108);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 5;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(107, 107);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 6;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "PollingRate(hz)";
            // 
            // btn_ApplyPolling
            // 
            this.btn_ApplyPolling.Location = new System.Drawing.Point(199, 79);
            this.btn_ApplyPolling.Name = "btn_ApplyPolling";
            this.btn_ApplyPolling.Size = new System.Drawing.Size(75, 23);
            this.btn_ApplyPolling.TabIndex = 9;
            this.btn_ApplyPolling.Text = "Anwenden";
            this.btn_ApplyPolling.UseVisualStyleBackColor = true;
            this.btn_ApplyPolling.Click += new System.EventHandler(this.btn_ApplyPolling_Click);
            // 
            // grpboxAction
            // 
            this.grpboxAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpboxAction.Controls.Add(this.btn_applyActions);
            this.grpboxAction.Controls.Add(this.btn_removeAction);
            this.grpboxAction.Controls.Add(this.treeViewActions);
            this.grpboxAction.Controls.Add(this.btn_Tree_Add);
            this.grpboxAction.Location = new System.Drawing.Point(406, 33);
            this.grpboxAction.Name = "grpboxAction";
            this.grpboxAction.Size = new System.Drawing.Size(382, 388);
            this.grpboxAction.TabIndex = 10;
            this.grpboxAction.TabStop = false;
            this.grpboxAction.Text = "Aktion";
            // 
            // btn_applyActions
            // 
            this.btn_applyActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_applyActions.Location = new System.Drawing.Point(301, 359);
            this.btn_applyActions.Name = "btn_applyActions";
            this.btn_applyActions.Size = new System.Drawing.Size(75, 23);
            this.btn_applyActions.TabIndex = 4;
            this.btn_applyActions.Text = "Apply";
            this.btn_applyActions.UseVisualStyleBackColor = true;
            this.btn_applyActions.Click += new System.EventHandler(this.btn_applyActions_Click);
            // 
            // btn_removeAction
            // 
            this.btn_removeAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_removeAction.Location = new System.Drawing.Point(87, 359);
            this.btn_removeAction.Name = "btn_removeAction";
            this.btn_removeAction.Size = new System.Drawing.Size(75, 23);
            this.btn_removeAction.TabIndex = 3;
            this.btn_removeAction.Text = "Remove";
            this.btn_removeAction.UseVisualStyleBackColor = true;
            this.btn_removeAction.Click += new System.EventHandler(this.btn_removeAction_Click);
            // 
            // treeViewActions
            // 
            this.treeViewActions.AllowDrop = true;
            this.treeViewActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewActions.HideSelection = false;
            this.treeViewActions.ImageIndex = 0;
            this.treeViewActions.ImageList = this.imageList1;
            this.treeViewActions.Location = new System.Drawing.Point(6, 19);
            this.treeViewActions.Name = "treeViewActions";
            treeNode2.Name = "NoiseLevelReached";
            treeNode2.Text = "NoiseLevelReached";
            this.treeViewActions.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeViewActions.SelectedImageIndex = 0;
            this.treeViewActions.Size = new System.Drawing.Size(370, 334);
            this.treeViewActions.TabIndex = 2;
            this.treeViewActions.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeViewActions.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewActions_NodeMouseDoubleClick);
            this.treeViewActions.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewActions_DragDrop);
            this.treeViewActions.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "939849383397179533.png");
            this.imageList1.Images.SetKeyName(1, "Open_Broadcaster_Software_Logo.png");
            this.imageList1.Images.SetKeyName(2, "void.png");
            this.imageList1.Images.SetKeyName(3, "Philips_hue_logo.png");
            // 
            // btn_Tree_Add
            // 
            this.btn_Tree_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Tree_Add.Location = new System.Drawing.Point(6, 359);
            this.btn_Tree_Add.Name = "btn_Tree_Add";
            this.btn_Tree_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Tree_Add.TabIndex = 1;
            this.btn_Tree_Add.Text = "Add";
            this.btn_Tree_Add.UseVisualStyleBackColor = true;
            this.btn_Tree_Add.Click += new System.EventHandler(this.btn_Tree_Add_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Exit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem_Exit
            // 
            this.toolStripMenuItem_Exit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoConnectRunToolStripMenuItem,
            this.toolStripSeparator3,
            this.Menu_Test_FireNoiseLevelReached,
            this.Menu_Test_FireNoiseLevelBelowThresholdAgain,
            this.toolStripSeparator1,
            this.saveSettingToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
            this.toolStripMenuItem_Exit.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem_Exit.Text = "File";
            // 
            // autoConnectRunToolStripMenuItem
            // 
            this.autoConnectRunToolStripMenuItem.CheckOnClick = true;
            this.autoConnectRunToolStripMenuItem.Name = "autoConnectRunToolStripMenuItem";
            this.autoConnectRunToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.autoConnectRunToolStripMenuItem.Text = "Auto Connect/Run";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(291, 6);
            // 
            // saveSettingToolStripMenuItem
            // 
            this.saveSettingToolStripMenuItem.Name = "saveSettingToolStripMenuItem";
            this.saveSettingToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.saveSettingToolStripMenuItem.Text = "Save Setting";
            this.saveSettingToolStripMenuItem.Click += new System.EventHandler(this.saveSettingToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(291, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 255);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(391, 170);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_OBS_Connect);
            this.tabPage1.Controls.Add(this.checkBox_ShowOBSPassword);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txt_OBS_Password);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txt_OBS_URL);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(383, 144);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "OBS Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_OBS_Connect
            // 
            this.btn_OBS_Connect.Location = new System.Drawing.Point(9, 58);
            this.btn_OBS_Connect.Name = "btn_OBS_Connect";
            this.btn_OBS_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_OBS_Connect.TabIndex = 6;
            this.btn_OBS_Connect.Text = "Anwenden";
            this.btn_OBS_Connect.UseVisualStyleBackColor = true;
            this.btn_OBS_Connect.Click += new System.EventHandler(this.btn_OBS_Connect_Click);
            // 
            // checkBox_ShowOBSPassword
            // 
            this.checkBox_ShowOBSPassword.AutoSize = true;
            this.checkBox_ShowOBSPassword.Location = new System.Drawing.Point(267, 34);
            this.checkBox_ShowOBSPassword.Name = "checkBox_ShowOBSPassword";
            this.checkBox_ShowOBSPassword.Size = new System.Drawing.Size(70, 17);
            this.checkBox_ShowOBSPassword.TabIndex = 5;
            this.checkBox_ShowOBSPassword.Text = "Anzeigen";
            this.checkBox_ShowOBSPassword.UseVisualStyleBackColor = true;
            this.checkBox_ShowOBSPassword.CheckedChanged += new System.EventHandler(this.checkBox_ShowOBSPassword_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Passwort";
            // 
            // txt_OBS_Password
            // 
            this.txt_OBS_Password.Location = new System.Drawing.Point(69, 32);
            this.txt_OBS_Password.Name = "txt_OBS_Password";
            this.txt_OBS_Password.PasswordChar = '*';
            this.txt_OBS_Password.Size = new System.Drawing.Size(192, 20);
            this.txt_OBS_Password.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "ws://127.0.0.1:4455";
            // 
            // txt_OBS_URL
            // 
            this.txt_OBS_URL.Location = new System.Drawing.Point(69, 6);
            this.txt_OBS_URL.Name = "txt_OBS_URL";
            this.txt_OBS_URL.Size = new System.Drawing.Size(192, 20);
            this.txt_OBS_URL.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "URL";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_ApplyHue);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.txt_Hue_User);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txt_Hue_URL);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(383, 144);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hue Config";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_ApplyHue
            // 
            this.btn_ApplyHue.Location = new System.Drawing.Point(302, 115);
            this.btn_ApplyHue.Name = "btn_ApplyHue";
            this.btn_ApplyHue.Size = new System.Drawing.Size(75, 23);
            this.btn_ApplyHue.TabIndex = 7;
            this.btn_ApplyHue.Text = "Anwenden";
            this.btn_ApplyHue.UseVisualStyleBackColor = true;
            this.btn_ApplyHue.Click += new System.EventHandler(this.btn_ApplyHue_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(269, 41);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Anzeigen";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txt_Hue_User
            // 
            this.txt_Hue_User.Location = new System.Drawing.Point(69, 39);
            this.txt_Hue_User.Name = "txt_Hue_User";
            this.txt_Hue_User.PasswordChar = '*';
            this.txt_Hue_User.Size = new System.Drawing.Size(194, 20);
            this.txt_Hue_User.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(9, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 23);
            this.label7.TabIndex = 3;
            this.label7.Text = "Hue User";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Hue URL";
            // 
            // txt_Hue_URL
            // 
            this.txt_Hue_URL.Location = new System.Drawing.Point(69, 8);
            this.txt_Hue_URL.Name = "txt_Hue_URL";
            this.txt_Hue_URL.Size = new System.Drawing.Size(194, 20);
            this.txt_Hue_URL.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Hue Wizard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numUpDown_PollingRate
            // 
            this.numUpDown_PollingRate.DecimalPlaces = 2;
            this.numUpDown_PollingRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUpDown_PollingRate.Location = new System.Drawing.Point(93, 81);
            this.numUpDown_PollingRate.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numUpDown_PollingRate.Name = "numUpDown_PollingRate";
            this.numUpDown_PollingRate.Size = new System.Drawing.Size(100, 20);
            this.numUpDown_PollingRate.TabIndex = 13;
            this.numUpDown_PollingRate.Tag = "";
            this.numUpDown_PollingRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(291, 6);
            // 
            // Menu_Test_FireNoiseLevelReached
            // 
            this.Menu_Test_FireNoiseLevelReached.Name = "Menu_Test_FireNoiseLevelReached";
            this.Menu_Test_FireNoiseLevelReached.Size = new System.Drawing.Size(294, 22);
            this.Menu_Test_FireNoiseLevelReached.Text = "Test: Fire NoiseLevelReached";
            this.Menu_Test_FireNoiseLevelReached.Click += new System.EventHandler(this.Menu_Test_FireNoiseLevelReached_Click);
            // 
            // Menu_Test_FireNoiseLevelBelowThresholdAgain
            // 
            this.Menu_Test_FireNoiseLevelBelowThresholdAgain.Name = "Menu_Test_FireNoiseLevelBelowThresholdAgain";
            this.Menu_Test_FireNoiseLevelBelowThresholdAgain.Size = new System.Drawing.Size(294, 22);
            this.Menu_Test_FireNoiseLevelBelowThresholdAgain.Text = "Test: Fire NoiseLevelBelowThresholdAgain";
            this.Menu_Test_FireNoiseLevelBelowThresholdAgain.Click += new System.EventHandler(this.Menu_Test_FireNoiseLevelBelowThresholdAgain_Click);
            // 
            // Schreitica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numUpDown_PollingRate);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.grpboxAction);
            this.Controls.Add(this.btn_ApplyPolling);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.btn_applyTreshold);
            this.Controls.Add(this.txt_Treshold);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Schreitica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schreitica";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpboxAction.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_PollingRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btn_ApplyHue;

        private System.Windows.Forms.TextBox txt_Hue_URL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Hue_User;
        private System.Windows.Forms.CheckBox checkBox1;

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolstrip_lbl_Connection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Treshold;
        private System.Windows.Forms.Button btn_applyTreshold;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ApplyPolling;
        private System.Windows.Forms.GroupBox grpboxAction;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem saveSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox checkBox_ShowOBSPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_OBS_Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_OBS_URL;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_OBS_Status;
        private System.Windows.Forms.NumericUpDown numUpDown_PollingRate;
        private System.Windows.Forms.Button btn_Tree_Add;
        private System.Windows.Forms.ToolStripMenuItem autoConnectRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button btn_OBS_Connect;
        private System.Windows.Forms.TreeView treeViewActions;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_removeAction;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_applyActions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem Menu_Test_FireNoiseLevelReached;
        private System.Windows.Forms.ToolStripMenuItem Menu_Test_FireNoiseLevelBelowThresholdAgain;
    }
}

