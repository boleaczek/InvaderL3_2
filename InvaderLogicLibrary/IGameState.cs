using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace InvaderLogicLibrary
{
    public interface IGameState
    {
        void OnLoad();
        void OnUnload();
        void OnUpdate(double dt);
        void OnDraw(Graphics g);
    }
}
