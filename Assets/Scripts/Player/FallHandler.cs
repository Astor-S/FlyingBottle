using System;
using System.Collections;
using UnityEngine;

public class FallHandler : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speedFall = 1f;
    [SerializeField] private float _speedFallMultiplier = 9.8f;
    [SerializeField] private float _groundCheckDistanceForFall = 2f;

    private Vector3 _position;

    private Vector3 Position
    {
        get => _position;
        set => _position = value;
    }

    private void Awake()
    {
        _groundChecker.Init(_groundLayer, transform);
        _position = transform.position;
    }

    private void Update()
    {
        bool isGrounded = _groundChecker.IsGrounded();

        if (isGrounded)
        {
            Debug.Log("Player is grounded");
        }
    }

    public void Play()
    {
        StartCoroutine(Falling());
    }

    private IEnumerator Falling()
    {
        float groundPositionY;
        
        if (_groundChecker.IsGrounded(transform.position, _groundCheckDistanceForFall, out groundPositionY) == false)
        {
            yield break;
        }

        (Func<float, Vector3> calculatePosition, Func<bool> whileCondition) = GetFallIntoGroundData(groundPositionY);
        float speed = _speedFall;

        float time = 0;

        while (whileCondition())
        {
            time += Time.fixedDeltaTime;
            float delta = (_speedFall + _speedFallMultiplier * time) * Time.fixedDeltaTime;
            Position = calculatePosition(delta);
            transform.position = Position;

            yield return new WaitForFixedUpdate();
        }
    }


    private (Func<float, Vector3> calculatePosition, Func<bool> whileCondition)
        GetFallIntoGroundData(float groundPositionY) =>
        (
            (delta) =>
            {
                Vector3 position = Position;
                if (position.y - delta < groundPositionY)
                    position.y = groundPositionY;
                else
                    position.y -= delta;

                return position;
            },
            () => groundPositionY < Position.y
        );
}