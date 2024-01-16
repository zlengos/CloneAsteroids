using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(order = 51, fileName = "SO_SpeedSettings", menuName = "Asteroids/SpeedConfig")]
    public class SpeedConfig : ScriptableObject
    {
        public List<PlayableObject> playableObjects = new();

        public float GetSpeedByName(string nameObject)
        {
            return playableObjects.Find(x => x.Name == nameObject)?.Speed ?? 0f;
        }
        
        [Serializable]
        public class PlayableObject
        {
            [Header("Speed Settings")] 
            [SerializeField] private string name;
            [SerializeField] private float speed;

            public string Name => name;
            public float Speed => speed;
        }
    }
}