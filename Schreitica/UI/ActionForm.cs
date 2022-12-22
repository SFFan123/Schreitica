using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Schreitica.Actions;
using Schreitica.Actions.Hue;
using Schreitica.Actions.OBS;

namespace Schreitica.UI
{
    public partial class ActionForm : Form
    {
        public ActionForm()
        {
            InitializeComponent();

            DialogResult = DialogResult.None;

            OBSActions = new object[] { nameof(HideSource), nameof(ShowSource), nameof(SwitchScene) };
            AppActions = new object[] { "Wait", "WaitFor" };
            HueActions = new object[] { nameof(TurnOnLight), nameof(TurnOffLight) };


            paramDictionary = new Dictionary<object, string>()
            {
                {nameof(HideSource), "SourceName"},
                {nameof(ShowSource), "SourceName"},
                {nameof(SwitchScene), "SceneName"},
                {"Wait", "Time in s"},
                {"WaitFor", "Eventname" },
                {nameof(TurnOnLight), "LightName" },
                {nameof(TurnOffLight), "LightName" },
            };
        }

        public ActionForm(object ActionType, object ActionName, object Parameter):this()
        {
            // TODO
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (DialogResult == DialogResult.None)
                DialogResult = DialogResult.Abort;
        }

        private readonly object[] OBSActions;
        private readonly object[] AppActions;
        private readonly object[] HueActions;

        private readonly Dictionary<object, string> paramDictionary;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_ActionType.SelectedItem)
            {
                case "OBS":
                    comboBox_Actions.Items.Clear();
                    comboBox_Actions.Items.AddRange(OBSActions);

                    comboBox_Actions.Enabled = true;
                    break;

                case "App":
                    comboBox_Actions.Items.Clear();
                    comboBox_Actions.Items.AddRange(AppActions);

                    comboBox_Actions.Enabled = true;
                    break;

                case "Hue":
                    comboBox_Actions.Items.Clear();
                    comboBox_Actions.Items.AddRange(HueActions);

                    comboBox_Actions.Enabled = true;
                    break;

                default:
                    comboBox_Actions.Enabled = false;
                    break;
            }

            comboBox_Actions.SelectedItem = null;
            comboBox_Actions.Text = null;
            comboBox_Actions_SelectedIndexChanged(sender, e);
        }

        private void comboBox_Actions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var elm = (string)comboBox_Actions.SelectedItem;

            if (string.IsNullOrEmpty(elm))
            {
                txt_Param.Enabled = false;
                lbl_ParamInfo.Text = string.Empty;
                return;
            }

            lbl_ParamInfo.Text = paramDictionary[elm];

            if (elm == "WaitFor")
            {
                txt_Param.Text = nameof(AppEvents.BelowThresholdAgain);
                txt_Param.ReadOnly = true;
                
            }
            else
            {
                txt_Param.ReadOnly = false;
            }
            txt_Param.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox_ActionType.SelectedItem)
                {
                    case "OBS":
                        switch (comboBox_Actions.SelectedItem)
                        {
                            case nameof(HideSource):
                                ResultAction = new HideSource(txt_Param.Text.Trim());
                                break;
                                
                            case nameof(ShowSource):
                                ResultAction = new ShowSource(txt_Param.Text.Trim());
                                break;
                                
                            case nameof(SwitchScene):
                                ResultAction = new SwitchScene(txt_Param.Text.Trim());
                                break;
                        }
                        break;

                    case "App":
                        switch (comboBox_Actions.SelectedItem)
                        {
                            case "Wait":
                                ResultAction = new WaitAction(int.Parse(txt_Param.Text.Trim()));
                                break;
                            case "WaitFor":
                                ResultAction = new WaitForEventAction(txt_Param.Text.Trim());
                                break;
                        }
                        break;

                    case "Hue":
                        switch (comboBox_Actions.SelectedItem)
                        {
                            case nameof(TurnOnLight):
                                ResultAction = new TurnOnLight(txt_Param.Text.Trim());
                                break;
                            case nameof(TurnOffLight):
                                ResultAction = new TurnOffLight(txt_Param.Text.Trim());
                                break;
                        }
                        break;

                    default:
                        throw new ArgumentException();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }
        
        
        public IActionBase ResultAction { get; private set; }
    }
}
