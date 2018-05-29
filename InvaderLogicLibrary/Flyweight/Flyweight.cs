using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Flyweight
{
    public class Flyweight
    {
        public ICollection<IEntity> GameObjects { get; set; }

        public void Update(double dt)
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject.Update(dt);
            }
        }

        public void Draw(Graphics g)
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject.Draw(g);
            }
        }
    }
}
