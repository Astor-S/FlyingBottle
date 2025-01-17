using UnityEngine;
using TMPro;

namespace GameService.ComboCounterService
{
    public class CoinCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinText;
        [SerializeField] private Game _game;

        private void OnEnable()
        {
            UpdateCoinText();
        }

        private void OnDisable()
        {
            UpdateCoinText();
        }

        private void UpdateCoinText()
        {
            _coinText.text = "+" + _game.TotalCoins.ToString();
        }
    }
}