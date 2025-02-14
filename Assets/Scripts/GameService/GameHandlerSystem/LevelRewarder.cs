using GameService.ComboCounterService;
using UI.Screens.ScreenButtons;
using UnityEngine;
using YG;

namespace GameService.GameHandlerSystem
{
    public class LevelRewarder : MonoBehaviour
    {
        [SerializeField] private ComboCounter _comboCounter;
        [SerializeField] private CoinDoublingButton _coinDoubling;
        [SerializeField] private int _coinsPerLevel;

        private SavesYG _savesYG;
        
        private int _totalCoins;
        private int _levelCoins;

        public int TotalCoins => _totalCoins;

        private void Start()
        {
            _savesYG = YandexGame.savesData;
        }

        private void OnEnable()
        {
            _coinDoubling.OnDoubleAwards += HandleDoubleAwardRequest;
        }

        private void OnDisable()
        {
            _coinDoubling.OnDoubleAwards -= HandleDoubleAwardRequest;
        }

        public void AwardCoins()
        {
            _levelCoins = _coinsPerLevel + _comboCounter.TotalComboCount;
            _totalCoins += _levelCoins;
            SaveProgress();
        }

        private void HandleDoubleAwardRequest()
        {
            _totalCoins += _levelCoins;
            SaveProgress();
        }

        private void SaveProgress()
        {
            _savesYG.balanceMoney += _levelCoins;
            _savesYG.score += _levelCoins;
            YandexGame.SaveProgress();
            AddNewLeaderboardScores();
        }

        private void AddNewLeaderboardScores()
        {
            int score = _savesYG.score;
            YandexGame.NewLeaderboardScores("BestPlayers", score);
        }
    }
}