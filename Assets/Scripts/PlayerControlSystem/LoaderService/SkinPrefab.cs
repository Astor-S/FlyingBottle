using GameService;
using UnityEngine;

namespace PlayerControlSystem.LoaderService
{
    [System.Serializable]
    public struct SkinPrefab
    {
        [SerializeField] private Skins _skin;
        [SerializeField] private Player _prefab;

        public readonly Skins Skin => _skin;
        public readonly Player Prefab => _prefab;
    }
}