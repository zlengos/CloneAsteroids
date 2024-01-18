using System.Collections.Generic;
using UnityEngine;

namespace Game.Composite
{
    public class CompositionOrder : MonoBehaviour
    {
        #region Fields

        [SerializeField] private List<CompositeRoot> order;

        #endregion
        
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