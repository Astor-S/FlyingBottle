using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Home.MainMenu.PlayButtonSystem
{
    public class LevelLoader : MonoBehaviour
    {
        public IEnumerator LoadLevelAsync(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        }
    }
}