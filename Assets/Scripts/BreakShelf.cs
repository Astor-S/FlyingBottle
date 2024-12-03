using UnityEngine;

public class BreakShelf : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _breakAnimationTrigger = "Break";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _)) 
            _animator.SetTrigger(_breakAnimationTrigger); 
    }
}