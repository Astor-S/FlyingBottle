using TMPro;
using UnityEngine;

namespace GameService.ComboCounterService
{
    public class ComboCounterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _comboText;

        private void Start()
        {
            HideCombo();
        }

        public void SetComboText(string text)
        {
            _comboText.text = text;
        }

        public void ShowCombo()
        {
            _comboText.gameObject.SetActive(true);
        }

        public void HideCombo()
        {
            _comboText.gameObject.SetActive(false);
        }
    }
}