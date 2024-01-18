using System.Collections.Generic;
using Game.Model;
using Game.Model.Abstract;
using Game.Model.Enemies;
using Game.View;
using UnityEngine;

namespace Game.Composite
{
    public class EnemiesComposition : CompositeRoot
    {
        #region Fields

        [SerializeField] private EnemyFactory enemyFactory;
        [SerializeField] private SpeedConfig speedConfig;
        [SerializeField] private SpawnConfig spawnConfig;
        [SerializeField] private View.View player;

        private readonly List<ObjectsFactory<Updatable>.ViewEntity> _listOfEnemies = new();

        private EnemySpawner _enemySpawner = null;

        #endregion

        private void OnEnable()
        {
            enemyFactory.OnSpawned += AddNewView;
            
            CollisionChecker.OnAsteroidDestroyed += SpawnAsteroidParts;
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
            enemyFactory.OnSpawned -= AddNewView;

            CollisionChecker.OnAsteroidDestroyed -= SpawnAsteroidParts;

            ClearSpawned();
        }

        private void AddNewView(ObjectsFactory<Updatable>.ViewEntity viewEntity, View.View view) =>
            _listOfEnemies.Add(viewEntity);

        public override void Compose() =>
            _enemySpawner = new EnemySpawner(speedConfig, spawnConfig, enemyFactory, player);

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