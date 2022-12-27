using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Schreitica.Actions;
using Schreitica.Properties;

namespace Schreitica
{
    internal static class Program
    {
        internal static Form Window;
        public static USBHandler USBHandler;
        public static OBSConenction OBSConnection;
        public static List<IActionBase> Actions;
        public static NotifyIcon TrayIcon;

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

            Actions = new List<IActionBase>(settings.Actions.Length);
            foreach (string settingsAction in settings.Actions)
            {
                Actions.Add(ParseAction(settingsAction));
            }

            USBHandler = new USBHandler();
            var passwd = CryptHelper.Decrypt(settings.OBSPassword);

            OBSConnection = new OBSConenction(settings.OBSUrl, passwd, settings.AutoConnectRun);


            AppEvents.ThresholdExceeded += async (sender, args) =>
            {
                foreach (IActionBase action in Actions)
                {
                    try
                    {
                        await action.ExecuteAsync();
                    }
                    catch (Exception e)
                    {
                        TrayIcon.ShowBalloonTip(1000, $"Fehler in Aktion: {Actions.IndexOf(action)}", $"Fehler action: {action.LogName}{Environment.NewLine}{(e.InnerException?.Message ?? e.Message)}", ToolTipIcon.Error);
                        if (!Settings.Instance.ContinueOnActionError)
                        {
                            break;
                        }
                    }
                }
            };
            Application.Run(new MyCustomApplicationContext());
        }


        public static IActionBase ParseAction(string commandString)
        {
            IActionBase action = null;

            string actionType = commandString.Substring(0, commandString.IndexOf("."));
            commandString = commandString.Substring(commandString.IndexOf(".") + 1);

            switch (actionType)
            {
                case "App":
                {
                    action = CommandParser.ParseAppCommand(commandString);
                    break;
                }
                case "OBS":
                {
                    action = CommandParser.ParseOBSCommand(commandString);
                    break;
                }
                case "Hue":
                {
                    action = CommandParser.ParseHueCommand(commandString);
                    break;
                }
            }

            return action;
        }

        public class MyCustomApplicationContext : ApplicationContext
        {
            private NotifyIcon trayIcon;

            public MyCustomApplicationContext()
            {
                // Initialize Tray Icon
                trayIcon = new NotifyIcon()
                {
                    Icon = Resources.AppIcon,
                    ContextMenu = new ContextMenu(new MenuItem[]
                    {
                        new MenuItem("Show", Show),
                        new MenuItem("Exit", Exit)
                    }),
                    Visible = true
                };
                trayIcon.DoubleClick += Show;
                TrayIcon = trayIcon;
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