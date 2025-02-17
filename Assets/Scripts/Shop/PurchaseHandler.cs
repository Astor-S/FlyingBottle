using System.Collections.Generic;
using UI.Home;
using UI.Home.ShopMenu;
using UnityEngine;
using YG;

namespace Shop
{
    public class PurchaseHandler : MonoBehaviour
    {
        [SerializeField] private BalanceDisplay _balanceDisplayShop;
        [SerializeField] private BalanceDisplay _balanceDisplayMain;
        [SerializeField] private List<ShopItemCell> _shopItemCells = new();
        
        private SavesYG _savesYG;

        private void Start()
        {
            _savesYG = YandexGame.savesData;
        }

        public void PurchaseRequest(BuyButton buyButton) 
        {
            if (_savesYG.balanceMoney >= buyButton.SkinCost)
            {
                SpendCoin(buyButton); 
                Buy(buyButton); 
            }
        }

        private void SpendCoin(BuyButton buyButton) =>
            _savesYG.balanceMoney -= buyButton.SkinCost;

        private void Buy(BuyButton buyButton)
        {
            _savesYG.ownedSkins.Add(buyButton.SkinToBuy);
            YandexGame.SaveProgress();

            buyButton.gameObject.SetActive(false); ;

            _balanceDisplayShop.RefreshBalance();
            _balanceDisplayMain.RefreshBalance();

            foreach (ShopItemCell shopItemCell in _shopItemCells)
                if (shopItemCell != null)
                    shopItemCell.SetAvailable(true);
        }
    }
}