using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            USBHandler = new USBHandler();
            var passwd = new SecureString();
            foreach(char c in "reLFqhqy62Pq3dOH")
                passwd.AppendChar(c);

            OBSConnection = new OBSConenction("ws://127.0.0.1:4455", passwd);

            Application.Run(new MyCustomApplicationContext());
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
