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
        [SerializeField] private PurchaseHandler _purchaseHandler;

        private SavesYG _savesYG;

        public Skins SkinToBuy => _skinToBuy;
        public int SkinCost => _skinCost;

        private void Start()
        {
            _savesYG = YandexGame.savesData;

            if (_savesYG.ownedSkins.Contains(_skinToBuy) == false)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);

            UpdatePriceText();
        }

        public override void OnButtonClick() =>
           _purchaseHandler.PurchaseRequest(this);

        private void UpdatePriceText() =>
            _priceText.text = _skinCost.ToString();
    }
}