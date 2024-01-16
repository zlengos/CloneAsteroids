using System;
using System.Collections.Generic;
using Game.Model.Guns;
using UnityEngine;

namespace Game.Model.Abstract
{
    public class Gun
    {
        protected int MaxBullets;

        public int Bullets;

        public float CooldownTime { get; protected set; }
        public float GunCooldownTime { get; protected set; }

        protected int BulletsPerShot;
        public Projectile Projectile  { get; protected set; }

        public virtual bool CanShoot() => Bullets >= BulletsPerShot;

        public virtual void Shoot(Vector2 position, Vector2 direction)
        {
            if (CanShoot())
            {
                Bullets -= BulletsPerShot;
                
            }
        }

        protected virtual void TryAddBullet()
        {
            if (Bullets + BulletsPerShot > MaxBullets)
                return;

            Bullets += BulletsPerShot;
        }

        public void Update(float deltaTime)
        {
            if (Bullets == MaxBullets)
                return;

            CooldownTime += deltaTime;

            if (CooldownTime >= GunCooldownTime)
            {
                TryAddBullet();
                CooldownTime = 0;
            }
        }

    }
}