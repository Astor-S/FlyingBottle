using System;
using UnityEngine;

namespace UI.Home.MainMenu
{
    public class SelectLevel : MonoBehaviour, IMenuButton
    {
        public event Action OnOpenLevelMenu;

        public void OnButtonClick()
        {
            OnOpenLevelMenu?.Invoke();
        }

        public void OnSelectLevelButton() =>
            OnButtonClick();
    }
}