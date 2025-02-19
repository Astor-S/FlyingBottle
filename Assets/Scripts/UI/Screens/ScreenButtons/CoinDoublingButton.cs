using GameService;
using System;
using UnityEngine;

namespace UI.Screens.ScreenButtons
{
    public class CoinDoublingButton : MonoBehaviour
    {
        [SerializeField] private RewardAdService _rewardAdService;

        public Action OnDoubleAwards;

        private void OnEnable()
        {
            _rewardAdService.RewardReceived += AddDoubleAwards;
        }

        private void OnDisable()
        {
            _rewardAdService.RewardReceived += AddDoubleAwards;
        }

        public void OnButtonClick() =>
            _rewardAdService.ShowRewardAd(0);

        private void AddDoubleAwards()
        {
            OnDoubleAwards?.Invoke();
            gameObject.SetActive(false);
        }
    }
}