using System.Collections;
using UnityEngine;

namespace PlayerControlSystem.Effects
{
    public class TrailsEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private float _trailsResetTime = 0.5f;

        private Coroutine _stopCoroutine;
        private WaitForSeconds _waitForSeconds;

        private void Awake()
        {
            _waitForSeconds = new WaitForSeconds(_trailsResetTime);
        }

        private void Start()
        {
            _particleSystem.Stop();
        }

        private void OnEnable()
        {
            _inputReader.Moving += OnPlayParticleEffect;
        }

        private void OnDisable()
        {
            _inputReader.Moving -= OnPlayParticleEffect;
        }

        private void OnPlayParticleEffect()
        {
            _particleSystem.Play();

            if (_stopCoroutine != null)
                StopCoroutine(_stopCoroutine); 
            
            _stopCoroutine = StartCoroutine(StopParticleEffectAfterDelay());
        }

        private IEnumerator StopParticleEffectAfterDelay()
        {
            yield return _waitForSeconds;

            _particleSystem.Stop();
        }
    }
}