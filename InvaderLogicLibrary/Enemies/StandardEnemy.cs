using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Enemies
{
    public class StandardEnemy : MovingEntity, IEnemy
    {
        bool destroyed;
        public int LeftLimit { get; set; }
        public int RightLimit { get; set; }
        Direction direction;

        public StandardEnemy(IHitBox hb, int leftLimit, int rightLimit): base(hb)
        {
            LeftLimit = leftLimit;
            RightLimit = rightLimit;
            direction = Direction.Left;
        }

        public void Notify(IHitBox hitBox)
        {
            if (this.HitBox.IsHit(HitBox))
            {
                destroyed = true;
            }
        }

        protected override MovingEntity.Direction DetermineDirection()
        {
            if (HitBox.X < LeftLimit)
            {
                direction = Direction.Right;
            }
            else if(HitBox.X + HitBox.Width > RightLimit)
            {
                direction = Direction.Left;
            }

            return direction;
        }
    }
}
