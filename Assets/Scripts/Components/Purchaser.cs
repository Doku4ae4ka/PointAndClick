using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Purchaser : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    
    public void OnPurchaseCompleted(Product product)
    {
        switch (product.definition.id)
        {
            case "com.PauldokDev.PointAndClick.buyTime":
                AddTime();
                break;
                
        }
    }

    private void AddTime()
    {
        _timer.remainingTime += 10;
    }
}
