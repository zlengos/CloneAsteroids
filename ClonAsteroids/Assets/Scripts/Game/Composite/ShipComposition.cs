using System.Collections.Generic;
using Game.Model.Abstract;
using Game.Model.Guns;
using Game.Model.ShipPlayer;
using Game.View;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Composite
{
    public class ShipComposition : CompositeRoot
    {
        [SerializeField] private View.View ship;
        [SerializeField] private ProjectileFactory projectileFactory;
        // [SerializeField] private Camera _camera;

        private Ship _shipModel;
        private ShipInputController _shipInputController;
        private MovementPlayer _movementPlayer;
        private BulletGun _bulletGun;
        private LaserGun _laserGun;

        private List<ObjectsFactory<Projectile>.ViewEntity> _listOfBullets = new();
        // private BulletsSimulation _bulletsSimulation;
        // private LaserGunRollback _laserGunRollback;

        public Ship Model => _shipModel;
        // public BulletsSimulation Bullets => _bulletsSimulation;
        public float Speed => _shipInputController.Speed;
        public LaserGun LaserGun => _laserGun;
        // public LaserGunRollback LaserGunRollback => _laserGunRollback;

        public override void Compose()
        {
            _bulletGun = new BulletGun();
            _laserGun = new LaserGun();

            _shipModel = new Ship(new Vector2(0.5f, 0.5f), 0);
            ship.Initialize(_shipModel);
            
            _movementPlayer = new MovementPlayer(_shipModel);
            _shipInputController = new ShipInputController(_movementPlayer, _shipModel)
                .BindGunToFirstSlot(_bulletGun)
                .BindGunToSecondSlot(_laserGun);


            // _bulletsSimulation = new BulletsSimulation();
            // _laserGunRollback = new LaserGunRollback(_laserGun, Config.LaserCooldown);
        }

        // public void DisableShip()
        // {
        //     _shipInputRouter.OnDisable();
        // }

        private void OnEnable()
        {
            _shipInputController.OnEnable();

            _shipInputController.OnShoot += OnShot;

            projectileFactory.OnSpawned += AddNewView;
            // _bulletsSimulation.Start += _bulletsViewFactory.Create;
            // _bulletsSimulation.End += _bulletsViewFactory.Destroy;
        }

        private void OnDisable()
        {
            _shipInputController.OnDisable();

            _shipInputController.OnShoot -= OnShot;
            
            projectileFactory.OnSpawned -= AddNewView;
            
            // _bulletsSimulation.Start -= _bulletsViewFactory.Create;
            // _bulletsSimulation.End -= _bulletsViewFactory.Destroy;
        }

        private void Update()
        {
            _shipInputController.Update();

            
            foreach (var bullet in _listOfBullets)
            {
                bullet.Entity.Update(Time.deltaTime);
            }
            // _bulletsSimulation.Update(Time.deltaTime);
            // _laserGunRollback.Tick(Time.deltaTime);
        }

        private void OnShot(Gun gun)
        {
            gun.Shoot(_shipModel.Position, _movementPlayer.Front);

            ObjectsFactory<Projectile>.ViewEntity projectile = new(gun.Projectile, gun.Projectile);
            projectileFactory.Spawn(projectile);
        }

        private void AddNewView(ObjectsFactory<Projectile>.ViewEntity viewEntity, View.View view)
        {
            _listOfBullets.Add(viewEntity);
        }
    }
}