using UI.Home.Interfaces;
using UI.Home.MainMenu.LeadearboardMenu;
using UI.Home.MainMenu.Screens.AuthorizationScreen;
using UnityEngine;
using YG;

namespace UI.Home.MainMenu
{
    public class LeaderboardButton : MonoBehaviour, IMenuButton
    {
        [SerializeField] private AuthorizationRequestScreen _requestScreen;
        [SerializeField] private LeadearboardService _leadearboardService;

        public void OnButtonClick()
        {
            if (YandexGame.auth)
                _leadearboardService.Open();
            else
                _requestScreen.Open();
        }
    }
}