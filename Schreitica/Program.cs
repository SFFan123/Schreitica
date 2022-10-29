using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Schreitica.Actions;
using Schreitica.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Schreitica
{
    internal static class Program
    {
        internal static Form Window;
        public static USBHandler USBHandler;
        public static OBSConenction OBSConnection;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Settings settings = Settings.Instance;
            settings.Load();

            USBHandler = new USBHandler();
            var passwd = CryptHelper.Decrypt(settings.OBSPassword);

            OBSConnection = new OBSConenction(settings.OBSUrl, passwd, settings.AutoConnectRun);

            var actions = ParseActions();


            AppEvents.ThresholdExceeded += async (sender, args) =>
            {
                foreach (IActionBase action in actions)
                {
                    await action.ExecuteAsync();
                }

            };


            Application.Run(new MyCustomApplicationContext());
        }


        public static List<IActionBase> ParseActions()
        {
            string[] test = ("OBS.CurrentScene.ShowSource(ALARM)\n" +
                          "App.WaitFor(UnderThreshold)").Split('\n');
            
            List<IActionBase> actions = new List<IActionBase>();

            string actionType = string.Empty;
            for (int i = 0; i < test.Length; i++)
            {
                string commandString = test[i];
                actionType = commandString.Substring(0, commandString.IndexOf("."));
                commandString = commandString.Substring(commandString.IndexOf(".")+1);

                switch (actionType)
                {
                    case "App":
                    {
                        // nop
                        break;
                    }
                    case "OBS":
                    {
                        actions.Add(new DynamicOBSAction(OBSConnection.obs, CommandParser.ParseOBSCommand(commandString)));
                        break;
                    }
                }

            }

            return actions;
        }

        public class MyCustomApplicationContext : ApplicationContext
        {
            private NotifyIcon trayIcon;

            public MyCustomApplicationContext ()
            {
                // Initialize Tray Icon
                trayIcon = new NotifyIcon()
                {
                    Icon = Resources.AppIcon,
                    ContextMenu = new ContextMenu(new MenuItem[] {
                        new MenuItem("Show", Show),
                        new MenuItem("Exit", Exit)
                    }),
                    Visible = true
                };
                trayIcon.DoubleClick += Show;
            }

            private void Show(object sender, EventArgs e)
            {
                if (Window == null || Window.IsDisposed)
                {
                    Window = new Schreitica();
                }
                Window.Show();
            }

            void Exit(object sender, EventArgs e)
            {
                // Hide tray icon, otherwise it will remain shown until user mouses over it
                trayIcon.Visible = false;

                Application.Exit();
            }
        }
    }
}
