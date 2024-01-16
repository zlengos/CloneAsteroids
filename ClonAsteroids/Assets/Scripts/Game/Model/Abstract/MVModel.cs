using UnityEngine;

namespace Game.Model.Abstract
{
    public abstract class MVModel
    {
        private Vector2 _position;

        public Vector2 Position
        {
            get => _position;
            protected set => _position = value;
        }

        public float Rotation { get; private set; }

        public MVModel(Vector2 position, float rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public void SetPosition(Vector2 newPosition)
        {
            Position = newPosition;
        }

        public void Rotate(float delta)
        {
            Rotation = Mathf.Repeat(Rotation + delta, 360);
        }
    }
}