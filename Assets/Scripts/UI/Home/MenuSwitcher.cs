using UI.Home.LeadearboardMenu;
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
        [SerializeField] private SelectLeaderboard _selectLeaderboard;
        [SerializeField] private LevelMenuService _levelMenuService;
        [SerializeField] private ShopMenuService _shopMenuService;
        [SerializeField] private LeadearboardService _leadearboardService;
        [SerializeField] private CloseLevelMenuButton _closeLevelMenuButton;
        [SerializeField] private CloseShopButton _closeShopButton;
        [SerializeField] private CloseLeadearBoardButton _closeLeadearBoardButton;

        private void OnEnable()
        {
            _selectLevel.OnOpenLevelMenu += HandleOpenLevelMenu;
            _selectShop.OnOpenShop += HandleOpenShop;
            _selectLeaderboard.OnOpenLeadearboard += HandleOpenLeaderboard;
            _closeLevelMenuButton.OnCloseLevelMenu += HandleCloseLevelMenu;
            _closeShopButton.OnCloseShop += HandleCloseShop;
            _closeLeadearBoardButton.OnCloseLeadearboard += HandleCloseLeadearboard;
        }

        private void OnDisable()
        {
            _selectLevel.OnOpenLevelMenu -= HandleOpenLevelMenu;
            _selectShop.OnOpenShop -= HandleOpenShop;
            _selectLeaderboard.OnOpenLeadearboard -= HandleOpenLeaderboard;
            _closeLevelMenuButton.OnCloseLevelMenu -= HandleCloseLevelMenu;
            _closeShopButton.OnCloseShop -= HandleCloseShop;
            _closeLeadearBoardButton.OnCloseLeadearboard -= HandleCloseLeadearboard;
        }

        private void HandleOpenLeaderboard()
        {
            _leadearboardService.Open();
            _mainMenuService.Close();
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

        private void HandleCloseLeadearboard() 
        { 
            _leadearboardService.Close();
            _mainMenuService.Open();
        }
    }
}