using UnityEngine;

namespace Game.Model.Abstract
{
    public abstract class MVModel
    {
        #region Fields

        public Vector2 Position { get; protected set; }

        public float Rotation { get; private set; }

        #endregion

        protected MVModel(Vector2 position, float rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public void SetPosition(Vector2 newPosition) 
            => Position = newPosition;

        public void Rotate(float delta) 
            => Rotation = Mathf.Repeat(Rotation + delta, 360);
    }
}