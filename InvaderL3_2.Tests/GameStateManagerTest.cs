using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using InvaderLogicLibrary;

namespace InvaderL3_2.Tests
{
    public class MockGameState : IGameState
    {
        public int OnDrawCallCount;
        public int OnLoadCallCount;
        public int OnUnloadCallCount;
        public int OnUpdateCallCount;

        public MockGameState()
        {
            this.OnDrawCallCount = 0;
            this.OnLoadCallCount = 0;
            this.OnUnloadCallCount = 0;
            this.OnUpdateCallCount = 0;
        }

        public void OnDraw(Graphics g)
        {
            this.OnDrawCallCount++;
        }

        public void OnLoad()
        {
            this.OnLoadCallCount++;
        }

        public void OnUnload()
        {
            this.OnUnloadCallCount++;
        }

        public void OnUpdate(double dt)
        {
            this.OnUpdateCallCount++;
        }
    }

    [TestFixture]
    class GameStateManagerTest
    {
        [Test]
        public void OnLoadIsCalledAfterCreatingStateManagerWithDefaultStateTest()
        {
            MockGameState gameState = new MockGameState();
            GameStateManager stateManager = new GameStateManager(gameState);

            // sprawdzenie czy wykonał się OnLoad po utworzeniu GameStateManagera z domyślnego GameState
            int got = gameState.OnLoadCallCount;
            int want = 1;

            Assert.AreEqual(want, got);
        }

        [Test]
        public void OnUnloadAndOnLoadIsCalledAfterStateChange()
        {
            MockGameState firstState = new MockGameState();
            MockGameState secondState = new MockGameState();
            GameStateManager stateManager = new GameStateManager(firstState);

            stateManager.SetState(secondState);

            // czy zmiana stanu wywołała OnUnload na starym stanie?
            int got = firstState.OnUnloadCallCount;
            int want = 1;

            Assert.AreEqual(want, got);

            // czy zmiana stanu wywołała OnLoad na nowym stanie?
            got = secondState.OnLoadCallCount;
            want = 1;

            Assert.AreEqual(want, got);
        }
    }
}
