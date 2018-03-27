using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    public class HitBox:IHitBox
    {
        int X;
        int Y;
        int Width;
        int Height;

        public HitBox()
        {
            this.X = 0;
            this.Y = 0;
            this.Width = 0;
            this.Height = 0;
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
