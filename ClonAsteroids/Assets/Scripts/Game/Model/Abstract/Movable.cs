using UnityEngine;

namespace Game.Model.Abstract
{
    public class Movable : Updatable
    {
        #region Fields

        private readonly Vector2 _direction;
        protected readonly float Speed;

        #endregion

        protected Movable(Vector2 position, float rotation, float speed, Vector2 direction) : base(position, rotation)
        {
            Speed = speed;
            _direction = direction;
            Rotate(Vector2.SignedAngle(Quaternion.Euler(0, 0, Rotation) * Vector3.up, _direction));
        }

        public override void Update(float deltaTime) 
            => Position += _direction * (Speed * deltaTime);
    }
}