using UnityEngine;
using GameService;
using Shop;
using YG;

namespace UI.Home.ShopMenu
{
    public class BuyButton : MenuButton
    {
        [SerializeField] private BuyButtonView _buyButtonView;
        [SerializeField] private PurchaseHandler _purchaseHandler;
        [SerializeField] private Skins _skinToBuy;
        [SerializeField] private int _skinCost;

        private SavesYG _savesYG;

        public Skins SkinToBuy => _skinToBuy;
        public int SkinCost => _skinCost;

        private void Start()
        {
            _savesYG = YandexGame.savesData;

            if (_savesYG.ownedSkins.Contains(_skinToBuy) == false)
                _buyButtonView.ActivateVisibility(this);
            else
                _buyButtonView.DeactivateVisibility(this);

            _buyButtonView.UpdatePriceText(this);
        }

        public override void OnButtonClick() =>
           _purchaseHandler.PurchaseRequest(this);
    }
}