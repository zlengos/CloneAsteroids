using Game.Model.Abstract;
using UnityEngine;

namespace Game.Model.Enemies
{
    public class UFO : Updatable
    {
        private readonly float _speed;
        private readonly Abstract.MVModel _targetMvModel;
        
        public string Name = "UFO";

        
        public UFO(Abstract.MVModel targetMvModel, Vector2 position, float speed) : base(position, 0)
        {
            _speed = speed;
            _targetMvModel = targetMvModel;
        }
        
        public override void Update(float deltaTime)
        {
            Position = Vector2.MoveTowards(Position, _targetMvModel.Position, _speed * deltaTime);
            LookAt(_targetMvModel.Position);
        }
        
        private void LookAt(Vector2 targetPosition) => Rotate(
            Vector2.SignedAngle(
            Quaternion.Euler(0, 0, Rotation) * Vector3.up,
            (Position - targetPosition)));
        //legacy formula
        //Mathf.Atan2(Mathf.Sin(Rotation * Mathf.Deg2Rad), Mathf.Cos(Rotation * Mathf.Deg2Rad)) * Mathf.Rad2Deg
    }
}