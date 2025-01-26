using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Home
{
    public class GlobalAudioListener : MonoBehaviour
    {
        private bool _isMuted = false;
        private float _previousVolume = 1f;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            AudioService.UpdateAllAudioSources();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus == false)
            {
                if (_isMuted == false)
                {
                    _isMuted = true;
                    _previousVolume = AudioListener.volume;
                    AudioListener.volume = 0;
                }
            }
            else
            {
                if (_isMuted)
                {
                    _isMuted = false;
                    AudioListener.volume = _previousVolume;
                }
            }
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode) =>
            AudioService.UpdateAllAudioSources();
    }
}