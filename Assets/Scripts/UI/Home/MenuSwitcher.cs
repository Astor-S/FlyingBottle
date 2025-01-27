using UI.Home.MainMenu;
using UI.Home.LevelMenu;
using UI.Home.ShopMenu;
using UnityEngine;

namespace UI.Home
{
    public class MenuSwitcher : MonoBehaviour
    {
        [SerializeField] private MainMenuService _mainMenuService;
        [SerializeField] private SelectLevel _selectLevel;
        [SerializeField] private SelectShop _selectShop;
        [SerializeField] private LevelMenuService _levelMenuService;
        [SerializeField] private ShopMenuService _shopMenuService;
        [SerializeField] private CloseLevelMenuButton _closeLevelMenuButton;
        [SerializeField] private CloseShopButton _closeShopButton;

        private void OnEnable()
        {
            _selectLevel.OnOpenLevelMenu += HandleOpenLevelMenu;
            _selectShop.OnOpenShop += HandleOpenShop;
            _closeLevelMenuButton.OnCloseLevelMenu += HandleCloseLevelMenu;
            _closeShopButton.OnCloseShop += HandleCloseShop;
        }

        private void OnDisable()
        {
            _selectLevel.OnOpenLevelMenu -= HandleOpenLevelMenu;
            _selectShop.OnOpenShop -= HandleOpenShop;
            _closeLevelMenuButton.OnCloseLevelMenu -= HandleCloseLevelMenu;
            _closeShopButton.OnCloseShop -= HandleCloseShop;
        }

        private void HandleOpenLevelMenu()
        {
            _levelMenuService.Open();
            _mainMenuService.Close();
        }

        private void HandleOpenShop()
        {
            _mainMenuService.Close();
            _shopMenuService.Open();
        }

        private void HandleCloseLevelMenu()
        {
            _levelMenuService.Close();
            _mainMenuService.Open();
        }

        private void HandleCloseShop()
        {
            _mainMenuService.Open();
            _shopMenuService.Close();
        }
    }
}