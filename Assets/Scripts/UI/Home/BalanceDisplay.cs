using TMPro;
using UnityEngine;
using YG;

namespace UI.Home
{
    public class BalanceDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _balanceText;

        private SavesYG _savesYG;

        private void Start()
        {
            _savesYG = YandexGame.savesData;
            UpdateBalanceText();
        }

        private void UpdateBalanceText()
        {
            if (_balanceText != null && _savesYG != null)
                _balanceText.text = _savesYG.balanceMoney.ToString();   
        }

        public void RefreshBalance()
        {
            _savesYG = YandexGame.savesData;
            UpdateBalanceText();
        }
    }
}