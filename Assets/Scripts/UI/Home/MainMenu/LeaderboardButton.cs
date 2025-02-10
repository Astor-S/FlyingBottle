using UI.Home.MainMenu.LeadearboardMenu;
using UI.Home.MainMenu.Screens.AuthorizationScreen;
using UnityEngine;
using YG;

namespace UI.Home.MainMenu
{
    public class LeaderboardButton : MenuButton
    {
        [SerializeField] private AuthorizationRequestScreen _requestScreen;
        [SerializeField] private LeadearboardService _leadearboardService;

        public override void OnButtonClick()
        {
            if (YandexGame.auth)
                _leadearboardService.Open();
            else
                _requestScreen.Open();
        }
    }
}