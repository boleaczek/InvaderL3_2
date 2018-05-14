﻿using InvaderLogicLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    public abstract class MovingEntity : IEntity
    {
        public IHitBox HitBox { get; set; }
        public double Vx { get; set; }
        public double Vy { get; set; }

        protected enum Direction
        {
            Left,
            Right,
            None
        }
        
        public MovingEntity(IHitBox hitbox)
        {
            HitBox = hitbox;
        }

        public void Draw(Graphics g)
        {
            var rect = new Rectangle((int)HitBox.X, (int)HitBox.Y, (int)HitBox.Width, (int)HitBox.Height);
            g.FillRectangle(Brushes.LightCyan, rect);
        }

        public void Update(double dt)
        {
            Direction direction = DetermineDirection();
            if (direction == Direction.Left)
            {
                HitBox.X -= Vx * dt;
            }
            else if (direction == Direction.Right)
            {
                HitBox.X += Vx * dt;
            }

            if (HitBox.X < 0)
                HitBox.X = 0;

            if (HitBox.X + HitBox.Width > 800)
                HitBox.X = 800 - HitBox.Width;
        }

        protected abstract Direction DetermineDirection();
    }
}