using System;
using System.Numerics;
using Game.Model.Abstract;
using Vector2 = UnityEngine.Vector2;

namespace Game.Model.Guns
{
    public class LaserGun : Gun
    {
        public LaserGun(int bullets = 10, int bulletsPerShot = 1, float gunCooldownTime = 1.5f)
        {
            if (bulletsPerShot < 0)
                throw new ArgumentOutOfRangeException(nameof(bulletsPerShot));

            if (bullets <= 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));

            Bullets = bullets;
            MaxBullets = bullets;
            BulletsPerShot = bulletsPerShot;

            GunCooldownTime = gunCooldownTime;
        }

        public override void Shoot(Vector2 position, Vector2 direction)
        {
            base.Shoot(position, direction);
            Projectile = new Projectile(position, direction, 0.001f, .5f, "laser");

        }
    }
}