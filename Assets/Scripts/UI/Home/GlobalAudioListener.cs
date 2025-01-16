using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Home
{
    public class GlobalAudioListener : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            AudioService.UpdateAllAudioSources();
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            AudioService.UpdateAllAudioSources();
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}