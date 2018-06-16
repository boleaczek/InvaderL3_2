using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvaderLogicLibrary.Entities;
using InvaderLogicLibrary.Entities.Enemies;
using InvaderLogicLibrary.Observer;

namespace InvaderLogicLibrary.Builders
{
    class StandardEnemyBuilder : IEnemyBuilder
    {
        IHitBoxBuilder _hitBoxBuilder;
        ICollection<IObserver> _enemies;
        Flyweight.Flyweight _flyweight;

        public StandardEnemyBuilder(IHitBoxBuilder hitBoxBuilder, ICollection<IObserver> enemies, Flyweight.Flyweight flyweight)
        {
            _hitBoxBuilder = hitBoxBuilder;
            _enemies = enemies;
            _flyweight = flyweight;
        }

        public IEntity Build(int leftLimit, int rightLimit, int posX, int posY)
        {
            return new StandardEnemy(_hitBoxBuilder.Build(posX, posY), leftLimit, rightLimit, _flyweight, _enemies);
        }
    }
}
