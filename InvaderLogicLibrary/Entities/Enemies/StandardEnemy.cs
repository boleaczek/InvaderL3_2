using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Entities.Enemies
{
    public class StandardEnemy : ShotingEntity, IEnemy
    {
        bool destroyed;
        public int LeftLimit { get; set; }
        public int RightLimit { get; set; }
        Direction direction;

        public StandardEnemy(IHitBox hb, int leftLimit, int rightLimit, Flyweight.Flyweight flyweight): base(flyweight, hb, 1.0, Direction.Down)
        {
            LeftLimit = leftLimit;
            RightLimit = rightLimit;
            direction = Direction.Left;
            Vx = 100;
        }

        public void Notify(IHitBox hitBox)
        {
            if (HitBox.IsHit(HitBox))
            {
                destroyed = true;
            }
        }

        protected override MovingEntity.Direction DetermineDirection()
        {
            if (HitBox.X <= LeftLimit)
            {
                direction = Direction.Right;
            }
            else if(HitBox.X + HitBox.Width >= RightLimit)
            {
                direction = Direction.Left;
            }

            return direction;
        }

        protected override bool IsShooting()
        {
            return true;
        }
    }
}
