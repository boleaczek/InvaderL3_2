using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace InvaderLogicLibrary.GameStates
{
    public class InGameState : IGameState
    {
        public void OnDraw(Graphics g)
        {
            var rect = new Rectangle(0, 0, 120, 120);
            g.FillRectangle(Brushes.LightCyan, rect);
        }

        public void OnLoad()
        {
            
        }

        public void OnUnload()
        {
            
        }

        public void OnUpdate(double dt)
        {
        
        }
    }
}
