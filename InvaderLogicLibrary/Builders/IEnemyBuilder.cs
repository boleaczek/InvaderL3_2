using InvaderLogicLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Builders
{
    public interface IEnemyBuilder
    {
        IEntity Build(int leftLimit, int rightLimit, int posX, int posY);
    }
}
