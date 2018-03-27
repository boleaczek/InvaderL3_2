using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    public interface IHitBox
    {
        int X { get; set; }
        int Y { get; set; }
        int Height { get; set; }
        int Length { get; set; }

        bool IsHit(IHitBox hitbox);
    }
}
