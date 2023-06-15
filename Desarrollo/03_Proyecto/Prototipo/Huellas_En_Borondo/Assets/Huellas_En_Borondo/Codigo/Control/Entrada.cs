// GENERATED AUTOMATICALLY FROM 'Assets/Huellas_En_Borondo/Codigo/Control/Entrada.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Entrada : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Entrada()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Entrada"",
    ""maps"": [
        {
            ""name"": ""Movimiento"",
            ""id"": ""6be23d1f-32c8-4cef-8657-73d7383a06d9"",
            ""actions"": [
                {
                    ""name"": ""Pausa"",
                    ""type"": ""Button"",
                    ""id"": ""dc1d8b56-0eaa-40d0-b79e-fafbcfcca952"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Desplazamiento"",
                    ""type"": ""Value"",
                    ""id"": ""1ec3f0b6-8044-4583-8faf-91a998653ab6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Turbo"",
                    ""type"": ""Button"",
                    ""id"": ""9163a226-9058-4809-b063-e0d059516f07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Flechas"",
                    ""id"": ""1f42676d-abfc-485c-8a70-a0bf2cd49a01"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Desplazamiento"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""721cda3c-add4-4d5f-9e21-13ca5dd4568a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Desplazamiento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d17b574a-eb7f-4328-a561-9e5c560640ca"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Desplazamiento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""aa0325c0-7a49-4937-affc-91813a5dc058"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Desplazamiento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7a1737af-1b7f-4c45-ae16-84e85476a950"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Desplazamiento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""d4c0fd78-0925-4b83-b5db-01b19023399f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Desplazamiento"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4a14ec11-2d5c-49c5-8bb2-f7d9b780b178"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Desplazamiento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e536adef-85d8-4646-8878-b3b7804dbfb3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Desplazamiento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""75b716e0-da93-4ba9-8ce1-aec40c869e34"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Desplazamiento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""21bff9f9-f006-467d-97a5-d1276510b1dd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Desplazamiento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4c3c266a-15ac-4cb1-9403-7abbaad8f047"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Desplazamiento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff4e9086-7e44-478b-a850-9221afb78942"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turbo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2cb6f4cc-1438-401e-b2c0-078d4117fe0c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turbo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d66ea2ec-466b-4c0d-99df-7b7f786c314e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pausa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23c7d71c-e484-42f7-b9bb-875172e75247"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pausa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movimiento
        m_Movimiento = asset.FindActionMap("Movimiento", throwIfNotFound: true);
        m_Movimiento_Pausa = m_Movimiento.FindAction("Pausa", throwIfNotFound: true);
        m_Movimiento_Desplazamiento = m_Movimiento.FindAction("Desplazamiento", throwIfNotFound: true);
        m_Movimiento_Turbo = m_Movimiento.FindAction("Turbo", throwIfNotFound: true);
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

    // Movimiento
    private readonly InputActionMap m_Movimiento;
    private IMovimientoActions m_MovimientoActionsCallbackInterface;
    private readonly InputAction m_Movimiento_Pausa;
    private readonly InputAction m_Movimiento_Desplazamiento;
    private readonly InputAction m_Movimiento_Turbo;
    public struct MovimientoActions
    {
        private @Entrada m_Wrapper;
        public MovimientoActions(@Entrada wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pausa => m_Wrapper.m_Movimiento_Pausa;
        public InputAction @Desplazamiento => m_Wrapper.m_Movimiento_Desplazamiento;
        public InputAction @Turbo => m_Wrapper.m_Movimiento_Turbo;
        public InputActionMap Get() { return m_Wrapper.m_Movimiento; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovimientoActions set) { return set.Get(); }
        public void SetCallbacks(IMovimientoActions instance)
        {
            if (m_Wrapper.m_MovimientoActionsCallbackInterface != null)
            {
                @Pausa.started -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnPausa;
                @Pausa.performed -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnPausa;
                @Pausa.canceled -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnPausa;
                @Desplazamiento.started -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnDesplazamiento;
                @Desplazamiento.performed -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnDesplazamiento;
                @Desplazamiento.canceled -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnDesplazamiento;
                @Turbo.started -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnTurbo;
                @Turbo.performed -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnTurbo;
                @Turbo.canceled -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnTurbo;
            }
            m_Wrapper.m_MovimientoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pausa.started += instance.OnPausa;
                @Pausa.performed += instance.OnPausa;
                @Pausa.canceled += instance.OnPausa;
                @Desplazamiento.started += instance.OnDesplazamiento;
                @Desplazamiento.performed += instance.OnDesplazamiento;
                @Desplazamiento.canceled += instance.OnDesplazamiento;
                @Turbo.started += instance.OnTurbo;
                @Turbo.performed += instance.OnTurbo;
                @Turbo.canceled += instance.OnTurbo;
            }
        }
    }
    public MovimientoActions @Movimiento => new MovimientoActions(this);
    public interface IMovimientoActions
    {
        void OnPausa(InputAction.CallbackContext context);
        void OnDesplazamiento(InputAction.CallbackContext context);
        void OnTurbo(InputAction.CallbackContext context);
    }
}
