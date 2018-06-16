using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Builders
{
    public interface IHitBoxBuilder
    {
        IHitBox Build(int x, int y);
    }
}
