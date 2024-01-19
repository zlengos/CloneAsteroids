using System;
using Game.Model.Abstract;
using Game.Model.Enemies;
using Game.Views;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Model
{
    public class EnemySpawner
    {
        #region Fields

        private readonly SpeedConfig _speedConfig;
        private readonly SpawnConfig _spawnConfig;
        private readonly EnemyFactory _enemyFactory;
        private readonly Views.View _player;

        private float _elapsedTime;
        
        #endregion
        
        public EnemySpawner(SpeedConfig speedConfig, SpawnConfig spawnConfig, EnemyFactory enemyFactory, Views.View playerModel)
        {
            _speedConfig = speedConfig;
            _spawnConfig = spawnConfig;
            _enemyFactory = enemyFactory;
            _player = playerModel;
        }

        public void Update(float deltaTime)
        {
            _elapsedTime += deltaTime;

            foreach (var enemyObject in _spawnConfig.playableObjects)
            {
                var spawnTime = _spawnConfig.GetTimeByName(enemyObject.Name);

                if (_elapsedTime >= spawnTime && !enemyObject.IsSpawned)
                {
                    SpawnEnemy();
                    enemyObject.SetSpawned(true);
                }
            }
        }

        private void SpawnEnemy()
        {
            var randomPosition = GetRandomPositionOutsideScreen();
            var randomEnemy = GetRandomEnemy(_speedConfig, randomPosition, GetDirectionToScreen(randomPosition));
            var enemyEntity = new ObjectsFactory<Updatable>.ViewEntity(randomEnemy, randomEnemy);
            _enemyFactory.Spawn(enemyEntity);
        }

        private static Vector2 GetDirectionToScreen(Vector2 startPosition)
        {
            return (new Vector2(Random.value, Random.value) - startPosition).normalized;
        }

        private static Vector2 GetRandomPositionOutsideScreen()
        {
            return Random.insideUnitCircle.normalized + new Vector2(0.5f, 0.5f);
        }

        private Updatable GetRandomEnemy(SpeedConfig speedConfig, Vector2 position, Vector2 direction)
        {
            var random = Random.Range(0, 2);
            switch (random)
            {
                case 0:
                    var asteroid = new Asteroid(position, direction, speedConfig.GetSpeedByName("Asteroid"), 4);
                    return asteroid;
                case 1:
                    var ufo = new UFO(_player.Model, direction, speedConfig.GetSpeedByName("UFO"));
                    return ufo;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SpawnMiniAsteroid(MiniAsteroid miniAsteroid)
        {
            var enemyEntity = new ObjectsFactory<Updatable>.ViewEntity(miniAsteroid, miniAsteroid);
            _enemyFactory.Spawn(enemyEntity);
        }
    }
}
