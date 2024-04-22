using System;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class InputManager : Singleton<InputManager>
    {
        public event Action<Vector2> OnStartTouch;
        public event Action<Vector2> OnEndTouch;
        
        private TouchControls _touchControls;

        private void Awake()
        {
            _touchControls = new TouchControls();
        }

        private void OnEnable()
        {
            _touchControls.Enable();
        }

        private void OnDisable()
        {
            _touchControls.Disable();
        }

        private void Start()
        {
            _touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
            _touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
        }
        
        private void StartTouch(InputAction.CallbackContext ctx)
        {
            //Debug.Log("Touch started " + _touchControls.Touch.TouchPosition.ReadValue<Vector2>());
            OnStartTouch?.Invoke(_touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        }
        
        private void EndTouch(InputAction.CallbackContext ctx)
        {
            //Debug.Log("Touch ended " + _touchControls.Touch.TouchPosition.ReadValue<Vector2>());
            OnEndTouch?.Invoke(_touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        }
        
    }
}