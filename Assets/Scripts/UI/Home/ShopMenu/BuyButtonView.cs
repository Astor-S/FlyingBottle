using UnityEngine;
using TMPro;

namespace UI.Home.ShopMenu
{
    public class BuyButtonView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _priceText;

        public void ActivateVisibility(BuyButton buyButton) =>
            buyButton.gameObject.SetActive(true);

        public void DeactivateVisibility(BuyButton buyButton) =>
            buyButton.gameObject.SetActive(false);

        public void UpdatePriceText(BuyButton buyButton) =>
            _priceText.text = buyButton.SkinCost.ToString();
    }
}