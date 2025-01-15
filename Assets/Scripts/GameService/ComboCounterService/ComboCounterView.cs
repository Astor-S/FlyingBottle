using TMPro;
using UnityEngine;

namespace GameService.ComboCounterService
{
    public class ComboCounterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _comboNumberText;
        [SerializeField] private TextMeshProUGUI _comboText;

        private void Start()
        {
            HideCombo();
        }

        public void SetComboText(string text)
        {
            _comboNumberText.text = text;
        }

        public void ShowCombo()
        {
            _comboNumberText.enabled = true;
            _comboText.enabled = true;
        }

        public void HideCombo()
        {
            _comboNumberText.enabled = false;
            _comboText.enabled = false;
        }
    }
}