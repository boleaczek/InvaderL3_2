using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace InvaderLogicLibrary
{
    public class GameStateManager
    {
        IGameState currentState;

        public GameStateManager(IGameState defaultState)
        {
            this.currentState = defaultState;
            this.currentState.OnLoad();
        }

        public void SetState(IGameState newState)
        {
            this.currentState.OnUnload();
            this.currentState = newState;
            this.currentState.OnLoad();
        }

        public void Update(double dt)
        {
            this.currentState.OnUpdate(dt);
        }

        public void Draw(Graphics g)
        {
            this.currentState.OnDraw(g);
        }

    }

}
