using System;
using UnityEngine;
using Zenject;

namespace Assets._source._codeBase.Infrastructure.Services.InputService
{
    internal class StandaloneInput : IInputService, ITickable, IInitializable
    {
        private const string Horizontal = "Mouse X";
        private const string Vertical = "Mouse Y";

        public event Action<float> HorizontalAxis;
        public event Action<Vector2> Dragging;
        public event Action<Vector2> ClickUp;
        public event Action<Vector2> ClickDown;

        private Camera _camera;
        private float _horizontalAxisValue;
        private bool _isActive = false;

        private Vector2 MouseClickPosition => _camera.ScreenToWorldPoint(Input.mousePosition);

        public void Initialize()
        {
            _camera = Camera.main;
        }

        public void Tick()
        {
            HandleInput();
        }

        private void HandleInput()
        {

            if (Input.GetMouseButtonUp(0))
            {
                ClickUp?.Invoke(MouseClickPosition);
                _isActive = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                ClickDown?.Invoke(MouseClickPosition);
                _isActive = true;
            }

            if (_isActive)
            {
                _horizontalAxisValue = Input.GetAxis(Horizontal);
                _horizontalAxisValue = Mathf.Clamp(_horizontalAxisValue, -1, 1);

                HorizontalAxis?.Invoke(_horizontalAxisValue);
                Dragging?.Invoke(MouseClickPosition);
            }
        }
    }
}