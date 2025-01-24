using System;
using UnityEngine;

namespace UI.Home.LeadearboardMenu
{
    public class CloseLeadearBoardButton : MonoBehaviour, Interfaces.IMenuButton
    {
        public event Action OnCloseLeadearboard;

        public void OnButtonClick() =>
            OnCloseLeadearboard?.Invoke();
    }
}