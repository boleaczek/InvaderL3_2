using InvaderLogicLibrary.Observer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    public class Player : IEntity, IObserver
    {
        private IKeyboardInput keyboardInput;

        public IHitBox HitBox { get; set; }
        public double Vx { get; set; }
        public double Vy { get; set; }

        public Player(IKeyboardInput kb, IHitBox hitbox)
        {
            keyboardInput = kb;
            HitBox = hitbox;
        }

        public void Draw(Graphics g)
        {
            var rect = new Rectangle((int)HitBox.X, (int)HitBox.Y, (int)HitBox.Width, (int)HitBox.Height);
            g.FillRectangle(Brushes.LightCyan, rect);
        }

        public void Notify(IHitBox hitBox)
        {
            throw new NotImplementedException();
        }

        public void Update(double dt)
        {
            if (keyboardInput.IsPressed("Left"))
                HitBox.X -= Vx * dt;

            if (keyboardInput.IsPressed("Right"))
                HitBox.X += Vx * dt;

            if (HitBox.X < 0)
                HitBox.X = 0;

            if (HitBox.X + HitBox.Width > 800)
                HitBox.X = 800 - HitBox.Width;
        }
    }
}
