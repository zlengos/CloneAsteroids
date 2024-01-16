using System;
using Game.Model;
using Game.Model.Abstract;
using Game.Model.Guns;
using UnityEngine;

namespace Game.View
{
    public class ProjectileFactory : ObjectsFactory<Projectile>
    {
        [SerializeField] private View bulletProjectile;
        [SerializeField] private View laserProjectile;
        
        
        

        public override void Spawn(ViewEntity entity)
        {
            base.Spawn(entity);
            
            if (entity.Entity is Projectile projectile)
            {
                Destroy(_tempView.gameObject, projectile.Lifetime);
                
            }
        }

        protected override View GetView(Projectile model)
        {
            if (model.Name is "laser")
                return laserProjectile;

            if (model.Name is "bullet")
                return bulletProjectile;

            throw new InvalidOperationException();
        }


    }
}