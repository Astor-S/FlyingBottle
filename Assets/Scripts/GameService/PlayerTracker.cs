using UnityEngine;
using System.Collections;
using PlayerControlSystem;
using PlayerControlSystem.LoaderService;

namespace GameService
{
    public class PlayerTracker : MonoBehaviour
    {
        [SerializeField] private PlayerControlSystem.LoaderService.PlayerLoader _playerLoader;
        [SerializeField] private float _xOffset;

        private Player _player;

        private void Start()
        {
            StartCoroutine(WaitForPlayer());
        }

        private void Update()
        {
            if (_player != null)
            {
                Vector3 position = transform.position;
                position.x = _player.transform.position.x + _xOffset;
                transform.position = position;
            }
        }

        private IEnumerator WaitForPlayer()
        {
            while (PlayerLoader.Instance == null)
            {
                yield return null;
            }

            _player = PlayerLoader.Instance;
        }
    }
}