using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.GameStates
{
    public interface IGameStateManager
    {
        void SetState(IGameState newState);

        void Update(double dt);

        void Draw(Graphics g);
    }
}
