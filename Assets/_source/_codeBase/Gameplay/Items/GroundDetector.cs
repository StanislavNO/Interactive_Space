using System;
using UnityEngine;

namespace Assets._source._codeBase.Gameplay.Items
{
    [RequireComponent(typeof(Collider2D))]
    internal class GroundDetector : MonoBehaviour
    {
        public event Action GroundEnter;

        [SerializeField] private Collider2D _collider;

        public bool IsGround { get; private set; }

        private void Awake()
        {
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IsGround = true;
            GroundEnter?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            IsGround = false;
        }
    }
}