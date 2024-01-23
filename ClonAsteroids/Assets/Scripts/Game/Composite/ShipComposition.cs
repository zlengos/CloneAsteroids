using System.Collections.Generic;
using Game.Input;
using Game.Model;
using Game.Model.Abstract;
using Game.Model.Guns;
using Game.Model.ShipPlayer;
using Game.Views;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Composite
{
    public class ShipComposition : CompositeRoot
    {
        #region Fields

        [SerializeField] private Views.View ship;
        [SerializeField] private GameEndUI gameEndUI;
        
        [SerializeField] private Views.View bulletProjectile, laserProjectile;

        private ShipInputController _shipInputController;
        private MovementPlayer _movementPlayer;
        private BulletGun _bulletGun;
        private ProjectileFactory _projectileFactory;
        
        private readonly List<ObjectsFactory<Projectile>.ViewEntity> _listOfBullets = new();

        private int GameScore { get; set; }
        public Ship Model { get; private set; }

        public float Speed => _shipInputController.Speed;
        public LaserGun LaserGun { get; private set; }

        #endregion

        public override void Compose()
        {
            _bulletGun = new BulletGun();
            LaserGun = new LaserGun();
            
            _projectileFactory = new ProjectileFactory();
            _projectileFactory.InitializeViews(bulletProjectile, laserProjectile);

            Model = new Ship(new Vector2(0.5f, 0.5f), 0);
            ship.Initialize(Model);
            
            _movementPlayer = new MovementPlayer(Model);
            _shipInputController = new ShipInputController(_movementPlayer, Model)
                .BindGunToFirstSlot(_bulletGun)
                .BindGunToSecondSlot(LaserGun);
        }

        private void DisableShip()
        {
            _shipInputController.OnDisable();

            gameEndUI.ShowEndGame(GameScore);
        }

        private void AddScore() 
            => GameScore++;

        private void OnEnable()
        {
            _shipInputController.OnEnable();

            _shipInputController.OnShoot += OnShot;
            

            _projectileFactory.OnSpawned += AddNewView;

            CollisionChecker.GameEnd += DisableShip;

            CollisionChecker.OnScoreIncrease += AddScore;
        }

        private void OnDisable()
        {
            _shipInputController.OnDisable();

            _shipInputController.OnShoot -= OnShot;
            
            _projectileFactory.OnSpawned -= AddNewView;
            
            CollisionChecker.GameEnd -= DisableShip;
            
            CollisionChecker.OnScoreIncrease -= AddScore;
        }

        private void Update()
        {
            _shipInputController.Update();

            LaserGun.Update(Time.deltaTime);
            
            foreach (var bullet in _listOfBullets)
                bullet.Entity.Update(Time.deltaTime);
        }

        private void OnShot(Gun gun)
        {
            gun.Shoot(Model.Position, _movementPlayer.Front);

            ObjectsFactory<Projectile>.ViewEntity projectile = new(gun.Projectile, gun.Projectile);
            _projectileFactory.Spawn(projectile);
        }

        private void AddNewView(ObjectsFactory<Projectile>.ViewEntity viewEntity, Views.View view)
            => _listOfBullets.Add(viewEntity);
    }
}