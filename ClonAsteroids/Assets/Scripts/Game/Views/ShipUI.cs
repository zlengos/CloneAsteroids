using Game.Composite;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public class ShipUI : MonoBehaviour
    {
        [SerializeField] private ShipComposition ship;

        [SerializeField] private Text[] texts;
        
        private void FixedUpdate()
        {
            texts[0].text = $"Position: {ship.Model.Position}";
            texts[1].text = $"Rotation: {Mathf.RoundToInt(ship.Model.Rotation)}°";
            texts[2].text = $"Speed: {Mathf.RoundToInt(ship.Speed * 10000)}";
            texts[3].text = $"Cooldown: {Mathf.RoundToInt(ship.LaserGun.GunCooldownTime - ship.LaserGun.CooldownTime)}";
            texts[4].text = $"Lasers: {ship.LaserGun.Bullets}";
        }
    }
}
