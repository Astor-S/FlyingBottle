using UnityEngine;

namespace UI.Screens.LevelScreens
{
    public class TutorialScreen : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Close()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}