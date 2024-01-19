using UnityEngine;

namespace Game.Model.Abstract
{
    public class Gun
    {
        #region Fields
        
        protected int MaxBullets;
        protected int BulletsPerShot;
        
        public int Bullets { get; protected set; }
        public float CooldownTime { get; private set; }
        public float GunCooldownTime { get; protected set; }
        public Projectile Projectile  { get; protected set; }
        
        #endregion

        public bool CanShoot() => Bullets >= BulletsPerShot;

        public virtual void Shoot(Vector2 position, Vector2 direction)
        {
            if (CanShoot())
                Bullets -= BulletsPerShot;
        }

        private void TryAddBullet()
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

            if (!(CooldownTime >= GunCooldownTime)) 
                return;
            
            TryAddBullet();
            CooldownTime = 0;
        }

    }
}