using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    
    public void StartTheGame()
    {
        Loader.Load(Loader.Scene.Game);
    }
    
}
