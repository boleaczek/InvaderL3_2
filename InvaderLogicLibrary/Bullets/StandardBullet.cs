using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Bullets
{
    public class StandardBullet : MovingEntity, IBullet
    {
        Direction direction;
        int limit;
        bool destroyed;

        public StandardBullet(IHitBox hb, Direction dir, int limitY) : base(hb)
        {
            direction = dir;
            limit = limitY;
            destroyed = false;
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }

        protected override Direction DetermineDirection()
        {
            return direction;
        }

        protected override void HandleColision()
        {
            if(HitBox.Y > limit)
            {
                destroyed = true;
            }
        }

    }
}
