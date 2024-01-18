using Game.Model.Abstract;
using UnityEngine;

namespace Game.Model.Enemies
{
    public class Asteroid : Movable
    {
        public int CountOfParts { get; private set; }

        public Asteroid(Vector2 position, Vector2 direction, float speed, int countOfParts) :
            base(position, Random.Range(0f, 360f), speed, direction)
        {
            CountOfParts = countOfParts;
        }
        public MiniAsteroid CreatePart()
        {
            return new MiniAsteroid(Position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)) * Vector2.up,
                Speed / 2);
        }
    }
}