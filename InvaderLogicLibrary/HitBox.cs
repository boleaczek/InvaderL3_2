using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    public class HitBox:IHitBox
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public HitBox(double x, double y, double width, double height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public bool IsHit(IHitBox hitbox)
        {
            return (this.X < hitbox.X + hitbox.Width && 
                    this.X + this.Width > hitbox.X &&
                    this.Y < hitbox.Y + hitbox.Height && 
                    this.Y + this.Height > hitbox.Y);
        }
    }
}
