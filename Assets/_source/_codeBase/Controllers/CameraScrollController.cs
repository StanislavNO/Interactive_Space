using Assets._source._codeBase.Configs;
using Assets._source._codeBase.Gameplay.ScrollPoint;
using Assets._source._codeBase.Infrastructure.Services.InputService;
using System;
using UnityEngine;
using Zenject;

namespace Assets._source._codeBase.Controllers
{
    internal class CameraScrollController : IInitializable, IDisposable, IMapScroller
    {
        private readonly IInputService _inputService;

        private readonly StopScrollPoint _stopPoint;
        private readonly Transform _camera;

        private readonly float _cameraHalfWidth;
        private readonly float _scrollSpeed;

        public bool IsScrolling { get; set; }

        public CameraScrollController(IInputService inputService, StopScrollPoint stopScrollPoint, GameConfig config)
        {
            _inputService = inputService;
            _stopPoint = stopScrollPoint;

            _scrollSpeed = config.CameraScrollSpeed;
            IsScrolling = false;

            _camera = Camera.main.transform;
            _cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        }

        public void Initialize()
        {
            _inputService.HorizontalAxis += MovementCamera;
        }

        public void Dispose()
        {
            _inputService.HorizontalAxis -= MovementCamera;
        }

        private void MovementCamera(float axis)
        {
            if (IsScrolling == false)
                return;

            float newX = HandleNewPosition(-axis);
            _camera.position = new(newX, _camera.position.y, _camera.position.z);
        }

        private float HandleNewPosition(float axis)
        {
            float newX = _camera.position.x + axis * _scrollSpeed;

            newX = Mathf.Clamp(newX,
                _stopPoint.LeftPosition.x + _cameraHalfWidth,
                _stopPoint.RightPosition.x - _cameraHalfWidth);

            return newX;
        }
    }
}