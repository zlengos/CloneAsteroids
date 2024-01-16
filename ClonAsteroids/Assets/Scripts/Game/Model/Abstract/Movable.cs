using UnityEngine;

namespace Game.Model.Abstract
{
    public class Movable : Updatable
    {
        protected Vector2 Direction;
        protected readonly float Speed;

        public Movable(Vector2 position, float rotation, float speed, Vector2 direction) : base(position, rotation)
        {
            Speed = speed;
            Direction = direction;
        }

        public override void Update(float deltaTime) => Position += Direction * (Speed * deltaTime);
    }
}