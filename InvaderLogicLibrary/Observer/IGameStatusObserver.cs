﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary.Observer
{
    public interface IGameStatusObserver
    {
        void NotifyEnemyDestroyed();
        void NotifyPlayerDestroyed();
    }
}