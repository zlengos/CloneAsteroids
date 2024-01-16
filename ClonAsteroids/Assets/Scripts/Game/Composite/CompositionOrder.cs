using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Composite
{
    public class CompositionOrder : MonoBehaviour
    {
        [SerializeField] private List<CompositeRoot> order;

        private void Awake()
        {
            foreach (var compositionRoot in order)
            {
                compositionRoot.Compose();
                compositionRoot.enabled = true;
            }
        }
    }
}