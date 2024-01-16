using System;
using Game.Model.Abstract;
using Game.Model.Enemies;
using Game.View;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Model
{
    public class EnemySpawner
    {
        private readonly SpeedConfig _speedConfig;
        private readonly SpawnConfig _spawnConfig;
        private readonly EnemyFactory _enemyFactory;
        private readonly View.View _player;

        private float _elapsedTime = 0f;

        public EnemySpawner(SpeedConfig speedConfig, SpawnConfig spawnConfig, EnemyFactory enemyFactory, View.View playerModel)
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
                float spawnTime = _spawnConfig.GetTimeByName(enemyObject.Name);

                if (_elapsedTime >= spawnTime && !enemyObject.IsSpawned)
                {
                    SpawnEnemy();
                    enemyObject.SetSpawned();
                }
            }
        }

        private void SpawnEnemy()
        {
            var randomPosition = GetRandomPositionOutsideScreen();
            var randomEnemy = GetRandomEnemy(_speedConfig, randomPosition, GetDirectionToScreen(randomPosition));
            var enemyEntity = new ObjectsFactory<Updatable>.ViewEntity(randomEnemy, randomEnemy);
            _enemyFactory.Spawn(enemyEntity);
            // _elapsedTime = 0f;
        }

        private static Vector2 GetDirectionToScreen(Vector2 startPosition)
        {
            return (new Vector2(Random.value, Random.value) - startPosition).normalized;
        }

        private static Vector2 GetRandomPositionOutsideScreen()
        {
            return Random.insideUnitCircle.normalized + new Vector2(0.5f, 0.5f);
        }

        public Updatable GetRandomEnemy(SpeedConfig speedConfig, Vector2 position, Vector2 direction)
        {
            int random = Random.Range(0, 2);
            switch (random)
            {
                case 0:
                    Asteroid asteroid = new Asteroid(position, direction, speedConfig.GetSpeedByName("Asteroid"));
                    return asteroid;
                case 1:
                    UFO ufo = new UFO(_player.Model, direction, speedConfig.GetSpeedByName("UFO"));
                    return ufo;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
