using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using InvaderLogicLibrary.Enemies;

namespace InvaderLogicLibrary.GameStates
{
    public class InGameState : IGameState
    {
        private IEntity player;
        private IKeyboardInput keyboardInput;
        private Flyweight.Flyweight enemyFlyweight;

        public InGameState(IKeyboardInput kb)
        {
            keyboardInput = kb;
        }

        public void OnDraw(Graphics g)
        {
            player.Draw(g);
            enemyFlyweight.Draw(g);
        }

        public void OnLoad()
        {
            int width = 32,
                height = 32,
                startX = (800 / 2) - (width / 2),
                startY = 560;

            IHitBox hitBox = new HitBox(startX, startY, width, height);

            player = new Player(keyboardInput, hitBox);
            player.Vx = 500;
            player.Vy = 400;

            enemyFlyweight = new Flyweight.Flyweight();

            EnemySpawner spawner = new EnemySpawner(100, 50, 50, 5, 1, 50);
            
            enemyFlyweight.GameObjects = spawner.Spawn();

        }

        public void OnUnload()
        {

        }

        public void OnUpdate(double dt)
        {
            player.Update(dt);
            enemyFlyweight.Update(dt);
        }
    }
}
