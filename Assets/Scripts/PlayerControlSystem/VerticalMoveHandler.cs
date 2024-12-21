using System;
using UnityEngine;

[Serializable]
public class VerticalMoveHandler
{
    [SerializeField] private AnimationCurve _moveUp;
    [SerializeField] private AnimationCurve _moveDown;
    [SerializeField] private float _speed = 1f;

    private Transform _transform;
    
    public bool IsFall { get; private set; }

    public void Init(Transform transform)
    {
        _transform = transform;
    }

    public void Reset()
    {
        IsFall = false;
    }
    
    public float CalculateHeight(float maxHeight, float normalizeTime, float groundPositionY)
    {
        var (direction, curve) = GetMoveData(maxHeight);
        
        if (IsFall)
        {
            normalizeTime -= 0.5f;
        }
        
        float time = normalizeTime / 0.5f;
        
        var height = curve.Evaluate(time) * _speed * direction * Time.deltaTime;

        if (_transform.position.y + height <= groundPositionY && IsFall)
            height = _transform.position.y - groundPositionY;
        
        return height;
    }

    private (int direction, AnimationCurve curve) GetMoveData(float maxHeight)
    {
        if (IsFall == false)
        {
            if (_transform.position.y >= maxHeight)
            {
                IsFall = true;
            }
            else
            {
                return (1, _moveUp);
            }
        }
        
        return (-1, _moveDown);
    }
}