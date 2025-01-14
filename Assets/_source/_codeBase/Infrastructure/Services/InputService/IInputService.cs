using System;
using UnityEngine;

namespace Assets._source._codeBase.Infrastructure.Services.InputService
{
    public interface IInputService
    {
        event Action<float> HorizontalAxis;

        event Action<Vector2> Dragging;
        event Action<Vector2> ClickUp;
        event Action<Vector2> ClickDown;
    }
}