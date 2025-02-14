using UnityEngine;
using TMPro;
using GameService.GameHandlerSystem;

namespace GameService.ComboCounterService
{
    public class CoinCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinText;
        [SerializeField] private LevelRewarder _levelRewarder;

        private void OnEnable()
        {
            UpdateCoinText();
        }

        private void OnDisable()
        {
            UpdateCoinText();
        }

        private void UpdateCoinText() =>
            _coinText.text = "+" + _levelRewarder.TotalCoins.ToString();
    }
}