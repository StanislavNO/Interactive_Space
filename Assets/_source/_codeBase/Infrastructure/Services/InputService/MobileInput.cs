using System;
using UnityEngine;

namespace Assets._source._codeBase.Infrastructure.Services.InputService
{
    internal class MobileInput : IInputService
    {

        public event Action<float> HorizontalAxis;
        public event Action<Vector2> Dragging;
        public event Action<Vector2> ClickUp;
        public event Action<Vector2> ClickDown;

        private Camera _camera;
        private float _horizontalAxisValue;
        private bool _isTouching = false;

        private Vector2 TouchPosition => _camera.ScreenToWorldPoint(Input.touches[0].position);

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
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        ClickDown?.Invoke(TouchPosition);
                        _isTouching = true;
                        break;

                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        if (_isTouching)
                        {
                            _horizontalAxisValue = touch.deltaPosition.x;
                            _horizontalAxisValue = Mathf.Clamp(_horizontalAxisValue, -1, 1);

                            HorizontalAxis?.Invoke(_horizontalAxisValue);
                            Dragging?.Invoke(TouchPosition);
                        }
                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        ClickUp?.Invoke(TouchPosition);
                        _isTouching = false;
                        break;
                }
            }
        }
    }
}