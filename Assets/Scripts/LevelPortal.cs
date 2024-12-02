using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
            StartCoroutine(LoadLevelAsync(_sceneToLoad));  
    }

    IEnumerator LoadLevelAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (asyncLoad.isDone == false)
        {
            yield return null; 
        }
    }
}
