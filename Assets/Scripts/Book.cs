using UnityEngine;

public class Book : MonoBehaviour 
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void WakeUp()
    {
        _rigidbody.WakeUp();
    }
}