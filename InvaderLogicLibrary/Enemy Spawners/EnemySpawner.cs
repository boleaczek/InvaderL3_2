using InvaderLogicLibrary.Entities.Enemies;
using InvaderLogicLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvaderLogicLibrary.Observer;
using InvaderLogicLibrary.Builders;

namespace InvaderLogicLibrary
{
    public class EnemySpawner
    {
        int startX;
        int startY;
        int space;
        int rows;
        int cols;
        int size;
        IEnemyBuilder enemyBuilder;

        public EnemySpawner(int startX, int startY, int space, int rows, int cols, int size, IEnemyBuilder enemyBuilder)
        {
            this.rows = rows;
            this.cols = cols;
            this.space = space;
            this.size = size;
            this.startY = startY;
            this.startX = startX;
            this.enemyBuilder = enemyBuilder;
        }

        (int middle, int leftLimit, int rightLimit) GetStartingPosition(int startX)
        {
            return (startX, startX - space, startX + space + size);
        }

        (int middle, int leftLimit, int rightLimit) AdvancePosition(int rightLimit)
        {
            return (rightLimit + space, rightLimit, rightLimit + (space * 2) + size);
        }

        public ICollection<IEntity> Spawn()
        {
            ICollection<IEntity> enemies = new List<IEntity>();
            ICollection<IObserver> enemyObservers = new List<IObserver>();
            int currentY = startY;
            (int middle, int leftLimit, int rightLimit) = GetStartingPosition(startX);

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    IEntity enemy = enemyBuilder.Build(leftLimit, rightLimit, middle, currentY);
                    enemies.Add(enemy);
                    (middle, leftLimit, rightLimit) = AdvancePosition(rightLimit);
                }
                currentY += space + size;
                (middle, leftLimit, rightLimit) = GetStartingPosition(startX);
            }

            return enemies;
        }
    }
}