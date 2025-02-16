using System;
using UnityEngine;
using YG;

namespace GameService
{
    public class RewardAdService : MonoBehaviour
    {
        public event Action OnRewardReceived;

        private void OnEnable()
        {
            YandexGame.RewardVideoEvent += Rewarded;
        }

        private void OnDisable()
        {
            YandexGame.RewardVideoEvent -= Rewarded;
        }

        public void ShowRewardAd(int id) =>
            YandexGame.RewVideoShow(id);

        private void Rewarded(int id) =>
            OnRewardReceived?.Invoke();
    }
}