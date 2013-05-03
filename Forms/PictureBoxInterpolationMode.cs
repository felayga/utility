using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace utility.Controls
{
    public class PictureBoxInterpolationMode : PictureBox
    {
        private InterpolationMode interpolationmode = InterpolationMode.Default;
        [DefaultValue(typeof(InterpolationMode), "Default")]
        public virtual InterpolationMode InterpolationMode { set { interpolationmode = value; } get { return interpolationmode; } }

        private PixelOffsetMode pixeloffsetmode = PixelOffsetMode.Default;
        [DefaultValue(typeof(PixelOffsetMode), "Default")]
        public virtual PixelOffsetMode PixelOffsetMode { set { pixeloffsetmode = value; } get { return pixeloffsetmode; } }

        public PictureBoxInterpolationMode()
        {
        }


        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.InterpolationMode = interpolationmode;
            pevent.Graphics.PixelOffsetMode = pixeloffsetmode;
            base.OnPaintBackground(pevent);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.InterpolationMode = interpolationmode;
            pevent.Graphics.PixelOffsetMode = pixeloffsetmode;
            base.OnPaint(pevent);
        }
    }
}
