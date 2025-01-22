using System;
using UnityEngine;
using YG;

namespace UI.Screens.LevelScreens
{
    public class CoinDoublingButton : MonoBehaviour
    {
        public Action OnDoubleAwards;

        private void OnEnable()
        {
            YandexGame.RewardVideoEvent += Rewarded;
        }

        private void OnDisable()
        {
            YandexGame.RewardVideoEvent -= Rewarded;
        }

        public void OnButtonClick() =>
            OpenRewardAd(0);

        private void OpenRewardAd(int id) =>
            YandexGame.RewVideoShow(id);

        private void Rewarded(int id) =>
            AddDoubleAwards();

        private void AddDoubleAwards()
        {
            OnDoubleAwards?.Invoke();
            gameObject.SetActive(false);
        }
    }
}