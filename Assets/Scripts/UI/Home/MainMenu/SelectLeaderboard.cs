using UI.Home.Interfaces;
using UI.Home.MainMenu.LeadearboardMenu;
using UI.Home.MainMenu.Screens.AuthorizationScreen;
using UnityEngine;
using YG;

namespace UI.Home.MainMenu
{
    public class SelectLeaderboard : MonoBehaviour, IMenuButton
    {
        [SerializeField] AuthorizationRequestScreen _requestScreen;
        [SerializeField] LeadearboardService _leadearboardService;

        public void OnButtonClick()
        {
            if (YandexGame.auth)
                _leadearboardService.Open();
            else
                _requestScreen.Open();
        }
    }
}