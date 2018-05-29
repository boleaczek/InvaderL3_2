using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using InvaderLogicLibrary;
using InvaderLogicLibrary.GameStates;

namespace InvaderGame
{
    public partial class Game : Form
    {
        Rectangle screen;
        GameStateManager stateManager;
        KeyboardInput input;

        public Game()
        {
            InitializeComponent();

            input = new KeyboardInput();
            IGameState state = new InGameState(input);
            screen = new Rectangle(0, 0, 800, 600);
            stateManager = new GameStateManager(state);
        }

        // aktualizacja gry
        private void timer1_Tick(object sender, EventArgs e)
        {
            double dt = 1.0 / 60.0;

            // aktualizacja stanu
            stateManager.Update(dt);

            // aktualizacja labela
            coin_label.Text = String.Format("Delta czas: {0}", dt);

            // przerysowanie ekranu gry
            canvas.Refresh();
        }

        // rysowanie gry
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // wyczyszczenie ekranu
            g.FillRectangle(Brushes.White, screen);

            // rysowanie stanu
            stateManager.Draw(g);
        }

        // zdarzenie wciśnięcia klawisza
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                input.Update("Left", true);

            if (e.KeyCode == Keys.Right)
                input.Update("Right", true);

            if (e.KeyCode == Keys.Up)
                input.Update("Up", true);

            if (e.KeyCode == Keys.Down)
                input.Update("Down", true);

            if (e.KeyCode == Keys.Space)
                input.Update("Space", true);
        }

        // zdarzenie zwolnienia klawisza
        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                input.Update("Left", false);

            if (e.KeyCode == Keys.Right)
                input.Update("Right", false);

            if (e.KeyCode == Keys.Up)
                input.Update("Up", false);

            if (e.KeyCode == Keys.Down)
                input.Update("Down", false);

            if (e.KeyCode == Keys.Space)
                input.Update("Space", false);
        }


    }
}
