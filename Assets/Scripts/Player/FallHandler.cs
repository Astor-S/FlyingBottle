using System.Threading;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class FallHandler : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private readonly float _speedFall = 3f;
    [SerializeField] private readonly float _speedFallMultiplier = 9.8f;

    //private void Awake()
    //{
    //    _groundChecker.Init(_groundLayer, transform);
    //}

    //private void Update()
    //{
    //    bool isGrounded = _groundChecker.IsGrounded();

    //    if (isGrounded)
    //    {
    //        Debug.Log("Player is grounded");
    //    }
    //}

    //public async void Play()
    //{
    //    Func<float, Vector3> calculatePosition;
    //    Func<bool> whileCondition;
    //    Action endCallback;

    //}

    //private async UniTask Fall(Func<float, Vector3> calculatePosition, Func<bool> whileCondition, CancellationToken cancellationToken)
    //{
    //    float speed = _speedFall;

    //    while (whileCondition())
    //    {
    //        float delta = (speed += _speedFallMultiplier) * Time.fixedDeltaTime;
    //        Position = calculatePosition(delta);

    //        await UniTask.WaitForFixedUpdate(cancellationToken);
    //    }
    //}

    //private (Func<float, Vector3> calculatePosition, Func<bool> whileCondition, Action endCallback)

    //    GetFallIntoGroundData(float groundPositionY) =>
    //    (delta) =>
    //    {
    //        Vector3 position = Position;

    //        if (position.y - delta < groundPositionY)
    //            position.y = groundPositionY;
    //        else
    //            position.y -= delta;


    //        return position;
    //    },
    //    () => _groundChecker.IsGrounded() is false && groundPositionY < Position.y);
}

    //public async void StartFalling()
    //{
    //    float groundPositionY;

    //    if (!CanFallToGround(out groundPositionY))
    //    {
    //        Func<float, Vector3> calculatePositionFunc = GetFallIntoGroundData(groundPositionY);
    //        Func<bool> whileConditionFunc = () => !_groundChecker.IsGrounded(_cubeEntity.position, Mathf.Infinity, out groundPositionY) && Position.y > groundPositionY;
    //        CancellationTokenSource cts = new CancellationTokenSource();


    //        await Fall(calculatePositionFunc, whileConditionFunc, cts.Token);

    //        //Trigger a transition to control state
    //        _cubeStateMachine.EnterIn(ControlState);
    //    }
    //}