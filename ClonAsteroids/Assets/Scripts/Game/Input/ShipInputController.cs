using System;
using Game.Model;
using Game.Model.Abstract;
using Game.Model.ShipPlayer;
using Scripts.Game.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input
{
    public class ShipInputController
    {
        #region Fields

        private readonly ShipInputActions _input;
        private readonly Inertia _inertia;
        private readonly MovementPlayer _movement;

        private Gun _firstGun, _secondGun;
    
        public event Action<Gun> OnShoot;

        public float Speed => _inertia.Acceleration.magnitude;

        #endregion
        
        public ShipInputController(MovementPlayer shipMovement, MVModel ship)
        {
            _input = new ShipInputActions();
            
            _inertia = new Inertia();
            
            _movement = shipMovement;
        }

        public void OnEnable()
        {
            _input.Enable();
            
            _input.Ship.BulletFire.performed += OnFirstGunShoot;
            
            _input.Ship.LaserFire.performed += OnSecondGunShoot;
        }

        public void OnDisable()
        {
            _input.Disable();
            
            _input.Ship.BulletFire.performed -= OnFirstGunShoot;
            
            _input.Ship.LaserFire.performed -= OnSecondGunShoot;
        }

        public void Update()
        {
            if (MoveForwardAction())
                _inertia.Accelerate(_movement.Front, Time.deltaTime);
            else
                _inertia.Slowdown(Time.deltaTime);

            _movement.Move(_inertia.Acceleration);
            TryRotate();
        }

        public ShipInputController BindGunToFirstSlot(Gun gun)
        {
            _firstGun = gun;
            return this;
        }

        public ShipInputController BindGunToSecondSlot(Gun gun)
        {
            _secondGun = gun;
            return this;
        }

        private bool MoveForwardAction()
        {
            return _input.Ship.MoveForward.phase == InputActionPhase.Performed;
        }

        private void OnFirstGunShoot(InputAction.CallbackContext obj) => TryShoot(_firstGun);

        private void OnSecondGunShoot(InputAction.CallbackContext obj) => TryShoot(_secondGun);

        private void TryShoot(Gun gun)
        {
            if (gun.CanShoot())
                OnShoot?.Invoke(gun);
        }

        private void TryRotate()
        {
            var direction = _input.Ship.Rotate.ReadValue<float>();

            if (direction != 0)
                _movement.Rotate(direction, Time.deltaTime);
        }
    }
}
