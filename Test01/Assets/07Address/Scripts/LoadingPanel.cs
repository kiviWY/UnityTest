using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _txtLoadingProgress;
    [SerializeField] private Slider _sliderLoadingProgress;


    private void Start()
    {
        LaunchMgr.Instance.RegisterProgressHandler(OnProgress);
    }
    
    private void OnProgress(float progress)
    {
        _sliderLoadingProgress.value = progress;
        _txtLoadingProgress.text = $"{progress*100}%";
    }
}
