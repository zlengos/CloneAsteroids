using System;
using Game.Model.Abstract;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Views
{
    public abstract class ObjectsFactory<T>
    {
        #region Fields

        protected Views.View TempView;
        public Action<ViewEntity, Views.View> OnSpawned;
        private const int CoordinateFromCenter = 20;

        #endregion

        public virtual void Spawn(ViewEntity entity)
        {
            var debugSpawnPos = GetSpawnPosition();
            TempView = UnityEngine.Object.Instantiate(GetView(entity.Entity), debugSpawnPos, Quaternion.identity);
            TempView.Model = entity.Model;

            OnSpawned?.Invoke(entity, TempView);
        }

        public void Destroy(Views.View view) => UnityEngine.Object.Destroy(view.gameObject);

        protected abstract Views.View GetView(T model);

        private Vector2 GetSpawnPosition()
        {
            return Random.insideUnitCircle.normalized + Vector2.one * CoordinateFromCenter;
        }

        public class ViewEntity
        {
            public readonly T Entity;
            public readonly MVModel Model;

            public ViewEntity(T entity, MVModel model)
            {
                Entity = entity;
                Model = model;
            }
        }
    }
}