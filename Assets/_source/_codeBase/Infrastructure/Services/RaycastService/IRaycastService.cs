using Assets._source._codeBase.Gameplay.Items;
using UnityEngine;

namespace Assets._source._codeBase.Infrastructure.Services.RaycastService
{
    internal interface IRaycastService
    {
        bool TryHit(Vector2 mouseWorldPosition, out IInteractable item);
    }
}