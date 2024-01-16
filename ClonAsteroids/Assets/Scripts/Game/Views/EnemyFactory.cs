 using System;
 using Game.Model.Abstract;
 using Game.Model.Enemies;
 using UnityEngine;
 using Random = UnityEngine.Random;

 namespace Game.View
{
    public class EnemyFactory : ObjectsFactory<Updatable>
    {
        [SerializeField] private View asteroid;
        [SerializeField] private View miniAsteroid;
        [SerializeField] private View ufo;


        protected override View GetView(Updatable model)
        {
            switch (model)
            {
                case MiniAsteroid:
                    return miniAsteroid;
                case Asteroid:
                    return asteroid;
                case UFO:
                    return ufo;
                default:
                    throw new InvalidOperationException();
            }
        }

    }
}