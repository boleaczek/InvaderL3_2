using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using InvaderLogicLibrary.Entities;
using InvaderLogicLibrary.Observer;
using InvaderLogicLibrary.Builders;
using InvaderLogicLibrary.Flyweight;

namespace InvaderLogicLibrary.GameStates
{
    public class InGameState : IGameState, IGameStatusObserver
    {
        public IInfoDisplayState NextState { get; set; }
        private IKeyboardInput keyboardInput;
        public IFlyweight Flyweight { get; set; }
        Player player;
        
        public IGameStateManager StateManager { get; set; }
        ITextDisplay scoreDisplay;
        ITextDisplay hitpointsDisplay;
        public EnemySpawner Spawner { get; set; }
        public int EnemyCount { get; set; }
        public int Score { get; set; }

        public InGameState(IKeyboardInput kb, IInfoDisplayState gameSummary)
        {
            keyboardInput = kb;
            Flyweight = new Flyweight.Flyweight();

            scoreDisplay = new TextDisplay();
            hitpointsDisplay = new TextDisplay();

            NextState = gameSummary;

            Font f = new Font("Verdana", 15);
            Brush b = Brushes.White;
            scoreDisplay.Font = new Font("Verdana", 15);
            scoreDisplay.Brush = b;
            hitpointsDisplay.Font = new Font("Verdana", 15);
            hitpointsDisplay.Brush = b;
        }

        public void NotifyEnemyDestroyed()
        {
            Score += 100;
            EnemyCount--;
            scoreDisplay.Text = $"Score: {Score}";
            if (EnemyCount == 0)
            {
                NewEnemies();
            }
        }

        public void OnDraw(Graphics g)
        {
            player.Draw(g);
            hitpointsDisplay.PrintText(g, 400, 600);
            scoreDisplay.PrintText(g, 400, 650);
            Flyweight.Draw(g);
        }

        public void OnLoad()
        {
            GameStart();
        }

        public void GameStart()
        {
            CreatePlayerInitial();
            CreateSpawner();
            NewEnemies();
        }

        void NewEnemies()
        {
            ICollection<IEntity> enemies = Spawner.Spawn();
            EnemyCount = enemies.Count;
            Flyweight.GameObjects = enemies;
            player.EnemyEntities = new List<IObserver>(enemies.Select(entity => (IObserver)entity));
        }

        void CreatePlayerInitial()
        {
            int width = 32,
                height = 32,
                startX = (800 / 2) - (width / 2),
                startY = 560;

            IHitBox playerHitbox = new HitBox(startX, startY, width, height);

            player = new Player(keyboardInput, playerHitbox, Flyweight, null, this);
            player.Vx = 500;
            player.Vy = 400;
        }

        void CreateSpawner()
        {
            IHitBoxBuilder hitBoxBuilder = new HitboxBuilder(50, 50);
            IEnemyBuilder enemyBuilder = new StandardEnemyBuilder(hitBoxBuilder, new List<IObserver> { player as IObserver }, Flyweight, this);
            Spawner = new EnemySpawner(150, 50, 50, 4, 3, 50, enemyBuilder);
        }

        public void OnUnload()
        {

        }

        public void OnUpdate(double dt)
        {
            player.Update(dt);
            hitpointsDisplay.Text = $"Hit points: {player.HitPoints}";
            Flyweight.Update(dt);
        }

        public void NotifyPlayerDestroyed()
        {
            NextState.Message = $"Game Over\n Score: {Score}";
            StateManager.SetState(NextState);
        }
    }
}
