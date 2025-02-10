using UnityEngine;

namespace UI.Home
{
    public class MenuService : MonoBehaviour
    {
        public void Open() =>
            gameObject.SetActive(true);

        public void Close() =>
            gameObject.SetActive(false);
    }
}