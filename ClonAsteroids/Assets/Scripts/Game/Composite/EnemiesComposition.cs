using System.Collections.Generic;
using Game.Model;
using Game.Model.Abstract;
using Game.Model.Enemies;
using Game.Views;
using UnityEngine;

namespace Game.Composite
{
    public class EnemiesComposition : CompositeRoot
    {
        #region Fields

        [SerializeField] private SpeedConfig speedConfig;
        [SerializeField] private SpawnConfig spawnConfig;
        [SerializeField] private Views.View player;
        
        [SerializeField] private Views.View asteroid, miniAsteroid, ufo;

        private readonly List<ObjectsFactory<Updatable>.ViewEntity> _listOfEnemies = new();

        private EnemyFactory _enemyFactory;
        private EnemySpawner _enemySpawner = null;

        #endregion

        private void OnEnable()
        {
            _enemyFactory.OnSpawned += AddNewView;
            
            CollisionChecker.OnAsteroidDestroyed += SpawnAsteroidParts;
            
            CollisionChecker.OnKillView += _enemyFactory.Destroy;
        }

        private void SpawnAsteroidParts(Asteroid asteroid)
        {
            if (asteroid.CountOfParts <= 0) 
                return;
            
            for (int i = 0; i < asteroid.CountOfParts; i++)
                _enemySpawner.SpawnMiniAsteroid(asteroid.CreatePart());
        }

        private void OnDisable()
        {
            _enemyFactory.OnSpawned -= AddNewView;

            CollisionChecker.OnAsteroidDestroyed -= SpawnAsteroidParts;
            
            CollisionChecker.OnKillView += _enemyFactory.Destroy;

            ClearSpawned();
        }

        private void AddNewView(ObjectsFactory<Updatable>.ViewEntity viewEntity, Views.View view) =>
            _listOfEnemies.Add(viewEntity);

        public override void Compose()
        {
            _enemyFactory = new EnemyFactory();
            
            _enemySpawner = new EnemySpawner(speedConfig, spawnConfig, _enemyFactory, player);

            _enemyFactory.InitializeViews(asteroid, miniAsteroid, ufo);
        }

        private void Update()
        {
            _enemySpawner.Update(Time.deltaTime);

            foreach (var enemy in _listOfEnemies)
                enemy.Entity.Update(Time.deltaTime);
        }

        private void ClearSpawned()
        {
            foreach (var spawnedObject in spawnConfig.playableObjects)
                spawnedObject.SetSpawned(false);
        }
    }
}