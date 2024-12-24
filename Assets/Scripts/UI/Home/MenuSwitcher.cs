using UnityEngine;

namespace UI.Home
{
    public class MenuSwitcher : MonoBehaviour
    {
        [SerializeField] private MainMenu.MainMenuService _mainMenuService;
        [SerializeField] private MainMenu.SelectLevel _selectLevel;
        [SerializeField] private LevelMenu.LevelMenuService _levelMenuService;
        [SerializeField] private LevelMenu.CloseButton _closeButton;

        private void OnEnable()
        {
            _selectLevel.OnOpenLevelMenu += HandleOpenLevelMenu;
            _closeButton.OnCloseLevelMenu += HandleCloseLevelMenu;
        }

        private void OnDisable()
        {
            _selectLevel.OnOpenLevelMenu -= HandleOpenLevelMenu;
            _closeButton.OnCloseLevelMenu -= HandleCloseLevelMenu;
        }

        private void HandleOpenLevelMenu()
        {
            _levelMenuService.Open();
            _mainMenuService.Close();
        }

        private void HandleCloseLevelMenu()
        {
            _levelMenuService.Close();
            _mainMenuService.Open();
        }
    }
}