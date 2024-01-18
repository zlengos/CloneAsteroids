using System;
using Game.Model;
using Game.Model.Abstract;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.View
{
    public abstract class ObjectsFactory<T> : MonoBehaviour
    {
        #region Fields

        protected View TempView;
        public Action<ViewEntity, View> OnSpawned;
        private const int CoordinateFromCenter = 20;

        #endregion

        #region Listening

        private void OnEnable() => CollisionChecker.OnKillView += Destroy;

        private void OnDisable() => CollisionChecker.OnKillView -= Destroy;

        #endregion

        public virtual void Spawn(ViewEntity entity)
        {
            var debugSpawnPos = GetSpawnPosition(entity);
            TempView = Instantiate(GetView(entity.Entity), debugSpawnPos, Quaternion.identity);
            TempView.Model = entity.Model;

            OnSpawned?.Invoke(entity, TempView);
        }

        private void Destroy(View view) => Destroy(view.gameObject);

        protected abstract View GetView(T model);

        private Vector2 GetSpawnPosition(ViewEntity entity)
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