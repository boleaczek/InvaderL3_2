using InvaderLogicLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Entities
{
    public abstract class MovingEntity : IEntity
    {
        public IHitBox HitBox { get; set; }
        public double Vx { get; set; }
        public double Vy { get; set; }

        public enum Direction
        {
            Left,
            Right,
            Up,
            Down,
            None
        }

        public MovingEntity(IHitBox hitbox)
        {
            HitBox = hitbox;
        }

        public void Draw(Graphics g)
        {
            var rect = new Rectangle(HitBox.X, HitBox.Y, (int)HitBox.Width, (int)HitBox.Height);
            g.FillRectangle(Brushes.LightCyan, rect);
        }

        public void Update(double dt)
        {
            Move(dt);
            HandleColision();
        }

        protected virtual void Move(double dt)
        {
            Direction direction = DetermineDirection();
            switch (direction)
            {
                case Direction.Left:
                    HitBox.X -= (int)(Vx * dt);
                    break;
                case Direction.Right:
                    HitBox.X += (int)(Vx * dt);
                    break;
                case Direction.Up:
                    HitBox.Y -= (int)(Vy * dt);
                    break;
                case Direction.Down:
                    HitBox.Y += (int)(Vy * dt);
                    break;
            }
        }

        protected abstract Direction DetermineDirection();

        protected virtual void HandleColision()
        {
            if (HitBox.X < 0)
                HitBox.X = 0;
            else if (HitBox.X + HitBox.Width > 800)
                HitBox.X = (int)(800 - HitBox.Width);
        }
    }
}