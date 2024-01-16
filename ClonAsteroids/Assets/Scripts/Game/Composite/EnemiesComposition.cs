using System;
using System.Collections.Generic;
using Game.Model;
using Game.Model.Abstract;
using Game.View;
using UnityEngine;

namespace Game.Composite
{
    public class EnemiesComposition : CompositeRoot
    {
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private ShipComposition _ship;
        [SerializeField] private SpeedConfig _speedConfig;
        [SerializeField] private SpawnConfig _spawnConfig;
        
        [SerializeField] private View.View player;

        private List<ObjectsFactory<Updatable>.ViewEntity> _listOfEnemies = new();

        
        private EnemySpawner _spawner = null;


        private void OnEnable()
        {
            _enemyFactory.OnSpawned += AddNewView;        
        }
        private void OnDisable()
        {
            _enemyFactory.OnSpawned -= AddNewView;        
        }

        private void AddNewView(ObjectsFactory<Updatable>.ViewEntity arg1, View.View arg2)
        {
            _listOfEnemies.Add(arg1);
        }

        public override void Compose()
        {
            _spawner = new EnemySpawner(_speedConfig, _spawnConfig, _enemyFactory, player);
        }

        private void LateUpdate()
        {
            _spawner.Update(Time.deltaTime);
            
            foreach (var bullet in _listOfEnemies)
            {
                bullet.Entity.Update(Time.deltaTime);
            }
        }
    }
}