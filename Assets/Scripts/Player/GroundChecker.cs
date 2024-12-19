using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private const float CheckDistance = 0.1f;
    
    private readonly RaycastHit[] _results = new RaycastHit[1];
    private readonly Vector3 _extents = new Vector3(0.45f, 0.45f, 0.45f);
    
    private LayerMask _groundMask;
    private Transform _defaultTransform;

    public void Init(LayerMask groundMask, Transform defaultTransform)
    {
        _groundMask = groundMask;
        _defaultTransform = defaultTransform;
    }

    public bool IsGrounded() =>
        IsGrounded(_defaultTransform.position, CheckDistance, out _);

    public bool IsGrounded(Vector3 center, float checkDistance, out float groundPositionY)
    {
        groundPositionY = 0f;

        int count = Physics.BoxCastNonAlloc(
            center,
            _extents,
            Vector3.down,
            _results,
            Quaternion.identity,
            checkDistance,
            _groundMask);

        if (count > 0)
        {
             groundPositionY = _results[0].point.y;
            Debug.Log($"Grounded! Hit object: {_results[0].transform.name}, Ground position Y: {groundPositionY}");
        }

        return count > 0;
    }
}