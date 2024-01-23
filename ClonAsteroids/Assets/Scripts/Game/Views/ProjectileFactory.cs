using System;
using Game.Model.Abstract;
using UnityEngine;

namespace Game.Views
{
    public class ProjectileFactory : ObjectsFactory<Projectile>
    {
        #region Fields
        
        private View _bulletProjectile, _laserProjectile;
        
        #endregion

        public override void Spawn(ViewEntity entity)
        {
            base.Spawn(entity);
            
            if (entity.Entity is Projectile projectile)
                UnityEngine.Object.Destroy(TempView.gameObject, projectile.Lifetime);
        }

        public void InitializeViews(View bulletProjectileView, View laserProjectileView)
        {
            _bulletProjectile = bulletProjectileView;
            _laserProjectile = laserProjectileView;
        }

        protected override View GetView(Projectile model)
        {
            return model.Name switch
            {
                "laser" => _laserProjectile,
                "bullet" => _bulletProjectile,
                _ => throw new InvalidOperationException()
            };
        }
    }
}