using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class AppodealManager : Singleton<AppodealManager>, IAppodealInitializationListener
{
    private const string APP_KEY = "19fd0e223c28b110b99e86b7bc9ea1e49604d5beed93f866";

    private LevelManager _levelManager; //Почему AppodealManager должен иметь доступ к LevelManagerу?

    [SerializeField] private bool testingMode;

    private void Awake()
    {
        _levelManager = LevelManager.Instance;
        Initialized();
    }

    private void OnEnable()
    {
        _levelManager.OnLevelReload += ShowInterAds;
    }

    private void OnDisable()
    {
        _levelManager.OnLevelReload -= ShowInterAds;
    }

    private void Initialized()
    {
        Appodeal.setTesting(testingMode);
        
        Appodeal.disableLocationPermissionCheck();
        
        Appodeal.muteVideosIfCallsMuted(true);
        
        Appodeal.cache(Appodeal.INTERSTITIAL);
        
        int adTypes = Appodeal.INTERSTITIAL;
        Appodeal.initialize(APP_KEY, adTypes, this);
    }
    
    public void onInitializationFinished(List<string> errors) {}

    private void ShowInterAds()
    {
        if (Appodeal.canShow(Appodeal.INTERSTITIAL) && Appodeal.isLoaded(Appodeal.INTERSTITIAL))
        {
            Appodeal.show(Appodeal.INTERSTITIAL);
        }
    }
}
