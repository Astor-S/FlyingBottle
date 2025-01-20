using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameService.ReviveService
{
    public class Reviver : MonoBehaviour
    {
        [SerializeField] private List<RevivePoint> _revivePoints = new List<RevivePoint> ();
        [SerializeField] private Transform _playerTransform;

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