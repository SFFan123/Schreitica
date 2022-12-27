using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Schreitica.Actions;
using Schreitica.Actions.Hue;
using Schreitica.Actions.OBS;
using Schreitica.Properties;
using Schreitica.UI;

namespace Schreitica
{
    public partial class Schreitica : Form
    {
        private List<IActionBase> _actions;

        public Schreitica()
        {
            Icon = Resources.AppIcon;
            InitializeComponent();

            UsbConnectionStateChanged(null, new ConnectionChangedEventArgs(Program.USBHandler.IsConnected));
            OBSConnectionStateChanged(null, new ConnectionChangedEventArgs(OBSConenction.Instance.IsConnected));

            AppEvents.USBConnectionStateChanged += UsbConnectionStateChanged;
            AppEvents.OBSConnectionStateChanged += OBSConnectionStateChanged;
            
            init_GetValues();
        }

        private void init_ParsePollingDelay()
        {
            double delay = Program.USBHandler.pollingDelay;

            double hz = 1000 / delay;

            this.numUpDown_PollingRate.Value = (decimal)hz;
        }

        private void init_LoadActions()
        {
            _actions = Program.Actions;
            foreach (var action in _actions)
            {
                addNodeToTree(action);
            }

            treeViewActions.Nodes[0].Expand();
        }

        private void addNodeToTree(IActionBase action)
        {
            int OBSImageIndex = 1;
            int AppImageIndex = 2;
            int HueImageIndex = 3;


            var type = action.GetType();
            string name = action.ToXMLAction();
            if (type.IsSubclassOf(typeof(OBSBase)))
            {
                treeViewActions.Nodes[0].Nodes.Add(name, name.Substring(name.IndexOf(".") + 1), OBSImageIndex,
                    selectedImageIndex: OBSImageIndex);
            }
            else if (type.IsSubclassOf(typeof(AppAction)))
            {
                treeViewActions.Nodes[0].Nodes.Add(name, name.Substring(name.IndexOf(".") + 1), AppImageIndex,
                    selectedImageIndex: AppImageIndex);
            }
            else if (type.IsSubclassOf(typeof(HueBase)))
            {
                treeViewActions.Nodes[0].Nodes.Add(name, name.Substring(name.IndexOf(".") + 1), HueImageIndex,
                    selectedImageIndex: HueImageIndex);
            }
        }


        private void init_GetValues()
        {
            if (!string.IsNullOrEmpty(Settings.Instance.OBSPassword))
            {
                txt_OBS_Password.Text =
                    new NetworkCredential(string.Empty, CryptHelper.Decrypt(Settings.Instance.OBSPassword)).Password;
            }

            txt_OBS_URL.Text = Settings.Instance.OBSUrl;

            txt_Hue_URL.Text = Settings.Instance.HueURL;
            txt_Hue_User.Text = Settings.Instance.HueUser;

            continueOnErrorToolStripMenuItem.Checked = Settings.Instance.ContinueOnActionError;

            init_ParsePollingDelay();
            init_LoadActions();
        }

        private void UsbConnectionStateChanged(object sender, ConnectionChangedEventArgs e)
        {
            this.btn_Start.Enabled = e.Connected;
            this.btn_Stop.Enabled = e.Connected;
            this.toolstrip_lbl_Connection.Text = e.Connected ? "Connected" : "Disconnected";
        }

        private void OBSConnectionStateChanged(object sender, ConnectionChangedEventArgs e)
        {
            this.toolStripStatusLabel_OBS_Status.Text = e.Connected ? "Connected" : "Disconnected";
        }

        private void saveSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SettingHelper.SaveSetting(Settings.Instance.ToXML());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show(exception.Message, exception.GetType().Name, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void checkBox_ShowOBSPassword_CheckedChanged(object sender, EventArgs e)
        {
            txt_OBS_Password.PasswordChar = checkBox_ShowOBSPassword.Checked ? '\0' : '*';
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Program.USBHandler.StartReading();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            Program.USBHandler.StopReading();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var diag = new HueWizard();
            var res = diag.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                txt_Hue_URL.Text = diag.HueAdress;
                txt_Hue_User.Text = diag.UserName;

                Settings.Instance.HueURL = diag.HueAdress;
                Settings.Instance.HueUser = diag.UserName;

                if (MessageBox.Show("Save Settings now?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                {
                    SettingHelper.SaveSetting(Settings.Instance.ToXML());
                }
            }
        }

        private void treeViewActions_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
            }
        }

        private void btn_applyTreshold_Click(object sender, EventArgs e)
        {
            string textval = txt_Treshold.Text.Trim();
            if (string.IsNullOrEmpty(textval) || string.IsNullOrWhiteSpace(textval))
                return;

            if (double.TryParse(txt_Treshold.Text, out double newval))
            {
                Settings.Instance.DbThreshold = newval;
            }
            else
            {
                MessageBox.Show("Invalid number");
            }
        }

        private void btn_OBS_Connect_Click(object sender, EventArgs e)
        {
            Settings.Instance.OBSPassword = CryptHelper.Encrypt(txt_OBS_Password.Text);
            Settings.Instance.OBSUrl = txt_OBS_URL.Text;

            Program.OBSConnection.Dispose();
            Program.OBSConnection = new OBSConenction(Settings.Instance.OBSUrl,
                CryptHelper.Decrypt(Settings.Instance.OBSPassword), true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txt_Hue_User.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void btn_ApplyHue_Click(object sender, EventArgs e)
        {
            Settings.Instance.HueURL = txt_Hue_URL.Text;
            Settings.Instance.HueUser = txt_Hue_User.Text;
        }

        private void btn_Tree_Add_Click(object sender, EventArgs e)
        {
            var from = new ActionForm("Create Action");
            if (from.ShowDialog(this) == DialogResult.OK)
            {
                _actions.Add(from.ResultAction);

                addNodeToTree(from.ResultAction);
            }

            from.Dispose();
        }

        private void treeViewActions_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = treeViewActions.PointToClient(new Point(e.X, e.Y));

            TreeNode targetNode = treeViewActions.GetNodeAt(targetPoint);

            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (!draggedNode.Equals(targetNode) && targetNode != null)
            {
                var act = _actions[draggedNode.Index];
                _actions.Remove(act);
                draggedNode.Remove();
                treeViewActions.Nodes[0].Nodes.Insert(targetNode.Index, draggedNode);
                _actions.Insert(draggedNode.Index, act);
            }
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void btn_applyActions_Click(object sender, EventArgs e)
        {
            Program.Actions = _actions;
        }

        private void btn_removeAction_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in treeViewActions.Nodes[0].Nodes)
            {
                if (node.IsSelected)
                {
                    _actions.RemoveAt(node.Index);
                    node.Remove();
                    return;
                }
            }
        }

        private void btn_ApplyPolling_Click(object sender, EventArgs e)
        {
            double hz = (double)numUpDown_PollingRate.Value;
            int delay = (int) (1/hz * 1000);
            Settings.Instance.USBPollingDelay = delay;
            Program.USBHandler.pollingDelay = delay;
        }

        private void Menu_Test_FireNoiseLevelBelowThresholdAgain_Click(object sender, EventArgs e)
        {
            AppEvents.RaiseBelowThresholdAgain(sender, e);
        }

        private void Menu_Test_FireNoiseLevelReached_Click(object sender, EventArgs e)
        {
            AppEvents.RaiseThresholdExceeded(sender, e);
        }

        private void continueOnErrorToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Instance.ContinueOnActionError = continueOnErrorToolStripMenuItem.Checked;
        }
    }
}