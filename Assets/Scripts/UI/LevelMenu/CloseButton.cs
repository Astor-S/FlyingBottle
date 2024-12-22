using UnityEngine;

namespace UI.LevelMenu
{
    public class CloseButton : MonoBehaviour
    {
        [SerializeField] LevelMenuService _levelMenuService;
        [SerializeField] MainMenu.MainMenuService _mainMenuService;

        public void OnCloseLevelButton()
        {
            _levelMenuService.Close();
            _mainMenuService.Open();
        }
    }
}