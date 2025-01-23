using TMPro;
using UI.Home.Interfaces;
using UnityEngine;
using YG;

namespace UI.Home.ShopMenu
{
    public class BuyButton : MonoBehaviour, IMenuButton
    {
        [SerializeField] private GameService.Skins _skinToBuy;
        [SerializeField] private int _skinCost;
        [SerializeField] private TextMeshProUGUI _priceText;

        private SavesYG _savesYG;

        private void Start()
        {
            _savesYG = YandexGame.savesData;

            if (_savesYG.ownedSkins.Contains(_skinToBuy) == false)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);

            UpdatePriceText();
        }

        public void OnButtonClick() =>
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
        }

        private void UpdatePriceText() =>
            _priceText.text = _skinCost.ToString();
    }
}