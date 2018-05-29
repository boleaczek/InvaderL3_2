using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using InvaderLogicLibrary.Entities;

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
            int width = 32,
                height = 32,
                startX = (800 / 2) - (width / 2),
                startY = 560;

            IHitBox hitBox = new HitBox(startX, startY, width, height);

            entityFlyweight = new Flyweight.Flyweight();

            EnemySpawner spawner = new EnemySpawner(150, 50, 50, 4, 3, 50);
            
            entityFlyweight.GameObjects = spawner.Spawn(entityFlyweight);

            player = new Player(keyboardInput, hitBox, entityFlyweight);
            player.Vx = 500;
            player.Vy = 400;
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
