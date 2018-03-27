using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    interface IEntity
    {
        IHitBox hitbox { get; set; }
        void Update(double dt);
        void Draw();
    }
}
