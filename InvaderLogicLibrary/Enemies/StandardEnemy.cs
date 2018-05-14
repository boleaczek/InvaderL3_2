using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Enemies
{
    class StandardEnemy : IEnemy
    {
        public IHitBox HitBox { get; set; }
        bool destroyed;
        public int LeftLimit { get; set; }
        public int RightLimit { get; set; }
        public int Velocity { get; set; }
        public double Vx { get; set; }
        public double Vy { get; set; }

        enum Direction
        {
            Left,
            Right
        }

        Direction dir;
  
        void CalculateDirection()
        {
            switch (dir)
            {
                case Direction.Right:
                    HitBox.X += Velocity;
                    if (HitBox.X < RightLimit)
                    {
                        dir = Direction.Right;
                    }
                    break;
                case Direction.Left:
                    HitBox.X -= Velocity;
                    if (HitBox.X > LeftLimit)
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
            if (this.HitBox.IsHit(HitBox))
            {
                destroyed = true;
            }
        }

        public void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
