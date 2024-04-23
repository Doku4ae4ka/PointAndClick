using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private class LoadingMonoBehavior : MonoBehaviour { }
    public enum Scene
    {
        Game,
        Bootstrap,
        Loading
        
    }

    public static Action OnLoaderCallback;

    private static AsyncOperation loadingAsyncOperation;
    
    public static void Load(Scene scene)
    {
        OnLoaderCallback = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehavior>().StartCoroutine(LoadSceneAsync(scene));
            SceneManager.LoadSceneAsync(scene.ToString());
        };
            
        
        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    private static IEnumerator LoadSceneAsync(Scene scene)
    {
        yield return null;

        loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());
        
        while (!loadingAsyncOperation.isDone)
        {
            yield return null;
        }
        
    }
    
    public static float GetLoadingProgress()
    {
        if (loadingAsyncOperation != null)
        {
            return loadingAsyncOperation.progress;
        }
        else
        {
            return 1f;
        }
    }

    public static void LoaderCallback()
    {
        if (OnLoaderCallback != null)
        {
            OnLoaderCallback();
            OnLoaderCallback = null;
        }
    }
}
