using InvaderLogicLibrary.Observer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvaderLogicLibrary.Flyweight;
using InvaderLogicLibrary.Bullets;

namespace InvaderLogicLibrary
{
    public class Player : MovingEntity, IObserver
    {
        IKeyboardInput keyboardInput;
        Flyweight.Flyweight entities;
        double lastShoot;
        double fireRate;
        

        public Player(IKeyboardInput kb, IHitBox hitbox, Flyweight.Flyweight entityFlyweight) : base(hitbox)
        {
            keyboardInput = kb;
            entities = entityFlyweight;
            lastShoot = 0;
            fireRate = 8.0;
        }

        public void Notify(IHitBox hitBox)
        {
            throw new NotImplementedException();
        }

        protected override Direction DetermineDirection()
        {
            if (keyboardInput.IsPressed("Left"))
                return Direction.Left;
            else if (keyboardInput.IsPressed("Right"))
                return Direction.Right;
            else
                return Direction.None;
        }

        new public void Update(double dt)
        {
            base.Update(dt);

            if (keyboardInput.IsPressed("Space"))
            {

                if (lastShoot == 0)
                {
                    double bulletWidth = 4.0,
                           bulletHeight = 30.0;

                    double bulletX = HitBox.X + (HitBox.Width / 2) - (bulletWidth / 2),
                           bulletY = HitBox.Y - bulletHeight / 2;

                    IHitBox hitbox = new HitBox(bulletX, bulletY, bulletWidth, bulletHeight);
                    StandardBullet bullet = new StandardBullet(hitbox, Direction.Up, 0);
                    bullet.Vy = 500;
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
}