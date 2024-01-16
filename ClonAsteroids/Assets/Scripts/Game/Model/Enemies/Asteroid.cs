using Game.Model.Abstract;
using UnityEngine;

namespace Game.Model.Enemies
{
    public class Asteroid : Movable
    {
        public string Name = "Asteroid";
        
        public Asteroid(Vector2 position, Vector2 direction, float speed) : base(position, 0, speed,direction) { }

        public MiniAsteroid CreatePart()
        {
            return new MiniAsteroid(Position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)) * Vector2.up,
                Speed / 2);
        }
    }
}