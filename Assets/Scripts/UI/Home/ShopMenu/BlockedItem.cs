using GameService;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace UI.Home.ShopMenu
{
    public class BlockedItem : MonoBehaviour
    {
        [SerializeField] private Skins _skin;
        [SerializeField] private Image _icon;

        private SavesYG _savesYG;

        private void Start()
        {
            _savesYG = YandexGame.savesData;

            if (_savesYG.ownedSkins.Contains(_skin) == false)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
        }
    }
}