using UnityEngine;

namespace Assets._source._codeBase.Gameplay.Items
{
    [RequireComponent(typeof(Collider2D))]
    public class Item : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private GroundDetector _detector;

        private float _minGravity = 0f;
        private float _maxGravity = 1f;

        private void OnEnable() => _detector.GroundEnter += OnGroundEnter;
        private void OnDisable() => _detector.GroundEnter -= OnGroundEnter;

        public void Move(Vector2 position) =>
            _transform.position = position;

        public void StartDragAndDropping()
        {
            _rigidbody.gravityScale = _minGravity;
        }

        public void StopDragAndDropping()
        {
            if (_detector.IsGround == false)
            {
                _rigidbody.gravityScale = _maxGravity;
            }
        }

        private void OnGroundEnter()
        {
            _rigidbody.gravityScale = _minGravity;
            _rigidbody.velocity = Vector2.zero;
        }
    }
}