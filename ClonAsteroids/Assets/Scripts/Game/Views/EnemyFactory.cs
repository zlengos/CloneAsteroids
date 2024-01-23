using System;
using Game.Model.Abstract;
using Game.Model.Enemies;

namespace Game.Views
{
    public class EnemyFactory : ObjectsFactory<Updatable>
    {
        #region Fields

        private View _asteroid, _miniAsteroid, _ufo;

        #endregion

        public void InitializeViews(View asteroidView, View miniAsteroidView, View ufoView)
        {
            _asteroid = asteroidView;
            _miniAsteroid = miniAsteroidView;
            _ufo = ufoView;
        }

        protected override View GetView(Updatable model)
        {
            return model switch
            {
                MiniAsteroid => _miniAsteroid,
                Asteroid => _asteroid,
                UFO => _ufo,
                _ => throw new InvalidOperationException()
            };
        }

    }
}