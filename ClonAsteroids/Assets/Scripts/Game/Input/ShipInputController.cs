using System;
using Game.Model;
using Game.Model.Abstract;
using Game.Model.ShipPlayer;
using Scripts.Game.Input;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipInputController
{
    private readonly ShipInputActions _input;
    private Inertia _inertia;
    private MovementPlayer _movement;

    private MVModel _ship;

    private Gun _firstGunSlot, _secondGunSlot;
    
    public event Action<Gun> OnShoot;


    public float Speed => _inertia.Acceleration.magnitude;

    public ShipInputController(MovementPlayer shipMovement, MVModel ship)
    {
        _input = new ShipInputActions();
        _inertia = new Inertia();
        _movement = shipMovement;
        _ship = ship;
    }

    public void OnEnable()
    {
        _input.Enable();
        _input.Ship.BulletFire.performed += OnFirstSlootShoot;
        _input.Ship.LaserFire.performed += OnSecondSlootShoot;
    }

    public void OnDisable()
    {
        _input.Disable();
        _input.Ship.BulletFire.performed -= OnFirstSlootShoot;
        _input.Ship.LaserFire.performed -= OnSecondSlootShoot;
    }

    public void Update()
    {
        if (MoveForwardPerformed())
            _inertia.Accelerate(_movement.Front, Time.deltaTime);
        else
            _inertia.Slowdown(Time.deltaTime);

        _movement.Move(_inertia.Acceleration);
        TryRotate();
    }

    public ShipInputController BindGunToFirstSlot(Gun gun)
    {
        _firstGunSlot = gun;
        return this;
    }

    public ShipInputController BindGunToSecondSlot(Gun gun)
    {
        _secondGunSlot = gun;
        return this;
    }

    private bool MoveForwardPerformed()
    {
        return _input.Ship.MoveForward.phase == InputActionPhase.Performed;
    }

    private void OnFirstSlootShoot(InputAction.CallbackContext obj)
    {
        TryShoot(_firstGunSlot);
    }

    private void OnSecondSlootShoot(InputAction.CallbackContext obj)
    {
        TryShoot(_secondGunSlot);
    }

    private void TryShoot(Gun gun)
    {
        if (gun.CanShoot())
            OnShoot?.Invoke(gun);

    }

    private void TryRotate()
    {
        float direction = _input.Ship.Rotate.ReadValue<float>();

        if(direction != 0)
            _movement.Rotate(direction, Time.deltaTime);
    }
}
