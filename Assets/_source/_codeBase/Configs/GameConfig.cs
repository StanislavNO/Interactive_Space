using UnityEngine;

namespace Assets._source._codeBase.Configs
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Settings")]
    internal class GameConfig : ScriptableObject
    {
        [field: SerializeField] public float CameraScrollSpeed { get; private set; }
    }
}