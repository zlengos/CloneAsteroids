using Game.Model.Abstract;
using UnityEngine;

namespace Game.Views
{
    public class View : MonoBehaviour
    {
        #region Fields

        public MVModel Model;
        private Camera _camera;

        #endregion
        
        private void Awake() => _camera = Camera.main;

        public void Initialize(MVModel model) => Model = model;
        
        private void Update()
        {
            transform.position = _camera.ViewportToWorldPoint(new Vector3(Model.Position.x, Model.Position.y, 10));
            transform.rotation = Quaternion.Euler(0,0,Model.Rotation);
        }
    }
}