using System.Windows.Forms;

namespace MythCapture
{
    internal class HideOnStartupApplicationContext: ApplicationContext
    {
        public HideOnStartupApplicationContext(Form form) {
            form.FormClosed += new FormClosedEventHandler(MainFrom_FormClosed);
        }

        protected virtual void MainFrom_FormClosed(object sender,FormClosedEventArgs args) {
            Application.Exit();
        }
    }
}
