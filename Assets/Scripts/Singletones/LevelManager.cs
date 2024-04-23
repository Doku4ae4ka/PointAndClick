using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private DifferenceSpotter _differenceSpotter;
    [SerializeField] private Timer _timer;
    
    private SaveLoadManager _saveLoadManager;
    private AssetsManager _assetsManager;
    
    private int currentLevel;
    private int currentRetries;
    private bool isGamePaused;

    public event Action<bool> OnGamePaused;
    public event Action OnWinProcessStart;
    public event Action OnGameOverProcessStart;
    public event Action OnLevelReload;

    private void Awake()
    {
        _saveLoadManager = SaveLoadManager.Instance;
        _assetsManager = AssetsManager.Instance;
    }

    #region Actions
    private void OnEnable()
    {
        _differenceSpotter.OnAllDifferencesSpotted += StartWinProcess;
        _timer.OnTimerEnd += StartGameOverProcess;
        _saveLoadManager.OnDataChanged += UpdateData;
    }

    private void OnDisable()
    {
        _differenceSpotter.OnAllDifferencesSpotted -= StartWinProcess;
        _timer.OnTimerEnd -= StartGameOverProcess;
        _saveLoadManager.OnDataChanged -= UpdateData;
    }
    
    #endregion

    private void UpdateData()
    {
        currentRetries = _saveLoadManager.currentRetries;
        currentLevel = _saveLoadManager.currentLevel;
    }
    
    private void OnApplicationQuit()
    {
        UpdateData();
        _saveLoadManager.SaveToJson();
    }
    
    private void StartWinProcess()
    {
        PauseGame();
        currentLevel++;
        _saveLoadManager.currentLevel = currentLevel;
        _saveLoadManager.SaveToJson();
        OnWinProcessStart?.Invoke();
    }

    private void StartGameOverProcess()
    {
        PauseGame();
        currentRetries++;
        _saveLoadManager.currentRetries = currentRetries;
        _saveLoadManager.SaveToJson();
        OnGameOverProcessStart?.Invoke();
    }

    public void Reload()
    {
        _saveLoadManager.LoadFromJson();
        isGamePaused = true;
        PauseGame();
        OnLevelReload?.Invoke();
        SceneManager.LoadScene("Game");
        _assetsManager.isAssetsLoaded = false;
    }
    
    public void PauseGame()
    {
        isGamePaused = isGamePaused ? false : true;
        Time.timeScale = isGamePaused ? 0 : 1;
        OnGamePaused?.Invoke(isGamePaused);
    }
    
}
