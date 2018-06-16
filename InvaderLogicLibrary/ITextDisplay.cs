using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    public interface ITextDisplay
    {
        string Text { get; set; }
        Font Font { get; set; }
        Brush Brush { get; set; }

        void PrintText(Graphics g, float x, float y);
    }
}
