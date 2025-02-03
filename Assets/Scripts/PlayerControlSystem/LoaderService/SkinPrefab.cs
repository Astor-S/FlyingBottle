using GameService;
using UnityEngine;

namespace PlayerControlSystem.LoaderService
{
    [System.Serializable]
    public struct SkinPrefab
    {
        [SerializeField] private Skins _skin;
        [SerializeField] private Player _prefab;

        public Skins Skin => _skin;
        public Player Prefab => _prefab;
    }
}