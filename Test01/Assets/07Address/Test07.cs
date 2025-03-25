using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class Test07 : MonoBehaviour
{
    [SerializeField] private List<AssetReference> imgAssets;
    
    
    [SerializeField] private Image mImg1;
    [SerializeField] private Image mImg2;
    [SerializeField] private Image mImg3;
    [SerializeField] private Button mBtn1;
    [SerializeField] private Button mBtn2;
    [SerializeField] private Button mBtn3;


    private void Awake()
    {
        // 3个按钮绑定方法
        mBtn1.onClick.AddListener(Btn1Click);
        mBtn2.onClick.AddListener(Btn2Click);
        mBtn3.onClick.AddListener(Btn3Click);
    }

    private void Btn1Click()
    {
       
    }

    private void Btn2Click()
    {
       
    }

    private void Btn3Click()
    {
        
    }



    IEnumerator DownloadSprite(int index)
    {
        var handle = Addressables.DownloadDependenciesAsync(imgAssets[index]);
        handle.Completed+=ImgDownloadComplete;
        while (!handle.IsDone)
        {
            var status = handle.GetDownloadStatus();
            float progress = status.Percent;
            yield return null;
        }
    }

    private void ImgDownloadComplete(AsyncOperationHandle handle)
    {
        
    }
}
