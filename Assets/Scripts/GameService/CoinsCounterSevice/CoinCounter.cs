using UnityEngine;
using TMPro;

namespace GameService.ComboCounterService
{
    public class CoinCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinText;
        [SerializeField] private GameHandler _gameHandler;

        private void OnEnable()
        {
            UpdateCoinText();
        }

        private void OnDisable()
        {
            UpdateCoinText();
        }

        private void UpdateCoinText() =>
            _coinText.text = "+" + _gameHandler.TotalCoins.ToString();
    }
}