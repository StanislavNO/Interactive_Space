using Assets._source._codeBase.Gameplay.Items;
using UnityEngine;

namespace Assets._source._codeBase.Infrastructure.Services.RaycastService
{
    internal class RaycastService : IRaycastService
    {
        public bool TryHit(Vector2 mouseWorldPosition, out IInteractable item)
        {
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero);

            if (hit && hit.collider.TryGetComponent(out IInteractable subject))
            {
                item = subject;
                return true;
            }

            item = null;
            return false;
        }
    }
}