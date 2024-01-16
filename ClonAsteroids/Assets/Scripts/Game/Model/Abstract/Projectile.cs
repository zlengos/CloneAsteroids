using System;
using Unity.Plastic.Newtonsoft.Json.Serialization;
using UnityEngine;

namespace Game.Model.Abstract
{
    public  class Projectile : Movable
    {
        public float Lifetime;

        public string Name; 

        public float SpawnTime;
        
        
        public Projectile(Vector2 position, Vector2 direction, float speed, float lifetime, string name) : base(position, Vector2.SignedAngle(Vector3.up, direction), speed,direction)
        {
            Lifetime = lifetime;
            SpawnTime = Time.time;
            Name = name;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            // if (Time.time - spawnTime >= Lifetime)
            // {
            //     DestroyProjectile();
            // }
        }

        // public void DestroyProjectile()
        // {
        //     
        // }
    }
}