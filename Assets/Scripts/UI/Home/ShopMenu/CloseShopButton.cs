using System;
using UnityEngine;

namespace UI.Home.ShopMenu
{
    public class CloseShopButton : MonoBehaviour, Interfaces.IMenuButton
    {
        public event Action OnCloseShop;

        public void OnButtonClick() =>
            OnCloseShop?.Invoke();
    }
}