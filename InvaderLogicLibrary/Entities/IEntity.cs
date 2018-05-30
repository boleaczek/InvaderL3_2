using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Entities
{
    public interface IEntity
    {
        IHitBox HitBox { get; set; }
        double Vx { get; set; }
        double Vy { get; set; }
        bool IsDestroyed { get; set; }

        void Update(double dt);
        void Draw(Graphics g);
    }
}
