using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    interface IPlayer : IEntity, IObserver
    {
        void UpdatePosition();
    }
}
