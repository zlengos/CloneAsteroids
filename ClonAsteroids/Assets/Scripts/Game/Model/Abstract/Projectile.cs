using UnityEngine;

namespace Game.Model.Abstract
{
    public  class Projectile : Movable
    {
        #region Fields

        public readonly float Lifetime;

        public readonly string Name; 
        
        #endregion
        
        public Projectile(Vector2 position, Vector2 direction, float speed, float lifetime, string name) : base(position, Vector2.SignedAngle(Vector3.up, direction), speed,direction)
        {
            Lifetime = lifetime;
            Name = name;
        }
    }
}