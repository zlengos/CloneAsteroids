using System.Collections.Generic;
using Game.Input;
using Game.Model;
using Game.Model.Abstract;
using Game.Model.Guns;
using Game.Model.ShipPlayer;
using Game.View;
using Game.Views;
using UnityEngine;

namespace Game.Composite
{
    public class ShipComposition : CompositeRoot
    {
        #region Fields

        [SerializeField] private View.View ship;
        [SerializeField] private ProjectileFactory projectileFactory;
        [SerializeField] private GameEndUI gameEndUI;

        private Ship _shipModel;
        private ShipInputController _shipInputController;
        private MovementPlayer _movementPlayer;
        private BulletGun _bulletGun;
        private LaserGun _laserGun;
        private int _gameScore;

        private readonly List<ObjectsFactory<Projectile>.ViewEntity> _listOfBullets = new();

        public Ship Model => _shipModel;
        public float Speed => _shipInputController.Speed;
        public LaserGun LaserGun => _laserGun;

        #endregion

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
        }

        private void DisableShip()
        {
            _shipInputController.OnDisable();

            gameEndUI.ShowEndGame(_gameScore);
        }

        private void AddScore() => _gameScore++;

        private void OnEnable()
        {
            _shipInputController.OnEnable();

            _shipInputController.OnShoot += OnShot;

            projectileFactory.OnSpawned += AddNewView;

            CollisionChecker.GameEnd += DisableShip;

            CollisionChecker.OnScoreIncrease += AddScore;
        }

        private void OnDisable()
        {
            _shipInputController.OnDisable();

            _shipInputController.OnShoot -= OnShot;
            
            projectileFactory.OnSpawned -= AddNewView;
            
            CollisionChecker.GameEnd -= DisableShip;
            
            CollisionChecker.OnScoreIncrease -= AddScore;
        }

        private void Update()
        {
            _shipInputController.Update();

            _laserGun.Update(Time.deltaTime);
            
            foreach (var bullet in _listOfBullets)
                bullet.Entity.Update(Time.deltaTime);
        }

        private void OnShot(Gun gun)
        {
            gun.Shoot(_shipModel.Position, _movementPlayer.Front);

            ObjectsFactory<Projectile>.ViewEntity projectile = new(gun.Projectile, gun.Projectile);
            projectileFactory.Spawn(projectile);
        }

        private void AddNewView(ObjectsFactory<Projectile>.ViewEntity viewEntity, View.View view) => 
            _listOfBullets.Add(viewEntity);
    }
}