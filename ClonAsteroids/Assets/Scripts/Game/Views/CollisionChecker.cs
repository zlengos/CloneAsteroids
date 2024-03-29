using System;
using Game.Model.Abstract;
using Game.Model.Enemies;
using Game.Model.ShipPlayer;

namespace Game.Views
{
    public static class CollisionChecker
    {
        public static event Action GameEnd;
        public static event Action<View> OnKillView;
        public static event Action OnScoreIncrease;
        public static event Action<Asteroid> OnAsteroidDestroyed;

        private static void EndGame() => GameEnd?.Invoke();
        private static void DestroyView(View view) => OnKillView?.Invoke(view);
        private static void IncreaseScore() => OnScoreIncrease?.Invoke();

        private static void DestroyAsteroid(Asteroid asteroid, bool destroyedByLaser)
        {
            if(!destroyedByLaser)
                OnAsteroidDestroyed?.Invoke(asteroid);
        }

        public static void HandleCollision(View view1, View view2)
        {
            ProcessCollision(view1, view2);
            ProcessCollision(view2, view1);
        }

        private static void ProcessCollision(View view1, View view2)
        {
            switch (view1.Model)
            {
                case Ship _ when view2.Model is Updatable and not Projectile:
                    EndGame();
                    break;
                case Projectile { Name: "laser" } when view2.Model is not Ship:
                    HandleLaserCollision(view2);
                    break;
                case Projectile _ when view2.Model is Asteroid asteroid and not MiniAsteroid:
                    HandleAsteroidCollision(asteroid, view1, view2);
                    break;
                case Projectile _ when view2.Model is Updatable and not Projectile:
                    HandleProjectileCollision(view1, view2);
                    break;
            }
        }

        private static void HandleLaserCollision(View otherView)
        {
            if (otherView.Model is Asteroid asteroid)
            {
                DestroyAsteroid(asteroid, true);
                DestroyView(otherView);
            }
            else
                DestroyView(otherView);

            IncreaseScore();
        }

        private static void HandleAsteroidCollision(Asteroid asteroid, View view1, View view2)
        {
            DestroyAsteroid(asteroid, false);
            DestroyView(view1);
            DestroyView(view2);
            IncreaseScore();
        }

        private static void HandleProjectileCollision(View view1, View view2)
        {
            DestroyView(view1);
            DestroyView(view2);
            IncreaseScore();
        }
    }
}