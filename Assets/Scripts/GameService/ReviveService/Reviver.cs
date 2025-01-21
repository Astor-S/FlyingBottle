using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameService.ReviveService
{
    public class Reviver : MonoBehaviour
    {
        [SerializeField] private List<RevivePoint> _revivePoints = new List<RevivePoint> ();
        
        private Transform _playerTransform;

        private void Start()
        {
            StartCoroutine(WaitForPlayer());
        }

        private IEnumerator WaitForPlayer()
        {
            while (PlayerControlSystem.LoaderService.PlayerLoader.Instance == null)
            {
                yield return null;
            }

            _playerTransform = PlayerControlSystem.LoaderService.PlayerLoader.Instance.transform;
        }

        public void Revived()
        {
            RevivePoint closestPoint = FindClosestRevivePoint();

            _playerTransform.position = closestPoint.transform.position;
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