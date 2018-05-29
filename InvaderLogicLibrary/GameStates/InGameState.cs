﻿using System;
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

            EnemySpawner enemySpawner = new EnemySpawner(200, 200, 50, 100, 5, 5, 10, 10);
            enemySpawner = new EnemySpawner(100, 100, 100, 50, 5, 4, 40, 40);
            
            entityFlyweight.GameObjects = enemySpawner.Spawn();

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
