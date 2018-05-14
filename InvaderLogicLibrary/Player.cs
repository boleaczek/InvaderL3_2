using InvaderLogicLibrary.Observer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    public class Player : MovingEntity, IObserver
    {
        IKeyboardInput keyboardInput;

        public Player(IKeyboardInput kb, IHitBox hitbox) : base(hitbox)
        {
            keyboardInput = kb;
        }

        public void Notify(IHitBox hitBox)
        {
            throw new NotImplementedException();
        }

        protected override Direction DetermineDirection()
        {
            if (keyboardInput.IsPressed("Left"))
                return Direction.Left;
            else if (keyboardInput.IsPressed("Right"))
                return Direction.Right;
            else
                return Direction.None;
                
        }
    }
}
