using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPopup : MonoBehaviour
{
    [SerializeField] private GameObject winPopup;
    [SerializeField] private DifferenceSpotter _differenceSpotter;
    private LevelManager _levelManager;

    private void Awake()
    {
        _levelManager = LevelManager.Instance;
    }

    private void OnEnable()
    {
        _levelManager.OnWinProcessStart += ShowWinPopup;
    }

    private void OnDisable()
    {
        _levelManager.OnWinProcessStart -= ShowWinPopup;
    }

    private void ShowWinPopup()
    {
        winPopup.SetActive(true);
    }
    
}
