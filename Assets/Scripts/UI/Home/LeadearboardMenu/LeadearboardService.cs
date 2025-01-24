using UI.Home.Interfaces;
using UnityEngine;

namespace UI.Home.LeadearboardMenu
{
    public class LeadearboardService : MonoBehaviour, IMenuService
    {
        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }
    }
}