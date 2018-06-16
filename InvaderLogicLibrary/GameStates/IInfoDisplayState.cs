using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.GameStates
{
    public interface IInfoDisplayState : IGameState
    {
        string Message { get; set; }
    }
}
