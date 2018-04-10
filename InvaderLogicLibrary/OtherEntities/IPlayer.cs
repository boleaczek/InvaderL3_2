using InvaderLogicLibrary.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.OtherEntities
{
    interface IPlayer : IEntity, IObserver
    {
        void UpdatePosition();
    }
}
