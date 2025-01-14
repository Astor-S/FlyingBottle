using UnityEngine;

namespace Objects
{
    public class FinishPortal : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerControlSystem.Player player))
                player.gameObject.SetActive(false);
        }
    }
}