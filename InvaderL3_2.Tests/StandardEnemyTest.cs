using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvaderLogicLibrary.Enemies;
using InvaderLogicLibrary;

namespace InvaderL3_2.Tests
{
    [TestFixture]
    public class StandardEnemyTest
    {
        [Test]
        public void Velocity_set_to_500_position_x_increases_by_500_multiplied_by_dt_after_update()
        {
            double velocityX = 500;
            double velocityY = 0;
            StandardEnemy standardEnemy = new StandardEnemy(new HitBox(0, 0, 32, 32), 50, 500)
            {
                Vx = velocityX,
                Vy = velocityY
            };

            standardEnemy.Update(1/60);

            Assert.AreEqual(standardEnemy.HitBox.X, 0 + velocityX * (1 / 60));

        }
    }
}
