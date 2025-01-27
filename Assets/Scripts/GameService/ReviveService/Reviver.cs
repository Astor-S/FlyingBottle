using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameService.ReviveService
{
    public class Reviver : MonoBehaviour
    {
        [SerializeField] private List<RevivePoint> _revivePoints = new List<RevivePoint> ();
        [SerializeField] private float _delayTime = 0.1f;

        private Transform _playerTransform;
        private Rigidbody _playerRigidbody;

        private void Awake()
        {
            FindPlayerTransform();
        }

        public void Revived() =>
            StartCoroutine(WaitForRevive());

        private IEnumerator WaitForRevive()
        {
            yield return null;
            
            if (_playerTransform == null)
                FindPlayerTransform();

            if (_playerTransform == null)
                yield break;
            

            yield return new WaitForSeconds(_delayTime);

            RevivePoint closestPoint = FindClosestRevivePoint();

            if (closestPoint != null)
            {
                if (_playerRigidbody != null)
                    _playerRigidbody.MovePosition(closestPoint.transform.position);
                else
                    _playerTransform.position = closestPoint.transform.position;
            }
        }

        private void FindPlayerTransform()
        {
            if (PlayerControlSystem.LoaderService.PlayerLoader.Instance != null)
            {
                _playerTransform = PlayerControlSystem.LoaderService.PlayerLoader.Instance.transform;
                _playerRigidbody = _playerTransform.GetComponent<Rigidbody>();
            }
        }

        private RevivePoint FindClosestRevivePoint()
        {
            if (_revivePoints.Count == 0)
                return null;

            return _revivePoints.OrderBy(point =>
                (_playerTransform.position - point.transform.position).sqrMagnitude).FirstOrDefault();
        }
    }
}