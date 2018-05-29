using InvaderLogicLibrary.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    class EnemySpawner
    {
        int startX;
        int startY;
        int spaceX;
        int spaceY;
        int rows;
        int cols;
        int sizeX;
        int sizeY;

        public EnemySpawner(int startX, int startY, int spaceX, int spaceY, int rows, int cols, int sizeX, int sizeY)
        {
            this.rows = rows;
            this.cols = cols;
            this.spaceY = spaceY;
            this.spaceX = spaceX;
            this.startY = startY;
            this.startX = startX;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }

        public ICollection<IEntity> Spawn()
        {
            ICollection<IEntity> enemies = new List<IEntity>();
            int currentX = startX;
            int currentY = startY;
            //
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    int nextX = currentX + spaceX;
                    HitBox hb = new HitBox(currentX, currentY, sizeX, sizeY);
                    enemies.Add(new StandardEnemy(hb, currentX, nextX));
                    currentX = nextX + sizeX;
                }
                currentX = startX;
                currentY += spaceY + sizeY;
            }

            return enemies;
        }
    }
}
