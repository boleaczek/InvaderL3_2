using InvaderLogicLibrary.Entities.Bullets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Observer
{
    public interface IObserver
    {
        void Notify(IBullet bullet);
    }
}
