using UnityEngine;
using UnityEngine.UI;

namespace UI.Home.MainMenu.Screens
{
    public class ScreenInMainMenu : MonoBehaviour
    {

        [SerializeField] private Button _openButton;
        [SerializeField] private Button _closeButton;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Open() =>
            gameObject.SetActive(true);

        public void Close() =>
            gameObject.SetActive(false);
    }
}