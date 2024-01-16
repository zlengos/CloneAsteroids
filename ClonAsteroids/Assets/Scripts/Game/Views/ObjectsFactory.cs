using System;
using Game.Model;
using Game.Model.Abstract;
using UnityEngine;

namespace Game.View
{
    public abstract class ObjectsFactory<T> : MonoBehaviour
    {
        protected View _tempView;
        public Action<ViewEntity, View> OnSpawned;
            
        public virtual void Spawn(ViewEntity entity)
        {
            _tempView = Instantiate(GetView(entity.Entity), entity.Model.Position, Quaternion.identity);
            _tempView.Model = entity.Model;
            
            OnSpawned?.Invoke(entity, _tempView);
        }

        protected abstract View GetView(T model);
        
        public  class ViewEntity
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
