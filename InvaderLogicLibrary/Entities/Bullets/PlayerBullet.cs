using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using InvaderLogicLibrary.Observer;

namespace InvaderLogicLibrary.Entities.Bullets
{
    public class PlayerBullet : MovingEntity, IBullet
    {
        public bool IsDestroyed;

        public ICollection<IObserver> Observers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
            var rect = new Rectangle(HitBox.X, HitBox.Y, (int)HitBox.Width, (int)HitBox.Height);
            g.FillRectangle(Brushes.PaleVioletRed, rect);
        }

    }
}
