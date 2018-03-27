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
        public int Width { get; set; }
        public int Height { get; set; }

        public HitBox(int x, int y, int width, int height)
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
