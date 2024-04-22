using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelRetriesView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelCounter;
    [SerializeField] private TextMeshProUGUI retriesCounter;
    
    private LevelManager _levelManager;
    private SaveLoadManager _saveLoadManager;

    private void Awake()
    {
        _levelManager = LevelManager.Instance;
        _saveLoadManager = SaveLoadManager.Instance;
    }
    
    private void OnEnable()
    {
        _saveLoadManager.OnDataChanged += ChangeCounters;
    }

    private void OnDisable()
    {
        _saveLoadManager.OnDataChanged -= ChangeCounters;
    }
    
    private void ChangeCounters()
    {
        ChangeLevelCounter();
        ChangeRetriesCounter();
    }
    
    private void ChangeLevelCounter()
    {
        levelCounter.text = string.Format("Level: {0}", _saveLoadManager.currentLevel);
    }
    
    private void ChangeRetriesCounter()
    {
        retriesCounter.text = string.Format("Retries: {0}", _saveLoadManager.currentRetries);
    }

}
