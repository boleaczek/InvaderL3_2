using InvaderLogicLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Flyweight
{
    public interface IFlyweight
    {
        ICollection<IEntity> GameObjects { get; set; }
        void Update(double dt);
        void Draw(Graphics g);
    }
}
