using System;
using UnityEngine;

namespace UI.Home.LevelMenu
{
    public class CloseButton : MonoBehaviour, IMenuButton
    {
        public event Action OnCloseLevelMenu;
        
        public void OnButtonClick()
        {
            OnCloseLevelMenu?.Invoke();
        }

        public void OnCloseLevelButton() =>
            OnButtonClick();
    }
}