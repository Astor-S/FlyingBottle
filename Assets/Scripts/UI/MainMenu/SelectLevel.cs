using UnityEngine;

namespace UI.MainMenu
{
    public class SelectLevel : MonoBehaviour
    {
        [SerializeField] LevelMenu.LevelMenuService _levelMenuService;
        [SerializeField] MainMenuService _mainMenuService;

        public void OnSelectLevelButton()
        {
            _levelMenuService.Open();
            _mainMenuService.Close();
        }
    }
}