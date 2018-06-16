using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Builders
{
    public class HitboxBuilder : IHitBoxBuilder
    {
        double _width;
        double _height;

        public HitboxBuilder(double width, double height)
        {
            _width = width;
            _height = height;
        }

        public IHitBox Build(int x, int y)
        {
            return new HitBox(x, y, _width, _height);
        }
    }
}
