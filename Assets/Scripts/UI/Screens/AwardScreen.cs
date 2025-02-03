using GameService;
using UnityEngine;
using YG;

namespace UI.Screens
{
    public class AwardScreen : MonoBehaviour
    {
        [SerializeField] private Skins _skinToAdd;

        private SavesYG _savesYG;

        private void Start()
        {
            _savesYG = YandexGame.savesData;
            gameObject.SetActive(false);
        }

        public void GiveReward()
        {
            if (_savesYG.ownedSkins.Contains(_skinToAdd) == false)
            {
                gameObject.SetActive(true);
                _savesYG.ownedSkins.Add(_skinToAdd);
                YandexGame.SaveProgress();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}