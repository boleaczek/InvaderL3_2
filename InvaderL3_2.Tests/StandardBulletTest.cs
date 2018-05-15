using InvaderLogicLibrary;
using InvaderLogicLibrary.Bullets;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderL3_2.Tests
{
    [TestFixture]
    class StandardBulletTest
    {
        [Test]
        public void Reaches_border_is_destroyed()
        {
            double velocityX = 500;
            double velocityY = 0;
            StandardBullet bullet = new StandardBullet(new HitBox(0, 0, 32, 32), MovingEntity.Direction.Up, 500)
            {
                Vx = velocityX,
                Vy = velocityY
            };

            bullet.Update(1 / 60);

            Assert.AreEqual(bullet.HitBox.X, 0 + velocityX * (1 / 60));
        }
    }
}
