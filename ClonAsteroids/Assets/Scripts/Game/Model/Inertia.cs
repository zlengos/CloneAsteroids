using UnityEngine;

namespace Game.Model
{
    public class Inertia
    {
        private readonly float _unitsPerSecond = 0.001f;
        private readonly float _maxSpeed = 0.002f;
        private readonly float _secondsUnilStop = 1f;

        public Vector2 Acceleration { get; private set; }

        public void Accelerate(Vector2 forward, float deltaTime)
        {
            Acceleration += forward * (_unitsPerSecond * deltaTime);
            Acceleration = Vector2.ClampMagnitude(Acceleration, _maxSpeed);
        }

        public void Slowdown(float deltaTime)
        {
            Acceleration -= Acceleration * (deltaTime / _secondsUnilStop);
        }
    }
}