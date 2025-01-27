using UI.Home.MainMenu.LeadearboardMenu;
using UnityEngine;

namespace UI.Home.LeadearboardMenu
{
    public class CloseLeadearBoardButton : MonoBehaviour, Interfaces.IMenuButton
    {
        [SerializeField] LeadearboardService _leadearboardService;

        public void OnButtonClick() =>
            _leadearboardService.Close();
    }
}