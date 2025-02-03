using System;
using TMPro;
using UI.Home.ShopMenu;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopItemCell : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private Image _itemImage;
        [SerializeField] private TextMeshProUGUI _priceText;
        
        [SerializeField] private Sprite _availableBackground;
        [SerializeField] private Sprite _selectedBackground;
        [SerializeField] private Sprite _unavailableBackground;

        private SkinItem _skinItem;

        private bool _isAvailable;
        private bool _isSelected;

        public Action<ShopItemCell> OnCellClicked;

        public void OnCellClick() =>
            OnCellClicked?.Invoke(this);

        public SkinItem GetSkinItem() =>
            _skinItem;

        public void Initialize(SkinItem skinItem, bool isAvailable, bool isSelected)
        {
            _skinItem = skinItem;
            _isAvailable = isAvailable;
            _isSelected = isSelected;

            UpdateVisual();
        }

        public void SetAvailable(bool isAvailable)
        {
            _isAvailable = isAvailable;
            UpdateVisual();
        }

        public void SetSelected(bool isSelected)
        {
            _isSelected = isSelected;
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            if (_isSelected)
            {
                _background.sprite = _selectedBackground;
            }
            else if (_isAvailable)
            {
                _background.sprite = _availableBackground;
            }
            else
            {
                _background.sprite = _unavailableBackground;
            }

            if (_skinItem != null)
            {
                _itemImage.sprite = _skinItem.Image;
            }
        }
    }
}