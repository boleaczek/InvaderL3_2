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
        int space;
        int rows;
        int cols;
        int size;

        public EnemySpawner(int startX, int startY, int space, int rows, int cols, int size)
        {
            this.rows = rows;
            this.cols = cols;
            this.space = space;
            this.size = size;
            this.startY = startY;
            this.startX = startX;
   
        }

        public ICollection<IEntity> Spawn()
        {
            ICollection<IEntity> enemies = new List<IEntity>();
            int currentY = startY;
            int middle = startX;
            int leftLimit = middle - space;
            int rightLimit = middle + space + size;

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    HitBox hb = new HitBox(middle, currentY, size, size);
                    StandardEnemy standardEnemy = new StandardEnemy(hb, leftLimit, rightLimit);
                    enemies.Add(standardEnemy);
                    leftLimit = rightLimit;
                    middle = leftLimit + space;
                    rightLimit = middle + space + size;
                }
                currentY += space;
            }

            return enemies;
        }
    }
}

//space:50, size:50, start: 400
//middle1 = 400, left1 = 350, right1 = 500
//middle2 = 500, left2 = 400, right2 = 600