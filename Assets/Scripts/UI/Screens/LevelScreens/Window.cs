using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.LevelScreens
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] private Button _homeButton;

        public event Action HomeButtonClicked;

        protected Button HomeButton => _homeButton;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _homeButton.onClick.AddListener(OnHomeButtonClick);
        }

        private void OnDisable()
        {
            _homeButton.onClick.RemoveListener(OnHomeButtonClick);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        private void OnHomeButtonClick()
        {
            HomeButtonClicked?.Invoke();
        }
    }
}