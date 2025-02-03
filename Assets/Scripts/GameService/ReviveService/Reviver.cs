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

        private Rigidbody _playerRigidbody;

        private void Awake()
        {
            FindPlayerRigidbody();
        }

        public void Revived() =>
            StartCoroutine(WaitForRevive());

        private IEnumerator WaitForRevive()
        {
            yield return null;

            if (_playerRigidbody == null)
                FindPlayerRigidbody();

            if (_playerRigidbody == null)
                yield break;
            
            yield return new WaitForSeconds(_delayTime);

            RevivePoint closestPoint = FindClosestRevivePoint();

            if (closestPoint != null)
            {
                _playerRigidbody.MovePosition(closestPoint.transform.position);
                _playerRigidbody.velocity = Vector3.zero;
                _playerRigidbody.angularVelocity = Vector3.zero;
            }
        }

        private void FindPlayerRigidbody()
        {
            if (PlayerControlSystem.LoaderService.PlayerLoader.Instance != null)
            {
                Transform playerTransform = PlayerControlSystem.LoaderService.PlayerLoader.Instance.transform;
                _playerRigidbody = playerTransform.GetComponent<Rigidbody>();
            }
        }

        private RevivePoint FindClosestRevivePoint()
        {
            if (_revivePoints.Count == 0)
                return null;

            Vector3 playerPosition;
            
            if (_playerRigidbody != null)
                playerPosition = _playerRigidbody.position;
            else
                playerPosition = PlayerControlSystem.LoaderService.PlayerLoader.Instance.transform.position;
            
            return _revivePoints.OrderBy(point =>
                (playerPosition - point.transform.position).sqrMagnitude).FirstOrDefault();
        }
    }
}