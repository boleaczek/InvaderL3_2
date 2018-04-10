using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Flyweight
{
    class Flyweight
    {
        public ICollection<IEntity> GameObjects { get; set; }

        public void Update(double dt)
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject.Update(dt);
            }
        }
    }
}
