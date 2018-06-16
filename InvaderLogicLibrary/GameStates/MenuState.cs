using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.GameStates
{
    public class MenuState : IInfoDisplayState
    {
        public string Score { get; set; }

        public IGameStateManager StateManager { get; set; }
        public IKeyboardInput Input;
        public IGameState NextState { get; set; }
        public string Message { get; set; }

        ITextDisplay promptDisplay;
        ITextDisplay logoDisplay;
        ITextDisplay messageDisplay;

        public MenuState()
        {
            Score = "";
        }

        public void OnDraw(Graphics g)
        {
            logoDisplay.PrintText(g, 800, 150);
            promptDisplay.PrintText(g, 800, 450);
            messageDisplay.PrintText(g, 800, 650);

        }

        public void OnLoad()
        {
            Brush brush = new SolidBrush(Color.White);
            promptDisplay = new TextDisplay();
            promptDisplay.Font = new Font("Verdana", 48);
            promptDisplay.Brush = brush;
            promptDisplay.Text = "INVADER";

            logoDisplay = new TextDisplay();
            logoDisplay.Font = new Font("Verdana", 26);
            logoDisplay.Brush = brush;
            logoDisplay.Text = "Press [spacebar] to start!";

            messageDisplay = new TextDisplay();
            messageDisplay.Font = new Font("Verdana", 26);
            messageDisplay.Brush = brush;
            messageDisplay.Text = Message;
        }

        public void OnUnload()
        {
            
        }

        public void OnUpdate(double dt)
        {
            if (Input.IsPressed("Space"))
            {
                StateManager.SetState(NextState);
            }
        }
    }
}
