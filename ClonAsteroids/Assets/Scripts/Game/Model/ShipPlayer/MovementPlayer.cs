using UnityEngine;

namespace Game.Model.ShipPlayer
{
    public class MovementPlayer
    {
        #region Fields
        
        private readonly Ship _ship;
        private const float Angles = 180;

        public Vector2 Front => Quaternion.Euler(0, 0, _ship.Rotation) * Vector3.up;

        #endregion
        
        public MovementPlayer(Ship ship)
        {
            _ship = ship;
        }

        public void Move(Vector2 delta) 
            => _ship.MoveLooped(delta);

        public void Rotate(float direction, float deltaTime) 
        {
            direction = direction > 0 ? 1 : -1;

            _ship.Rotate(direction * deltaTime * Angles);
        }
    }
}