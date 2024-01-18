using UnityEngine;

namespace Game.Model.Abstract
{
    public class Movable : Updatable
    {
        #region Fields

        protected Vector2 Direction;
        protected readonly float Speed;

        #endregion

        protected Movable(Vector2 position, float rotation, float speed, Vector2 direction) : base(position, rotation)
        {
            Speed = speed;
            Direction = direction;
            Rotate(Vector2.SignedAngle(Quaternion.Euler(0, 0, Rotation) * Vector3.up, Direction));
        }

        public override void Update(float deltaTime)
        {
            Position += Direction * (Speed * deltaTime);
        }
    }
}