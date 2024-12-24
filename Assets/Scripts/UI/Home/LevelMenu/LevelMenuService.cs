using UnityEngine;

namespace UI.Home.LevelMenu
{
    public class LevelMenuService : MonoBehaviour
    {
        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}