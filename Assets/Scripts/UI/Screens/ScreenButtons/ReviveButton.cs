using GameService;
using GameService.ReviveService;
using System;
using UnityEngine;

namespace UI.Screens.LevelScreens.ScreenButtons
{
    public class ReviveButton : MonoBehaviour
    {
        [SerializeField] private Reviver _reviver;
        [SerializeField] private FailScreen _failScreen;
        [SerializeField] private RewardAdService _rewardAdService;

        public event Action OnGameContinue;

        private void OnEnable()
        {
            _rewardAdService.OnRewardReceived += OnRevive;
        }

        private void OnDisable()
        {
            _rewardAdService.OnRewardReceived -= OnRevive;
        }

        public void OnReviveClick() =>
            _rewardAdService.ShowRewardAd(0);

        private void OnRevive()
        {
            _failScreen.Close();
            OnGameContinue?.Invoke();
            _reviver.Revived();
        }
    }
}