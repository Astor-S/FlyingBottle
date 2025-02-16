using GameService;
using UnityEngine;
using YG;

namespace UI.Home.ShopMenu
{
    public class AddMoneyButton : MenuButton
    {
        private readonly int _coinsForWathAD = 200;

        [SerializeField] private BalanceDisplay _balanceDisplayShop;
        [SerializeField] private BalanceDisplay _balanceDisplayMain;
        [SerializeField] private RewardAdService _rewardAdService;

        private SavesYG _savesYG;

        private void Start()
        {
            _savesYG = YandexGame.savesData;
        }

        private void OnEnable()
        {
            _rewardAdService.OnRewardReceived += AddMoney;
        }

        private void OnDisable()
        {
            _rewardAdService.OnRewardReceived -= AddMoney;
        }

        public override void  OnButtonClick() =>
            _rewardAdService.ShowRewardAd(0);

        private void AddMoney()
        {
            _savesYG.balanceMoney += _coinsForWathAD;
            YandexGame.SaveProgress();
            _balanceDisplayShop.RefreshBalance();
            _balanceDisplayMain.RefreshBalance();
        }
    }
}