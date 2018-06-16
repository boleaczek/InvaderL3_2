using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvaderLogicLibrary.Entities;
using InvaderLogicLibrary.Entities.Enemies;
using InvaderLogicLibrary.Flyweight;
using InvaderLogicLibrary.Observer;

namespace InvaderLogicLibrary.Builders
{
    public class StandardEnemyBuilder : IEnemyBuilder
    {
        IHitBoxBuilder _hitBoxBuilder;
        ICollection<IObserver> _enemies;
        IFlyweight _flyweight;
        IGameStatusObserver _playerStatusManager;

        public StandardEnemyBuilder(IHitBoxBuilder hitBoxBuilder, ICollection<IObserver> enemies, IFlyweight flyweight, IGameStatusObserver playerStatusManager)
        {
            _hitBoxBuilder = hitBoxBuilder;
            _enemies = enemies;
            _flyweight = flyweight;
            _playerStatusManager = playerStatusManager;
        }

        public IEntity Build(int leftLimit, int rightLimit, int posX, int posY)
        {
            return new StandardEnemy(_hitBoxBuilder.Build(posX, posY), leftLimit, rightLimit, _flyweight, _enemies, _playerStatusManager);
        }
    }
}
