using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    class Flyweight
    {
        public ICollection<IFlyweight> GameObjects { get; set; }

        public void Update()
        {
            foreach (var gameObject in GameObjects)
            {
                gameObject.UpdateStatus();
            }
        }
    }
}
