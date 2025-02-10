namespace UI.Home.TypesServiceMenus
{
    public class InitiallyInactiveService : MenuService
    {
        private void Awake()
        {
            gameObject.SetActive(false);
        }
    }
}