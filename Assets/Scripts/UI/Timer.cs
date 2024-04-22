using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public float remainingTime;
    private bool isTimerEnd = false;
        
    public event Action OnTimerEnd;
    
    // Логика подсчета времени не должна быть в UI! UI должен только отображать
    void FixedUpdate()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0;
            if (!isTimerEnd)
            {
                OnTimerEnd?.Invoke();
                isTimerEnd = true;
            }
        }
        
        if (remainingTime <= 10 && remainingTime >= 0) timerText.color = Color.red;

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
