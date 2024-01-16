using Game.Model.Abstract;
using UnityEngine;

namespace Game.View
{
    public class View : MonoBehaviour
    {
        public MVModel Model;
        private Camera _camera;

        private void Awake() => _camera = Camera.main;

        public void Initialize(MVModel model) => Model = model;
        
        private void FixedUpdate()
        {
            transform.position = _camera.ViewportToWorldPoint(new Vector3(Model.Position.x, Model.Position.y, 10));
            transform.rotation = Quaternion.Euler(0,0,Model.Rotation);
        }
    }
}