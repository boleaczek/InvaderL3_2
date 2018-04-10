using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Enemies
{
    class StandardEnemy : IEnemy
    {
        public IHitBox hitbox { get; set; }
        bool destroyed;

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Update(double dt)
        {
            hitbox.X += 1;
        }

        public void Notify(IHitBox hitBox)
        {
            if(this.hitbox.IsHit(hitbox))
            {
                destroyed = true;
            }
        }
    }
}
