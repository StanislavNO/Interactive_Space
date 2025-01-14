using Assets._source._codeBase.Gameplay.Items;
using Assets._source._codeBase.Infrastructure.Services.InputService;
using Assets._source._codeBase.Infrastructure.Services.RaycastService;
using System;
using UnityEngine;
using Zenject;

namespace Assets._source._codeBase.Controllers
{
    internal class PlayerInputController : IInitializable, IDisposable
    {
        private readonly IMapScroller _mapScroller;
        private readonly IInputService _inputService;
        private readonly IRaycastService _raycastService;

        private IInteractable _item;
        private bool _isDragAndDrooping;

        public PlayerInputController(IMapScroller mapScroller, IInputService inputService, IRaycastService raycastService)
        {
            _mapScroller = mapScroller;
            _inputService = inputService;
            _raycastService = raycastService;
        }

        public void Initialize()
        {
            _inputService.ClickDown += OnPlayerClickDown;
            _inputService.ClickUp += OnPlayerClickUp;
            _inputService.Dragging += OnDragging;
        }

        public void Dispose()
        {
            _inputService.ClickDown -= OnPlayerClickDown;
            _inputService.ClickUp -= OnPlayerClickUp;
            _inputService.Dragging -= OnDragging;
        }

        private void OnDragging(Vector2 worldPosition)
        {
            if (_isDragAndDrooping == false)
                return;

            _item?.Move(worldPosition);
        }

        private void OnPlayerClickDown(Vector2 mousePosition)
        {
            if (_raycastService.TryHit(mousePosition, out IInteractable item))
            {
                _item = item;
                _item.StartDragAndDropping();
                _isDragAndDrooping = true;
            }
            else
            {
                _mapScroller.IsScrolling = true;
            }
        }

        private void OnPlayerClickUp(Vector2 vector)
        {
            _mapScroller.IsScrolling = false;
            _isDragAndDrooping = false;
            _item?.StopDragAndDropping();
        }
    }
}