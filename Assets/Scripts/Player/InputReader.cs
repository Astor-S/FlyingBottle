using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _moveKey = KeyCode.Space;

    public event Action Moved;

    private void Update()
    {
        if (Input.GetKeyDown(_moveKey))
            Moved?.Invoke();
    }
}