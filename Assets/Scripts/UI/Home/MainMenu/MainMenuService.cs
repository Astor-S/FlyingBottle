using UnityEngine;

namespace UI.Home.MainMenu
{
    public class MainMenuService : MonoBehaviour
    {
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}