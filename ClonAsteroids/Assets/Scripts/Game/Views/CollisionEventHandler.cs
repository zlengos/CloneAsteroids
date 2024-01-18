using Game.Model;
using UnityEngine;

namespace Game.Views
{
    public class CollisionEventHandler : MonoBehaviour
    {
        #region Fields

        [SerializeField] private View.View view;
        
        #endregion

        private void OnCollisionEnter2D(Collision2D other) => 
            CollisionChecker.HandleCollision(view, other.gameObject.GetComponent<View.View>());
    }
}