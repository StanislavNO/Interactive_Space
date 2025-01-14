using UnityEngine;

namespace Assets._source._codeBase.Gameplay.Items
{
    internal interface IInteractable
    {
        void Move(Vector2 position);
        void StartDragAndDropping();
        void StopDragAndDropping();
    }
}