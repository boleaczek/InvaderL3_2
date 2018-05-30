using InvaderLogicLibrary.Observer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvaderLogicLibrary.Flyweight;
using InvaderLogicLibrary.Entities.Bullets;

namespace InvaderLogicLibrary.Entities
{
    public class Player : ShotingEntity, IObserver
    {
        IKeyboardInput keyboardInput;
        Flyweight.Flyweight entities;

        public Player(IKeyboardInput kb, IHitBox hitbox, Flyweight.Flyweight entityFlyweight) : base(entityFlyweight, hitbox, 8.0, Direction.Up)
        {
            keyboardInput = kb;
            entities = entityFlyweight;
        }

        public void Notify(IHitBox hitBox)
        {
            
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

        protected override bool IsShooting()
        {
            if(keyboardInput.IsPressed("Space") == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}