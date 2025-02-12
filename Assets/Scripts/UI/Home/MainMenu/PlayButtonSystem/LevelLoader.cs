using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Home.MainMenu.PlayButtonSystem
{
    public class LevelLoader : MonoBehaviour
    {
        public IEnumerator LoadLevelAsync(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            while (asyncLoad.isDone == false)
            {
                yield return null;
            }
        }
    }
}