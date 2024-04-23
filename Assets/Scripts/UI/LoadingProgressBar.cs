using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour
{
    [SerializeField] private Image image;

    private void Update()
    {
        image.fillAmount = Loader.GetLoadingProgress();
    }
}
