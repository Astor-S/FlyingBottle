using UI.Home.Interfaces;
using UnityEngine;

namespace UI.Home.MainMenu
{
    public class MainMenuService : MonoBehaviour, IMenuService
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