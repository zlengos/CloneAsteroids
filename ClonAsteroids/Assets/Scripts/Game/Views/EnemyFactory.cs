 using System;
 using Game.Model.Abstract;
 using Game.Model.Enemies;
 using UnityEngine;

 namespace Game.View
{
    public class EnemyFactory : ObjectsFactory<Updatable>
    {
        #region Fields

        [SerializeField] private View asteroid;
        [SerializeField] private View miniAsteroid;
        [SerializeField] private View ufo;

        #endregion

        protected override View GetView(Updatable model)
        {
            return model switch
            {
                MiniAsteroid => miniAsteroid,
                Asteroid => asteroid,
                UFO => ufo,
                _ => throw new InvalidOperationException()
            };
        }

    }
}