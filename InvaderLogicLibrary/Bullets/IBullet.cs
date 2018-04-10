using InvaderLogicLibrary.Flyweight;
using InvaderLogicLibrary.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    interface IBullet: IEntity, IObserverSubject
    {
    }
}
