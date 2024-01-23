using UnityEngine;

namespace Game.Model
{
    public class Inertia
    {
        #region Fields

        private const float UnitsPerSecond = 0.001f;
        private const float MaxSpeed = 0.002f;
        private const float SecondsUnilStop = 1f;

        public Vector2 Acceleration { get; private set; }

        #endregion

        public void Accelerate(Vector2 forward, float deltaTime)
        {
            Acceleration += forward * (UnitsPerSecond * deltaTime);
            Acceleration = Vector2.ClampMagnitude(Acceleration, MaxSpeed);
        }

        public void Slowdown(float deltaTime) 
            => Acceleration -= Acceleration * (deltaTime / SecondsUnilStop);
    }
}