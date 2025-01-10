using UnityEngine;

public class FinishPortal : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            player.gameObject.SetActive(false);   
    }
}