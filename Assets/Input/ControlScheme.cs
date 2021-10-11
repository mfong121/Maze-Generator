// GENERATED AUTOMATICALLY FROM 'Assets/Input/ControlScheme.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace FongMichael.Lab3.Input
{
    public class @ControlScheme : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ControlScheme()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlScheme"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""d7f3416d-893f-42ea-8a6a-0a4755ee9975"",
            ""actions"": [
                {
                    ""name"": ""ToggleRotation"",
                    ""type"": ""Button"",
                    ""id"": ""d4894bef-1eaf-4bc5-b66b-35a8b1e728d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwapCamera"",
                    ""type"": ""Button"",
                    ""id"": ""0892135e-7f79-42fb-b889-41dfbe35af24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""9abb4c28-c1c0-4bc5-a32c-3bcdfb8517d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Player"",
                    ""type"": ""Value"",
                    ""id"": ""917c58fc-9455-4f86-b389-a7fc3f3f6bf6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""fbe77cc4-c31d-4c3f-8fea-76fee12e2d21"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotatePlayerCamera"",
                    ""type"": ""Value"",
                    ""id"": ""7d59b938-da34-4130-a5d4-b1a01c193e70"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f2dada97-faa4-4c34-8498-cf4650199889"",
                    ""path"": ""<Keyboard>/0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""527bea12-f6c6-42ed-9fd7-492a20be660e"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""069166e1-f2cd-434d-bcb3-541e14089ad2"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""471cc883-e9f0-44cf-9517-42e4ceb2e848"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Player"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""c187a3e4-2d0e-4972-811e-09a6c2a6b3b4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Player"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7bce98eb-daf6-4380-b95a-c34e394c6a38"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Player"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d203acd0-6d6d-446a-aafd-eab50985d1b8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Player"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""23ce62ea-d2c4-4bd4-8226-f65b171d47fe"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Player"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8f4de7a7-58f3-4a60-b0a3-401f8d95903a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Player"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""c07c2378-73ab-4f92-a844-8359fa61742f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Player"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""66fd8766-2676-418a-a29b-0a9ffa32c397"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Player"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""caca929f-7772-409a-a215-9f1962ba7064"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Player"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3dd801c7-038b-4d32-a7f3-938766894481"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Player"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d2285d84-c698-47ad-bb65-b74f63b405d7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Player"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""616bd80f-f601-4470-bc03-14dd2c91595e"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7963f956-eb33-4cef-be1e-1a0a3410cfd9"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotatePlayerCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0084f829-7e08-4d2a-99ae-1808831d850f"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotatePlayerCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Controls
            m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
            m_Controls_ToggleRotation = m_Controls.FindAction("ToggleRotation", throwIfNotFound: true);
            m_Controls_SwapCamera = m_Controls.FindAction("SwapCamera", throwIfNotFound: true);
            m_Controls_Quit = m_Controls.FindAction("Quit", throwIfNotFound: true);
            m_Controls_MovePlayer = m_Controls.FindAction("Move Player", throwIfNotFound: true);
            m_Controls_Sprint = m_Controls.FindAction("Sprint", throwIfNotFound: true);
            m_Controls_RotatePlayerCamera = m_Controls.FindAction("RotatePlayerCamera", throwIfNotFound: true);
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

        // Controls
        private readonly InputActionMap m_Controls;
        private IControlsActions m_ControlsActionsCallbackInterface;
        private readonly InputAction m_Controls_ToggleRotation;
        private readonly InputAction m_Controls_SwapCamera;
        private readonly InputAction m_Controls_Quit;
        private readonly InputAction m_Controls_MovePlayer;
        private readonly InputAction m_Controls_Sprint;
        private readonly InputAction m_Controls_RotatePlayerCamera;
        public struct ControlsActions
        {
            private @ControlScheme m_Wrapper;
            public ControlsActions(@ControlScheme wrapper) { m_Wrapper = wrapper; }
            public InputAction @ToggleRotation => m_Wrapper.m_Controls_ToggleRotation;
            public InputAction @SwapCamera => m_Wrapper.m_Controls_SwapCamera;
            public InputAction @Quit => m_Wrapper.m_Controls_Quit;
            public InputAction @MovePlayer => m_Wrapper.m_Controls_MovePlayer;
            public InputAction @Sprint => m_Wrapper.m_Controls_Sprint;
            public InputAction @RotatePlayerCamera => m_Wrapper.m_Controls_RotatePlayerCamera;
            public InputActionMap Get() { return m_Wrapper.m_Controls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
            public void SetCallbacks(IControlsActions instance)
            {
                if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
                {
                    @ToggleRotation.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnToggleRotation;
                    @ToggleRotation.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnToggleRotation;
                    @ToggleRotation.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnToggleRotation;
                    @SwapCamera.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSwapCamera;
                    @SwapCamera.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSwapCamera;
                    @SwapCamera.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSwapCamera;
                    @Quit.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnQuit;
                    @Quit.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnQuit;
                    @Quit.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnQuit;
                    @MovePlayer.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovePlayer;
                    @MovePlayer.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovePlayer;
                    @MovePlayer.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovePlayer;
                    @Sprint.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSprint;
                    @Sprint.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSprint;
                    @Sprint.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSprint;
                    @RotatePlayerCamera.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRotatePlayerCamera;
                    @RotatePlayerCamera.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRotatePlayerCamera;
                    @RotatePlayerCamera.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRotatePlayerCamera;
                }
                m_Wrapper.m_ControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ToggleRotation.started += instance.OnToggleRotation;
                    @ToggleRotation.performed += instance.OnToggleRotation;
                    @ToggleRotation.canceled += instance.OnToggleRotation;
                    @SwapCamera.started += instance.OnSwapCamera;
                    @SwapCamera.performed += instance.OnSwapCamera;
                    @SwapCamera.canceled += instance.OnSwapCamera;
                    @Quit.started += instance.OnQuit;
                    @Quit.performed += instance.OnQuit;
                    @Quit.canceled += instance.OnQuit;
                    @MovePlayer.started += instance.OnMovePlayer;
                    @MovePlayer.performed += instance.OnMovePlayer;
                    @MovePlayer.canceled += instance.OnMovePlayer;
                    @Sprint.started += instance.OnSprint;
                    @Sprint.performed += instance.OnSprint;
                    @Sprint.canceled += instance.OnSprint;
                    @RotatePlayerCamera.started += instance.OnRotatePlayerCamera;
                    @RotatePlayerCamera.performed += instance.OnRotatePlayerCamera;
                    @RotatePlayerCamera.canceled += instance.OnRotatePlayerCamera;
                }
            }
        }
        public ControlsActions @Controls => new ControlsActions(this);
        public interface IControlsActions
        {
            void OnToggleRotation(InputAction.CallbackContext context);
            void OnSwapCamera(InputAction.CallbackContext context);
            void OnQuit(InputAction.CallbackContext context);
            void OnMovePlayer(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnRotatePlayerCamera(InputAction.CallbackContext context);
        }
    }
}
