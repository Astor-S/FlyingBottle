using UnityEngine;

namespace UI.Screens.LevelScreens.ScreenButtons
{
    public class AcceptTutorialButton : MonoBehaviour
    {
        [SerializeField] private TutorialScreen _tutorialScreen;
        
        public void OnButtonClick() =>
            _tutorialScreen.Close();
    }
}