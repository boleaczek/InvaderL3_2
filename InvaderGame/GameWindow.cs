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

namespace InvaderGame
{
    public partial class Game : Form
    {
        Rectangle screen;
        PlayerInput input;

        public Game()
        {
            InitializeComponent();

            screen = new Rectangle(0, 0, 800, 600);
            input = new PlayerInput();
        }

        // aktualizacja gry
        private void timer1_Tick(object sender, EventArgs e)
        {
            double dt = 1.0 / 120.0;

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
            g.FillRectangle(Brushes.LightBlue, screen);

            // rysowanie jakiegoś prostokąta
            var rect = new Rectangle(0, 0, 120, 120);
            g.FillRectangle(Brushes.LightCyan, rect);
 
        }

        // zdarzenie wciśnięcia klawisza
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                input.update("Left", true);

            if (e.KeyCode == Keys.Right)
                input.update("Right", true);

            if (e.KeyCode == Keys.Up)
                input.update("Up", true);

            if (e.KeyCode == Keys.Down)
                input.update("Down", true);
        }

        // zdarzenie zwolnienia klawisza
        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                input.update("Left", false);

            if (e.KeyCode == Keys.Right)
                input.update("Right", false);

            if (e.KeyCode == Keys.Up)
                input.update("Up", false);

            if (e.KeyCode == Keys.Down)
                input.update("Down", false);
        }


    }
}
