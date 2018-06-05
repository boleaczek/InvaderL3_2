﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.GameStates
{
    public class GameOverState : IGameState
    {
        private int score;
        private IKeyboardInput keyboardInput;

        private Font font;
        private Font font2;
        private Brush brush;
        private string logo;
        private string prompt;
        private SizeF logoSize;
        private SizeF promptSize;
        public GameStateManager StateManager;
        public KeyboardInput Input;
        public IGameState NextState;

        public GameOverState(IKeyboardInput keyboardInput, int score)
        {
            this.keyboardInput = keyboardInput;
            this.score = score;
        }

        public void OnDraw(Graphics g)
        {
            // narysowanie loga
            logoSize = g.MeasureString(logo, font);
            float x = 800 / 2 - (logoSize.Width / 2),
                  y = 150;

            g.DrawString(logo, font, brush, new PointF(x, y));

            // narysowanie informacji o wyniku
            promptSize = g.MeasureString(prompt, font2);
            x = 800 / 2 - (promptSize.Width / 2);
            y = 450;

            g.DrawString(prompt, font2, brush, new PointF(x, y));
        }

        public void OnLoad()
        {
            font = new Font("Verdana", 48);
            font2 = new Font("Verdana", 26);
            brush = new SolidBrush(Color.White);

            logo = "GAME OVER!";
            prompt = String.Format("Your score: {0}.\nPress [spacebar] to restart.", score);
        }

        public void OnUnload()
        {

        }

        public void OnUpdate(double dt)
        {
            if (Input.IsPressed("Space"))
            {
                Input.Update("Space", false);
                StateManager.SetState(NextState);
            }
        }
    }
}
