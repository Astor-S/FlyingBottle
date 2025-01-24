using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Home.MainMenu.Screens
{
    public class ScreenInMainMenu : MonoBehaviour
    {

        [SerializeField] private Button _openButton;
        [SerializeField] private Button _closeButton;

        public event Action OpenButtonClicked;
        public event Action CloseButtonClicked;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _openButton.onClick.AddListener(OnOpenButtonClick);
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnDisable()
        {
            _openButton.onClick.RemoveListener(OnOpenButtonClick);
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        private void OnOpenButtonClick() =>
            OpenButtonClicked?.Invoke();

        private void OnCloseButtonClick() =>
            CloseButtonClicked?.Invoke();
    }
}