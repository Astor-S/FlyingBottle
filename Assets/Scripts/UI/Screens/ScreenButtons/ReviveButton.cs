using GameService.ReviveService;
using UnityEngine;
using YG;

namespace UI.Screens.LevelScreens.ScreenButtons
{
    public class ReviveButton : MonoBehaviour
    {
        [SerializeField] private Reviver _reviver;
        [SerializeField] private FailScreen _failScreen;

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
            ContinueGame();
            _reviver.Revived();
        }

        private void ContinueGame() =>
            Time.timeScale = 1f;
    }
}