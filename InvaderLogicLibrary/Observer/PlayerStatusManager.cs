using InvaderLogicLibrary.Builders;
using InvaderLogicLibrary.Entities;
using InvaderLogicLibrary.Flyweight;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Observer
{
    class GameStatusManager
    {
        int score = 0;
        Player player;
        public IFlyweight Flyweight { get; set; }
        IKeyboardInput keyboardInput;
        ITextDisplay scoreDisplay;
        ITextDisplay hitpointsDisplay;
        public EnemySpawner Spawner { get; set; }
        public int EnemyCount { get; set; }
        public bool GameOver { get; set; }

        public GameStatusManager(IKeyboardInput kbInput)
        {
            keyboardInput = kbInput;
            Flyweight = new Flyweight.Flyweight();
            scoreDisplay = new TextDisplay();
            hitpointsDisplay = new TextDisplay();
            GameOver = false;

            Font f = new Font("Verdana", 15);
            Brush b = Brushes.White;
            scoreDisplay.Font = new Font("Verdana", 15);
            scoreDisplay.Brush = b;
            hitpointsDisplay.Font = new Font("Verdana", 15);
            hitpointsDisplay.Brush = b;
        }

        public int GetScore()
        {
            return score;
        }

        public void NotifyEnemyDestroyed()
        {
            score += 100;
            EnemyCount--;
            scoreDisplay.Text = $"Score: {score}";
            if (EnemyCount == 0)
            {
                NewEnemies();
            }
        }

        public void GameStart()
        {
            CreatePlayerInitial();
            CreateSpawner();
            NewEnemies();
        }

        void CreatePlayerInitial()
        {
            int width = 32,
                height = 32,
                startX = (800 / 2) - (width / 2),
                startY = 560;

            IHitBox playerHitbox = new HitBox(startX, startY, width, height);

            player = new Player(keyboardInput, playerHitbox, Flyweight, null, null);
            player.Vx = 500;
            player.Vy = 400;
        }

        void CreateSpawner()
        {
            IHitBoxBuilder hitBoxBuilder = new HitboxBuilder(50, 50);
          //  IEnemyBuilder enemyBuilder = new StandardEnemyBuilder(hitBoxBuilder, new List<IObserver> { player as IObserver }, Flyweight, this);
            //Spawner = new EnemySpawner(150, 50, 50, 4, 3, 50, enemyBuilder);
        }

        void NewEnemies()
        {
            ICollection<IEntity> enemies = Spawner.Spawn();
            EnemyCount = enemies.Count;
            Flyweight.GameObjects = enemies;
            player.EnemyEntities = new List<IObserver>(enemies.Select(entity => (IObserver)entity));
        }

        public void Draw(Graphics g)
        {
            player.Draw(g);
            hitpointsDisplay.PrintText(g, 400, 600);
            scoreDisplay.PrintText(g, 400, 650);
            Flyweight.Draw(g);
        }

        public void Update(double dt)
        {
            player.Update(dt);
            hitpointsDisplay.Text = $"Hit points: {player.HitPoints}";
            Flyweight.Update(dt);
        }
    }
}
