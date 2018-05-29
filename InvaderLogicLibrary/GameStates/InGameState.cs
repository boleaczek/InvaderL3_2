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
            //enemyFlyweight.GameObjects = new List<IEntity>() {
            //    new StandardEnemy(new HitBox(150, 150, 32, 32), 50, 500)
            //    {
            //        Vx = 100,
            //        Vy = 400
            //    },
            //    new StandardEnemy(new HitBox(250, 250, 32, 32), 50, 500)
            //    {
            //        Vx = 100,
            //        Vy = 400
            //    }};

            EnemySpawner enemySpawner = new EnemySpawner(200, 200, 50, 100, 5, 5, 10, 10);
            enemySpawner = new EnemySpawner(100, 100, 100, 50, 5, 4, 40, 40);
            
            enemyFlyweight.GameObjects = enemySpawner.Spawn();

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
