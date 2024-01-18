using UnityEngine;

namespace Game.Model.Abstract
{
    public abstract class Updatable : MVModel
    {
        protected Updatable(Vector2 position, float rotation) : base(position, rotation) { }

        public abstract void Update(float deltaTime);
    }
}