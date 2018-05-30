using InvaderLogicLibrary.Flyweight;
using InvaderLogicLibrary.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Entities.Bullets
{
    public interface IBullet: IEntity
    {
        ICollection<IObserver> Observers { get; set; }
        void HitSignal();
        void DestroyedSignal(IObserver observer);
        void Notify();
    }
}
