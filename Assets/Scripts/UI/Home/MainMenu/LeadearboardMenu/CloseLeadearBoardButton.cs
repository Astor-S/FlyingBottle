using UI.Home.MainMenu.LeadearboardMenu;
using UnityEngine;

namespace UI.Home.LeadearboardMenu
{
    public class CloseLeadearBoardButton : MenuButton
    {
        [SerializeField] LeadearboardService _leadearboardService;

        public override void OnButtonClick() =>
            _leadearboardService.Close();
    }
}