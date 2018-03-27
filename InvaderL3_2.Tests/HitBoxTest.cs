using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvaderLogicLibrary;


namespace InvaderL3_2.Tests
{
    [TestFixture]
    public class HitBoxTest
    {
        [Test]
        public void IsHitTest()
        {
            HitBox a = new HitBox(10, 10, 10, 10);
            HitBox b = new HitBox(0, 0, 20, 20);

            bool got = a.IsHit(b);
            bool want = true;

            Assert.AreEqual(want, got);



        }
    }
}
