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

        private void Awake()
        {
            if (_skinPrefabs == null || _skinPrefabs.Count == 0)
                return;
            
            _skinPrefabDictionary = new Dictionary<Skins, Player>();

            foreach (SkinPrefab skinPrefab in _skinPrefabs)
            {
                if (_skinPrefabDictionary.ContainsKey(skinPrefab.skin) == false)
                    _skinPrefabDictionary.Add(skinPrefab.skin, skinPrefab.prefab); 
            }
        }

        private void Start()
        {
            Skins selectedSkin = YandexGame.savesData.selectedSkin;

            LoadPlayerPrefab(selectedSkin);
        }

        private void LoadPlayerPrefab(Skins skin)
        {
            if (_skinPrefabDictionary.TryGetValue(skin, out Player prefab))
                Instantiate(prefab, _loadingPoint.position, _loadingPoint.rotation); 
        }
    }
}