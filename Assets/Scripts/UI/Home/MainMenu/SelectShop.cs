using System;
using UnityEngine;

namespace UI.Home.MainMenu
{
    public class SelectShop : MonoBehaviour, Interfaces.IMenuButton
    {
        public event Action OnOpenShop;

        public void OnButtonClick() =>
            OnOpenShop?.Invoke();
    }
}