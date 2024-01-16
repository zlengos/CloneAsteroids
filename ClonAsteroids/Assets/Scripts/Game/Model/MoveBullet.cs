// using System.Collections.Generic;
// using Game.Model.Abstract;
// using UnityEngine;
//
// namespace Game.Model
// {
//     public static class MoveBullet
//     {
//         private static float _currentTime;
//
//         public static List<MVModel> ObjectsToMove = new();
//
//         public static void Move(Vector2 direction, MVModel model, Projectile projectile)
//         {
//             if (model != null)
//             {
//                 ObjectsToMove.Add(model, direction)
//                 Vector2 newPosition = model.Position + direction.normalized * projectile.Speed * Time.deltaTime;
//
//                 newPosition.x = Mathf.Repeat(newPosition.x, 1);
//                 newPosition.y = Mathf.Repeat(newPosition.y, 1);
//
//                 model.SetPosition(newPosition);
//
//                 _currentTime += Time.deltaTime;
//                 if (_currentTime >= projectile.Lifetime)
//                 {
//                     ObjectsToMove.Remove(model);
//                 }
//             }
//         }
//     }
// }