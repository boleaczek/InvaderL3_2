using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Enemies
{
    class StandardEnemy : IEnemy
    {
        public IHitBox hitbox { get; set; }
        bool destroyed;
        public int LeftLimit { get; set; }
        public int RightLimit { get; set; }
        public int Velocity { get; set; }
        enum Direction
        {
            Left,
            Right
        }

        Direction dir;
        public void Draw()
        {
            throw new NotImplementedException();
        }

        void CalculateDirection()
        {
            switch (dir)
            {
                case Direction.Right:
                    hitbox.X += Velocity;
                    if (hitbox.X < RightLimit)
                    {
                        dir = Direction.Right;
                    }
                    break;
                case Direction.Left:
                    hitbox.X -= Velocity;
                    if (hitbox.X > LeftLimit)
                    {
                        dir = Direction.Left;
                    }
                    break;
            }
        }

        public void Update(double dt)
        {
            CalculateDirection();
        }

        public void Notify(IHitBox hitBox)
        {
            if (this.hitbox.IsHit(hitbox))
            {
                destroyed = true;
            }
        }
    }
}
