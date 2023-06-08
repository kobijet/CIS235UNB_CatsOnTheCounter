using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private class LoadingMonoBehaviour : MonoBehaviour { }

    public enum Scene
    {
        MAIN_MENU,
        LOADING,
        GAMEPLAY,
        SCORE_SCREEN
    }

    private static UnityAction onLoaderCallback;

    public static void LoadScene(Scene scene)
    {
        // Set loader callback action to load the new scene
        onLoaderCallback = () => 
        {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));
        };

        // Load the new scene
        SceneManager.LoadScene(Scene.LOADING.ToString());
        
    }

    private static IEnumerator LoadSceneAsync(Scene scene)
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    public static void LoaderCallback()
    {
        // Triggered on first update, letting the screen refresh
        // Execute the loader callback which loads the target scene
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
