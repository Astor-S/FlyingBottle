using GameService;
using System.Collections.Generic;
using UI.Home.ShopMenu;
using UnityEngine;

namespace Shop
{
    public class ShopHandler : MonoBehaviour
    {
        [SerializeField] private Transform _shopContainer;

        private List<SkinItem> _allSkins = new(); 
        private List<Skins> _availableSkins = new(); 
        private SkinItem _selectedSkin;

        private List<ShopItemCell> _shopCells = new();

        private void Start()
        {
            LoadSkins();
            InitializeCells();
        }

        private void LoadSkins()
        {
            _allSkins = new List<SkinItem>();

            SkinItem[] loadedSkins = Resources.LoadAll<SkinItem>("ShopItems");
            
            foreach (var item in loadedSkins)
                _allSkins.Add(item);

            _availableSkins = new List<Skins>() { Skins.Water}; 
            _selectedSkin = _allSkins.Find(skin => skin.SkinType == Skins.Water);
        }

        private void HandleItemClick(ShopItemCell cell)
        {
            var item = cell.GetSkinItem();
            
            Debug.Log($"Clicked on {item.SkinType}");

            if (_selectedSkin != null)
            {
                var prevSelectedCell = FindCell(_selectedSkin);
                prevSelectedCell?.SetSelected(false);
            }

            _selectedSkin = item;

            cell.SetSelected(true);
        }

        private void InitializeCells()
        {
            _shopCells = new List<ShopItemCell>(_shopContainer.GetComponentsInChildren<ShopItemCell>(true));

            for (int i = 0; i < _shopCells.Count; i++)
            {
                if (i < _allSkins.Count)
                {
                    var cell = _shopCells[i];
                    var item = _allSkins[i];

                    bool isAvailable = _availableSkins.Contains(item.SkinType);
                    bool isSelected = _selectedSkin != null && _selectedSkin.SkinType == item.SkinType;
                    
                    cell.Initialize(item, isAvailable, isSelected);
                    cell.OnCellClicked += HandleItemClick;
                }
            }
        }

        private ShopItemCell FindCell(SkinItem item)
        {
            foreach (Transform child in _shopContainer)
            {
                ShopItemCell cell = child.GetComponent<ShopItemCell>();
                
                if (cell == null)
                    continue;
                
                if (cell.GetSkinItem() == item)
                    return cell;   
            }

            return null;
        }
    }
}