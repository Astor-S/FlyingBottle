using System;
using UI.Home.Interfaces;
using UI.Home.MainMenu.Screens.AuthorizationScreen;
using UnityEngine;
using YG;

namespace UI.Home.MainMenu
{
    public class SelectLeaderboard : MonoBehaviour, IMenuButton
    {
        [SerializeField] AuthorizationRequestScreen _requestScreen;

        public event Action OnOpenLeadearboard;

        public void OnButtonClick()
        {
            if (YandexGame.auth)
                OnOpenLeadearboard?.Invoke();
            else
                _requestScreen.Open();
        }
    }
}