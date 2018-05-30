using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using InvaderLogicLibrary.Observer;

namespace InvaderLogicLibrary.Entities.Bullets
{
    public class StandardBullet : MovingEntity, IBullet
    {
        Direction direction;
        int limit;
        public bool IsDestroyed;

        public ICollection<IObserver> Observers { get; set; }

        public StandardBullet(IHitBox hb, Direction dir, int limitY) : base(hb)
        {
            direction = dir;
            limit = limitY;
            IsDestroyed = false;
        }

        public void Notify()
        {
            foreach (IObserver observer in Observers)
            {
                observer.Notify(HitBox);
            }
        }

        protected override Direction DetermineDirection()
        {
            return direction;
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
