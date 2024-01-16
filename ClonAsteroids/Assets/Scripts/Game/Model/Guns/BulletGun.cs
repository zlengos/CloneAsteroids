using System;
using Game.Model.Abstract;
using UnityEngine;

namespace Game.Model.Guns
{
    public class BulletGun : Gun
    {
        public BulletGun(int bullets = 10, int bulletsPerShot = 0, float gunCooldownTime = .3f)
        {
            if (bulletsPerShot < 0)
                throw new ArgumentOutOfRangeException(nameof(bulletsPerShot));

            if (bullets <= 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));

            Bullets = bullets;
            MaxBullets = bullets;
            BulletsPerShot = bulletsPerShot;
            // Projectile = new Projectile();

            GunCooldownTime = gunCooldownTime;
        }


        public override void Shoot(Vector2 position, Vector2 direction)
        {
            base.Shoot(position, direction);
            
            Projectile = new Projectile(position, direction, .4f, 5f, "bullet");
        }
    }
    
    
}