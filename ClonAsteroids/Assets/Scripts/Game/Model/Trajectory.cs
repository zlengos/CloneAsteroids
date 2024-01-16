using System;
using UnityEngine;

namespace Game.Model
{
    public class Trajectory
    {
        public float Speed { get; }
        public Vector2 StartPosition { get; }
        public Vector2 Direction { get; }

        private readonly Func<Trajectory, float> _currentTime;

        public Vector2 Position
        {
            get
            {
                float currentTime = _currentTime.Invoke(this);
                return StartPosition + (Direction * Speed * currentTime);
            }
        }

        public Trajectory(float speed, Vector2 startPosition, Vector2 direction, Func<Trajectory, float> currentTime)
        {
            Speed = speed;  
            StartPosition = startPosition;
            Direction = direction;
            _currentTime = currentTime;
        }
    }

}