using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvaderLogicLibrary;
using NUnit.Framework;

namespace InvaderL3_2.Tests
{
    [TestFixture]
    class KeyboardInputTest
    {
        [Test]
        public void IsPressedTest()
        {
            List<Tuple<string, bool>> tests = new List<Tuple<string, bool>>();
            KeyboardInput kb = new KeyboardInput();

            tests.Add(new Tuple<string, bool>("Left", true));
            tests.Add(new Tuple<string, bool>("Right", true));
            tests.Add(new Tuple<string, bool>("Shoot", true));
            tests.Add(new Tuple<string, bool>("Left", false));
            tests.Add(new Tuple<string, bool>("Right", false));

            foreach (var test in tests)
            {
                kb.Update(test.Item1, test.Item2);

                bool got = kb.IsPressed(test.Item1),
                     want = test.Item2;

                Assert.AreEqual(want, got);
            }
        }
    }
}
