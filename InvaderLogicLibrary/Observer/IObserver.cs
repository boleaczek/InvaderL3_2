using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Observer
{
    interface IObserver
    {
        void Notify(IHitBox hitBox);
    }
}
