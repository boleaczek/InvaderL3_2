using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvaderLogicLibrary.Entities.Bullets;
using InvaderLogicLibrary.Observer;

namespace InvaderLogicLibrary.Entities.Enemies
{
    public class StandardEnemy : ShotingEntity, IEnemy
    {
        bool destroyed;
        public int LeftLimit { get; set; }
        public int RightLimit { get; set; }
        Direction direction;

        public StandardEnemy(IHitBox hb, int leftLimit, int rightLimit, Flyweight.Flyweight flyweight, ICollection<IObserver> enemyEntities): 
            base(flyweight, hb, 1.0, Direction.Down, enemyEntities)
        {
            LeftLimit = leftLimit;
            RightLimit = rightLimit;
            direction = Direction.Left;
            Vx = 100;
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

        public void Notify(IBullet bullet)
        {
            if(HitBox.IsHit(bullet.HitBox))
            {
                IsDestroyed = true;
                bullet.HitSignal();
                bullet.DestroyedSignal(this);
            }
        }
    }
}
