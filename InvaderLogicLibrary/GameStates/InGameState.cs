using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using InvaderLogicLibrary.Entities;
using InvaderLogicLibrary.Observer;
using InvaderLogicLibrary.Builders;

namespace InvaderLogicLibrary.GameStates
{
    public class InGameState : IGameState
    {
        private Player player;
        private IKeyboardInput keyboardInput;
        private Flyweight.Flyweight entityFlyweight;

        public InGameState(IKeyboardInput kb)
        {
            keyboardInput = kb;
        }

        public void OnDraw(Graphics g)
        {
            entityFlyweight.Draw(g);
            player.Draw(g);
        }

        public void OnLoad()
        {
            entityFlyweight = new Flyweight.Flyweight();



            //define initial player instance that can be provided to EnemySpawner.Spawn method
            int width = 32,
                height = 32,
                startX = (800 / 2) - (width / 2),
                startY = 560;

            IHitBox playerHitbox = new HitBox(startX, startY, width, height);

            player = new Player(keyboardInput, playerHitbox, entityFlyweight, null);
            player.Vx = 500;
            player.Vy = 400;

            //initializing enemies
            IHitBoxBuilder hitBoxBuilder = new HitboxBuilder(50, 50);
            IEnemyBuilder enemyBuilder = new StandardEnemyBuilder(hitBoxBuilder, new List<IObserver> { player }, entityFlyweight);
            EnemySpawner spawner = new EnemySpawner(150, 50, 50, 4, 3, 50, enemyBuilder);
            ICollection<IEntity> enemies = spawner.Spawn();
            entityFlyweight.GameObjects = enemies;

            //now that enemies have been created, initialize EnemyEnties for player and GameObjects for flyweight
            player.EnemyEntities = new List<IObserver>(enemies.Select(entity => (IObserver)entity));
        }

        public void OnUnload()
        {

        }

        public void OnUpdate(double dt)
        {
            player.Update(dt);
            entityFlyweight.Update(dt);
        }
    }
}
