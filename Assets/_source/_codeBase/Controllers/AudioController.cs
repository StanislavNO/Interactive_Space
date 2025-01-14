using Assets._source._codeBase.Infrastructure.Services.InputService;
using UnityEngine;
using Zenject;

namespace Assets._source._codeBase.Controllers
{
    internal class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;

        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void OnEnable() => _inputService.ClickDown += OnPlayrClick;

        private void OnDisable() => _inputService.ClickDown -= OnPlayrClick;

        private void OnPlayrClick(Vector2 _) => _source.Play();
    }
}