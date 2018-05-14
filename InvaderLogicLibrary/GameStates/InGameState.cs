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
        private IEntity player;
        private IKeyboardInput keyboardInput;


        public InGameState(IKeyboardInput kb)
        {
            keyboardInput = kb;
        }

        public void OnDraw(Graphics g)
        {
            player.Draw(g);
        }

        public void OnLoad()
        {
            int width = 32,
                height = 32,
                startX = (800 / 2) - (width / 2),
                startY = 560;

            IHitBox hitBox = new HitBox(startX, startY, width, height);

            player = new Player(keyboardInput, hitBox);
            player.Vx = 500;
            player.Vy = 400;
        }

        public void OnUnload()
        {
            
        }

        public void OnUpdate(double dt)
        {
            player.Update(dt);
        }
    }
}
