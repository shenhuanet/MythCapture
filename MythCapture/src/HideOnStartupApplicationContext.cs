using System.Windows.Forms;

namespace MythCapture
{
    class HideOnStartupApplicationContext: ApplicationContext
    {
        public HideOnStartupApplicationContext(MythCapture form) {
            form.FormClosed += new FormClosedEventHandler(MainFrom_FormClosed);
        }

        void MainFrom_FormClosed(object sender,FormClosedEventArgs args) {
            Application.Exit();
        }
    }
}
