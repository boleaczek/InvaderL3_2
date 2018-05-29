using InvaderLogicLibrary.Entities.Bullets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Entities
{
    public abstract class ShotingEntity : MovingEntity
    {
        Flyweight.Flyweight entities;
        double lastShoot;
        double fireRate;

        public ShotingEntity(Flyweight.Flyweight entities, IHitBox hitbox, double fireRate) : base(hitbox)
        {
            this.entities = entities;
            this.fireRate = 8.0;
            lastShoot = 0;
            
        }

        new public void Update(double dt)
        {
            base.Update(dt);

            if (IsShooting())
            {
                SpawnBullets(dt);
            }
        }

        protected abstract bool IsShooting();

        void SpawnBullets(double dt)
        {
            if (lastShoot == 0)
            {
                double bulletWidth = 4.0,
                       bulletHeight = 30.0;

                int bulletX = HitBox.X + (int)((HitBox.Width / 2) - (bulletWidth / 2)),
                       bulletY = HitBox.Y - (int)(bulletHeight / 2);

                IHitBox hitbox = new HitBox(bulletX, bulletY, bulletWidth, bulletHeight);
                StandardBullet bullet = new StandardBullet(hitbox, Direction.Up, 0)
                {
                    Vy = 500
                };
                entities.GameObjects.Add(bullet);
            }

            lastShoot += dt;

            if (lastShoot >= 1.0 / fireRate)
            {
                lastShoot = 0;
            }
        }
    }
}
