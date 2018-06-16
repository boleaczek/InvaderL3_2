using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvaderLogicLibrary.Entities.Bullets;
using InvaderLogicLibrary.Flyweight;
using InvaderLogicLibrary.Observer;

namespace InvaderLogicLibrary.Entities.Enemies
{
    public class StandardEnemy : ShotingEntity, IObserver
    {
        public int LeftLimit { get; set; }
        public int RightLimit { get; set; }
        Direction direction;
        int hitPoints;
        int hitPointsMax;

        IGameStatusObserver statusManager;

        static Random shootingSeed = new Random();
        int shootChance;
        const int shootChanceMax = 10;

        public StandardEnemy(IHitBox hb, int leftLimit, int rightLimit, IFlyweight flyweight, ICollection<IObserver> enemyEntities, IGameStatusObserver statusManager): 
            base(flyweight, hb, 1.0, Direction.Down, enemyEntities)
        {
            LeftLimit = leftLimit;
            RightLimit = rightLimit;
            direction = Direction.Left;
            Vx = 100;
            shootChance = 0;
            hitPoints = 4;
            hitPointsMax = 4;
            this.statusManager = statusManager;
        }

        protected override Direction DetermineDirection()
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
            int t = shootingSeed.Next(shootChanceMax);
            if (t <= shootChance)
            {
                return true;
            }
            return false;
        }

        public void Notify(IBullet bullet)
        {
            
            if (HitBox.IsHit(bullet.HitBox))
            {
                AfterHitModification();
                bullet.HitSignal();
                if (hitPoints <= 0)
                {
                    IsDestroyed = true;
                    bullet.DestroyedSignal(this);
                    statusManager.NotifyEnemyDestroyed();
                }
            }
        }

        void AfterHitModification()
        {
            shootChance += 1;
            hitPoints -= 1;
            HitBox.Height -= (int)(HitBox.Height / hitPointsMax);
            HitBox.Width -= (int)(HitBox.Width / hitPointsMax);
        }
    }
}
