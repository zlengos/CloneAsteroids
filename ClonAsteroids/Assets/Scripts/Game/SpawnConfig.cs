using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(order = 51, fileName = "SO_SpawnTimeSettings", menuName = "Asteroids/SpawnTimeConfig")]
    public class SpawnConfig : ScriptableObject
    {
        public List<EnemyObject> playableObjects = new();

        public float GetTimeByName(string nameObject)
        {
            return playableObjects.Find(x => x.Name == nameObject && x.IsSpawned == false)?.TimeSinceStart ?? 0f;
        }

        [Serializable]
        public class EnemyObject
        {
            [Header("Speed Settings")] 
            [SerializeField] private string name;

            [SerializeField] private float time;

            [SerializeField] private bool isSpawned;

            public string Name => name;
            public float TimeSinceStart => time;
            public bool IsSpawned => isSpawned;

            public void SetSpawned(bool toggle) => isSpawned = toggle;
        }
    }
}