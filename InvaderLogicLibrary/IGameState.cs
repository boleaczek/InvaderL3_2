using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    interface IGameState
    {
        void OnLoad();
        void OnUnload();
        void OnUpdate(double dt);
        void OnDraw();
    }
}
