using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPopup : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPopup;
    [SerializeField] private Timer _timer;
    private LevelManager _levelManager;

    private void Awake()
    {
        _levelManager = LevelManager.Instance;
    }
    
    private void OnEnable()
    {
        _levelManager.OnGameOverProcessStart += ShowGameOverPopup;
    }

    private void OnDisable()
    {
        _levelManager.OnGameOverProcessStart -= ShowGameOverPopup;
    }
    

    private void ShowGameOverPopup()
    {
        gameOverPopup.SetActive(true);
    }
}
