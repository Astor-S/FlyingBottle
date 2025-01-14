using UnityEngine;

namespace Objects
{
    public class Book : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Reawaken()
        {
            _rigidbody.WakeUp();
        }
    }
}