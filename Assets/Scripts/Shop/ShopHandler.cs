using System.Collections.Generic;
using UI.Home.ShopMenu;
using UnityEngine;
using YG;

namespace Shop
{
    public class ShopHandler : MonoBehaviour
    {
        [SerializeField] private Transform _shopContainer;

        private SavesYG _savesYG;

        private List<SkinItem> _allSkins = new();
        private List<ShopItemCell> _shopCells = new();
        private void Start()
        {
            LoadSkins();
            LoadSaves();
            InitializeCells();
        }

        private void LoadSkins()
        {
            _allSkins = new List<SkinItem>();

            SkinItem[] loadedSkins = Resources.LoadAll<SkinItem>("ShopItems");
            
            foreach (var item in loadedSkins)
                _allSkins.Add(item);
        }

        private void LoadSaves() =>
            _savesYG = YandexGame.savesData;

        private void HandleItemClick(ShopItemCell cell)
        {
            var item = cell.GetSkinItem();
            
            Debug.Log($"Clicked on {item.SkinType}");

            if (_savesYG.selectedSkin != null)
            {
                var prevSelectedCell = FindCell(_allSkins.Find(skin =>
                skin.SkinType == _savesYG.selectedSkin));

                prevSelectedCell?.SetSelected(false);
            }

            _savesYG.selectedSkin = item.SkinType;

            cell.SetSelected(true);
            SaveSaves();
        }

        private void SaveSaves() =>
            YandexGame.SaveProgress();

        private void InitializeCells()
        {
            _shopCells = new List<ShopItemCell>(_shopContainer.GetComponentsInChildren<ShopItemCell>(true));

            for (int i = 0; i < _shopCells.Count; i++)
            {
                if (i < _allSkins.Count)
                {
                    var cell = _shopCells[i];
                    var item = _allSkins[i];

                    bool isAvailable = _savesYG.ownedSkins.Contains(item.SkinType);
                    bool isSelected = _savesYG.selectedSkin == item.SkinType;

                    cell.Initialize(item, isAvailable, isSelected);
                    cell.OnCellClicked += HandleItemClick;
                }
            }
        }

        private ShopItemCell FindCell(SkinItem item)
        {
            foreach (var cell in _shopCells)
            {
                if (cell.GetSkinItem() == item)
                    return cell;  
            }

            return null;
        }
    }
}