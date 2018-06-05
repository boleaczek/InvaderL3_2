using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    public class HitBox:IHitBox
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public HitBox(int x, int y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public bool IsHit(IHitBox hitbox)
        {
            return (X < hitbox.X + hitbox.Width && 
                    X + Width > hitbox.X &&
                    Y < hitbox.Y + hitbox.Height && 
                    Y + Height > hitbox.Y);
        }
    }
}
