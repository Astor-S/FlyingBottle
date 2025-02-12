using GameService.ReviveService;
using System;
using UnityEngine;
using YG;

namespace UI.Screens.LevelScreens.ScreenButtons
{
    public class ReviveButton : MonoBehaviour
    {
        [SerializeField] private Reviver _reviver;
        [SerializeField] private FailScreen _failScreen;

        public event Action OnGameContinue;

        private void OnEnable()
        {
            YandexGame.RewardVideoEvent += Rewarded;
        }

        private void OnDisable()
        {
            YandexGame.RewardVideoEvent -= Rewarded;
        }

        public void OnReviveClick() =>
           OpenRewardAd(0);

        private void OpenRewardAd(int id) =>
           YandexGame.RewVideoShow(id);

        private void Rewarded(int _) =>
           OnRevive();

        private void OnRevive()
        {
            _failScreen.Close();
            OnGameContinue?.Invoke();
            _reviver.Revived();
        }
    }
}