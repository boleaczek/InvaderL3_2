using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    class GameStateManager
    {
        IGameState currentState;

        GameStateManager(IGameState defaultState)
        {
            this.currentState = defaultState;
        }

        void SetState(IGameState newState)
        {
            this.currentState.OnUnload();
            this.currentState = newState;
            this.currentState.OnLoad();
        }

        void Update(double dt)
        {
            this.currentState.OnUpdate(dt);
        }

        void Draw()
        {
            this.currentState.OnDraw();
        }


    }

}
