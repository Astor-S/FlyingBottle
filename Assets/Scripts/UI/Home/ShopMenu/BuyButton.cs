using Shop;
using TMPro;
using UnityEngine;
using YG;
using GameService;

namespace UI.Home.ShopMenu
{
    public class BuyButton : MenuButton
    {
        [SerializeField] private Skins _skinToBuy;
        [SerializeField] private int _skinCost;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private BalanceDisplay _balanceDisplayShop;
        [SerializeField] private BalanceDisplay _balanceDisplayMain;

        private SavesYG _savesYG;
        private ShopItemCell _shopItemCell;

        private void Start()
        {
            _savesYG = YandexGame.savesData;

            _shopItemCell = GetComponentInParent<ShopItemCell>();

            if (_savesYG.ownedSkins.Contains(_skinToBuy) == false)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);

            UpdatePriceText();
        }

        public override void OnButtonClick() =>
            PurchaseRequest();

        private void PurchaseRequest()
        {
            if (_savesYG.balanceMoney >= _skinCost)
            {
                SpendCoin();
                Buy();
            }
        }

        private void SpendCoin() =>
            _savesYG.balanceMoney -= _skinCost;

        private void Buy()
        {
            _savesYG.ownedSkins.Add(_skinToBuy);
            YandexGame.SaveProgress();
            
            gameObject.SetActive(false);
            
            _balanceDisplayShop.RefreshBalance();
            _balanceDisplayMain.RefreshBalance();
            
            if (_shopItemCell != null)
                _shopItemCell.SetAvailable(true);
        }

        private void UpdatePriceText() =>
            _priceText.text = _skinCost.ToString();
    }
}