using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbCadona
{
    public class NewProgressBar : ProgressBar
    {
        public NewProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.FromArgb(255, 68, 85, 211));
            Rectangle rec = this.ClientRectangle;
            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;

            g.FillRectangle(brush, 1, 1, rec.Width, rec.Height);

            Draw3DBorder(g);

            brush.Dispose();
            g.Dispose();
        }

        private void Draw3DBorder(Graphics g)
        {
            int PenWidth = (int)Pens.White.Width;

            g.DrawLine(Pens.White, new Point(this.ClientRectangle.Left, this.ClientRectangle.Top), new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top));
            g.DrawLine(Pens.White, new Point(this.ClientRectangle.Left, this.ClientRectangle.Top), new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth));
            g.DrawLine(Pens.White, new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth), new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth));
            g.DrawLine(Pens.White, new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top), new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth));
        }
    }
}
