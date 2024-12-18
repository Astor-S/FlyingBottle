using UnityEngine;

public class FallService : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private FallHandler _fallHandler;

    private void Awake()
    {
        _groundChecker.Init(_groundLayer, transform);
    }

    private void Update()
    {
            TryFall();   
    }

    private bool TryFall()
    {
        if (_groundChecker.IsGrounded())
        {
            return false;
        }

        _fallHandler.Play();

        return true;
    }
}