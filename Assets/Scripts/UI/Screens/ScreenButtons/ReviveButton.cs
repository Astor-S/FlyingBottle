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

        public event Action GameContinued;

        private void OnEnable()
        {
            _rewardAdService.RewardReceived += OnRevive;
        }

        private void OnDisable()
        {
            _rewardAdService.RewardReceived -= OnRevive;
        }

        public void OnReviveClick() =>
            _rewardAdService.ShowRewardAd(0);

        private void OnRevive()
        {
            _failScreen.Close();
            GameContinued?.Invoke();
            _reviver.Revived();
        }
    }
}