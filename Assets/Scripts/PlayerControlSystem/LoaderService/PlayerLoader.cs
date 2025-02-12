using GameService;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace PlayerControlSystem.LoaderService
{
    public class PlayerLoader : MonoBehaviour
    {
        [SerializeField] private List<SkinPrefab> _skinPrefabs;
        [SerializeField] private Transform _loadingPoint;

        private Dictionary<Skins, Player> _skinPrefabDictionary;
        private Player _loadedPlayer;

        private void Awake()
        {
            if (_skinPrefabs == null || _skinPrefabs.Count == 0)
                return;
            
            _skinPrefabDictionary = new Dictionary<Skins, Player>();

            foreach (SkinPrefab skinPrefab in _skinPrefabs)
            {
                if (_skinPrefabDictionary.ContainsKey(skinPrefab.Skin) == false)
                    _skinPrefabDictionary.Add(skinPrefab.Skin, skinPrefab.Prefab); 
            }
        }

        private void Start()
        {
            Skins selectedSkin = YandexGame.savesData.selectedSkin;

            LoadPlayerPrefab(selectedSkin);
        }

        public Player GetPlayer() =>
            _loadedPlayer;

        private void LoadPlayerPrefab(Skins skin)
        {
            if (_skinPrefabDictionary.TryGetValue(skin, out Player prefab))
                _loadedPlayer = Instantiate(prefab, _loadingPoint.position, _loadingPoint.rotation);
        }
    }
}