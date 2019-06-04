using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbCadona
{
    public partial class SplashScreen : Form
    {
        const Int32 HTCAPTION = 0x02;
        const Int32 WM_NCHITTEST = 0x84;
        private delegate void ProgressDelegate(int progress);
        private ProgressDelegate del;

        public SplashScreen()
        {
            this.ShowInTaskbar = false;
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;

            InitializeComponent();

            this.lblVersion.Text = "v1.0.0";
            this.progressBar1.Maximum = 100;
            del = this.UpdateProgressInternal;
        }

        private void UpdateProgressInternal(int progress)
        {
            if (this.Handle == null)
            {
                return;
            }
            this.progressBar1.Value = progress;
        }

        public void UpdateProgress(int progress)
        {
            this.Invoke(del, progress);
        }

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == WM_NCHITTEST)
            {
                message.Result = (IntPtr)HTCAPTION;
            }
            else
            {
                base.WndProc(ref message);
            }
        }
    }
}
