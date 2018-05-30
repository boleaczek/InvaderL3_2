using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Observer
{
    interface IObserverSubject
    {
        ICollection<IObserver> Observers { get; set; }
        void Notify();
    }
}
