using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    public class TextDisplay : ITextDisplay
    {
        public string Text { get; set; }
        public Font Font { get; set; }
        public Brush Brush { get; set; }

        public void PrintText(Graphics g, float x, float y)
        {
            SizeF textSize = g.MeasureString(Text, Font);
            float xMove = x / 2 - (textSize.Width / 2),
                  yMove = y;

            g.DrawString(Text, Font, Brush, new PointF(xMove, yMove));
        }
    }
}
