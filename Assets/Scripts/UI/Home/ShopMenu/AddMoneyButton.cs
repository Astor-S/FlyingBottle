using UI.Home.Interfaces;
using UnityEngine;
using YG;

namespace UI.Home.ShopMenu
{
    public class AddMoneyButton : MonoBehaviour, IMenuButton
    {
        [SerializeField] private BalanceDisplay _balanceDisplayShop;
        [SerializeField] private BalanceDisplay _balanceDisplayMain;

        private SavesYG _savesYG;

        private int _coinsFofWathAD = 200;

        private void Start()
        {
            _savesYG = YandexGame.savesData;
        }

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
            AddMoney();

        private void AddMoney()
        {
            _savesYG.balanceMoney += _coinsFofWathAD;
            YandexGame.SaveProgress();
            _balanceDisplayShop.RefreshBalance();
            _balanceDisplayMain.RefreshBalance();
        }
    }
}