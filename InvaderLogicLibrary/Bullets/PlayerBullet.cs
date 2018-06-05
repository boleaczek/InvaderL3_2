using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace InvaderLogicLibrary.Bullets
{
    public class PlayerBullet : MovingEntity, IBullet
    {
        public bool IsDestroyed;

        public PlayerBullet(IHitBox hb, double speed) : base(hb)
        {
            HitBox = hb;
            Vy = speed;
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }

        protected override Direction DetermineDirection()
        {
            return Direction.None;
        }

        protected override void HandleColision()
        {
            if(HitBox.Y - HitBox.Height <= 0)
            {
                IsDestroyed = true;
            }

        }

        new public void Draw(Graphics g)
        {
            var rect = new Rectangle((int)HitBox.X, (int)HitBox.Y, (int)HitBox.Width, (int)HitBox.Height);
            g.FillRectangle(Brushes.PaleVioletRed, rect);
        }

    }
}
