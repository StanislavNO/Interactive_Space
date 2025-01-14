using UnityEngine;

namespace Assets._source._codeBase.Gameplay.ScrollPoint
{
    internal class StopScrollPoint : MonoBehaviour
    {
        [SerializeField] private Transform _leftTransform;
        [SerializeField] private Transform _rightTransform;

        public Vector3 LeftPosition => _leftTransform.position;
        public Vector3 RightPosition => _rightTransform.position;
    }
}