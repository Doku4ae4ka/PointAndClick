using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class AssetsManager : Singleton<AssetsManager>
{
    public bool isAssetsLoaded = false;
    private bool isGameScene = false;

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game" && !isAssetsLoaded) isGameScene = true;
        else isGameScene = false;
        
        if (isGameScene)
        {
            LoadAssets();
            isAssetsLoaded = true;
        }
        
    }


    public void LoadAssets()
    {
        AsyncOperationHandle<GameObject> asyncOperationHandle = 
            Addressables.LoadAssetAsync<GameObject>("LevelKitchen");

        asyncOperationHandle.Completed += AsyncOperationHandle_Completed;
    }

    public void AsyncOperationHandle_Completed(AsyncOperationHandle<GameObject> asyncOperationHandle)
    {
        if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(asyncOperationHandle.Result);
        }
    }
}
