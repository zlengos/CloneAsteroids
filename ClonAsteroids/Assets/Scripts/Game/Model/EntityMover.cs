using System.Collections.Generic;
using Game.Model.Abstract;

namespace Game.Model
{
    public class EntityMover
    {
        private List<Movable> _entities;


        public void Add(Movable entity)
        {
            _entities.Add(entity);
        }
    }
}