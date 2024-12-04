using UnityEngine;

public class ShelfBreakerJoint : MonoBehaviour
{
    [SerializeField] private HingeJoint _hingeJoint;
    [SerializeField] private float _breakAngle = 30f;
    [SerializeField] private float _breakTorque = 100f;

    private JointLimits _limits;
    private bool _broken = false;

    private void Start()
    {
        transform.localRotation = Quaternion.identity;

        _limits = _hingeJoint.limits;
        _hingeJoint.useMotor = false;
        _hingeJoint.useLimits = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _) && _broken == false)
        {
            _broken = true; 
            _limits.max = _breakAngle;
            _hingeJoint.limits = _limits;
            _hingeJoint.useLimits = true;
            _hingeJoint.useMotor = true;
            _hingeJoint.motor = new JointMotor { targetVelocity = _breakAngle, force = _breakTorque };
            enabled = false; 
        }
    }
}