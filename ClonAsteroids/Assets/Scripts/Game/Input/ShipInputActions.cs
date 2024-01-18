//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/Game/Input/ShipInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Scripts.Game.Input
{
    public partial class @ShipInputActions: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ShipInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ShipInputActions"",
    ""maps"": [
        {
            ""name"": ""Ship"",
            ""id"": ""c86f434d-f202-48b1-b4a3-7521fd7218d2"",
            ""actions"": [
                {
                    ""name"": ""MoveForward"",
                    ""type"": ""Button"",
                    ""id"": ""fb5aa88f-9f80-49a4-b403-7dbde5757314"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""fd7ed20c-3304-407f-af40-ff5c8ee04e91"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BulletFire"",
                    ""type"": ""Button"",
                    ""id"": ""ba49cc46-3dad-4904-8800-4ba0e9bfb2ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LaserFire"",
                    ""type"": ""Button"",
                    ""id"": ""38f24735-7fec-4654-a425-26c6d9807c29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""76b5f16d-577a-4246-83fd-5869c6860803"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Direction"",
                    ""id"": ""45b8a075-9b4f-417e-9d60-8bd15be2cfbf"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""05eae4dc-286d-4db8-95b9-70605713ec7a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c3fc4253-d257-4dc1-9051-7b7e260b5cf4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ddea8bc5-88c1-4345-a6a4-bd12e9ba0fb3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BulletFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4d93439-cdf3-4d3e-a814-f8532461ffb3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LaserFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Ship
            m_Ship = asset.FindActionMap("Ship", throwIfNotFound: true);
            m_Ship_MoveForward = m_Ship.FindAction("MoveForward", throwIfNotFound: true);
            m_Ship_Rotate = m_Ship.FindAction("Rotate", throwIfNotFound: true);
            m_Ship_BulletFire = m_Ship.FindAction("BulletFire", throwIfNotFound: true);
            m_Ship_LaserFire = m_Ship.FindAction("LaserFire", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Ship
        private readonly InputActionMap m_Ship;
        private List<IShipActions> m_ShipActionsCallbackInterfaces = new List<IShipActions>();
        private readonly InputAction m_Ship_MoveForward;
        private readonly InputAction m_Ship_Rotate;
        private readonly InputAction m_Ship_BulletFire;
        private readonly InputAction m_Ship_LaserFire;
        public struct ShipActions
        {
            private @ShipInputActions m_Wrapper;
            public ShipActions(@ShipInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveForward => m_Wrapper.m_Ship_MoveForward;
            public InputAction @Rotate => m_Wrapper.m_Ship_Rotate;
            public InputAction @BulletFire => m_Wrapper.m_Ship_BulletFire;
            public InputAction @LaserFire => m_Wrapper.m_Ship_LaserFire;
            public InputActionMap Get() { return m_Wrapper.m_Ship; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ShipActions set) { return set.Get(); }
            public void AddCallbacks(IShipActions instance)
            {
                if (instance == null || m_Wrapper.m_ShipActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_ShipActionsCallbackInterfaces.Add(instance);
                @MoveForward.started += instance.OnMoveForward;
                @MoveForward.performed += instance.OnMoveForward;
                @MoveForward.canceled += instance.OnMoveForward;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @BulletFire.started += instance.OnBulletFire;
                @BulletFire.performed += instance.OnBulletFire;
                @BulletFire.canceled += instance.OnBulletFire;
                @LaserFire.started += instance.OnLaserFire;
                @LaserFire.performed += instance.OnLaserFire;
                @LaserFire.canceled += instance.OnLaserFire;
            }

            private void UnregisterCallbacks(IShipActions instance)
            {
                @MoveForward.started -= instance.OnMoveForward;
                @MoveForward.performed -= instance.OnMoveForward;
                @MoveForward.canceled -= instance.OnMoveForward;
                @Rotate.started -= instance.OnRotate;
                @Rotate.performed -= instance.OnRotate;
                @Rotate.canceled -= instance.OnRotate;
                @BulletFire.started -= instance.OnBulletFire;
                @BulletFire.performed -= instance.OnBulletFire;
                @BulletFire.canceled -= instance.OnBulletFire;
                @LaserFire.started -= instance.OnLaserFire;
                @LaserFire.performed -= instance.OnLaserFire;
                @LaserFire.canceled -= instance.OnLaserFire;
            }

            public void RemoveCallbacks(IShipActions instance)
            {
                if (m_Wrapper.m_ShipActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IShipActions instance)
            {
                foreach (var item in m_Wrapper.m_ShipActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_ShipActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public ShipActions @Ship => new ShipActions(this);
        public interface IShipActions
        {
            void OnMoveForward(InputAction.CallbackContext context);
            void OnRotate(InputAction.CallbackContext context);
            void OnBulletFire(InputAction.CallbackContext context);
            void OnLaserFire(InputAction.CallbackContext context);
        }
    }
}