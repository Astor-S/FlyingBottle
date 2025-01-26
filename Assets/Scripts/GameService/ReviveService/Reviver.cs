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

        private void Awake()
        {
            FindPlayerTransform();
        }

        public void Revived() =>
            StartCoroutine(WaitForPlayerAndRevive());

        private IEnumerator WaitForPlayerAndRevive()
        {
            while (_playerTransform == null)
            {
                FindPlayerTransform();

                if (_playerTransform != null)
                    break;

                yield return null; 
            }

            RevivePoint closestPoint = FindClosestRevivePoint();

            if (closestPoint != null)
                _playerTransform.position = closestPoint.transform.position;
        }

        private void FindPlayerTransform()
        {
            if (PlayerControlSystem.LoaderService.PlayerLoader.Instance != null)
                _playerTransform = PlayerControlSystem.LoaderService.PlayerLoader.Instance.transform;    
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