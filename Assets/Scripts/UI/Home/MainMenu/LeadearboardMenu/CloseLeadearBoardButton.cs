using UnityEngine;
using UI.Home.MainMenu.LeadearboardMenu;

namespace UI.Home.LeadearboardMenu
{
    public class CloseLeadearBoardButton : MenuButton
    {
        [SerializeField] private LeadearboardService _leadearboardService;

        public override void OnButtonClick() =>
            _leadearboardService.Close();
    }
}