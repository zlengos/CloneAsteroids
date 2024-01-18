using System;
using Game.Model.Abstract;
using Game.View;
using UnityEngine;

namespace Game.Views
{
    public class ProjectileFactory : ObjectsFactory<Projectile>
    {
        #region Fields
        
        [SerializeField] private View.View bulletProjectile;
        [SerializeField] private View.View laserProjectile;
        
        #endregion

        public override void Spawn(ViewEntity entity)
        {
            base.Spawn(entity);
            
            if (entity.Entity is Projectile projectile)
                Destroy(TempView.gameObject, projectile.Lifetime);
        }

        protected override View.View GetView(Projectile model)
        {
            return model.Name switch
            {
                "laser" => laserProjectile,
                "bullet" => bulletProjectile,
                _ => throw new InvalidOperationException()
            };
        }


    }
}