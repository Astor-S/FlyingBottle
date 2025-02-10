using UnityEngine;
using YG;

namespace UI.Home.ShopMenu
{
    public class AddSkinForADButton : MenuButton
    {
        [SerializeField] private GameService.Skins _skinToAdd;

        private SavesYG _savesYG;

        private void Start()
        {
            _savesYG = YandexGame.savesData;

            if (_savesYG.ownedSkins.Contains(_skinToAdd) == false)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            YandexGame.RewardVideoEvent += Rewarded;
        }

        private void OnDisable()
        {
            YandexGame.RewardVideoEvent -= Rewarded;
        }

        public override void OnButtonClick() =>
           OpenRewardAd(0);

        private void OpenRewardAd(int id) =>
            YandexGame.RewVideoShow(id);

        private void Rewarded(int _) => 
            AddSkin();

        private void AddSkin()
        {
            _savesYG.ownedSkins.Add(_skinToAdd);
            YandexGame.SaveProgress();
            gameObject.SetActive(false);
        }
    }
}