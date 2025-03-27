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

    [SerializeField] private Text mTxt;


    private void Awake()
    {
        // 3个按钮绑定方法
        mBtn1.onClick.AddListener(Btn1Click);
        mBtn2.onClick.AddListener(Btn2Click);
        mBtn3.onClick.AddListener(Btn3Click);
    }

    private void Btn1Click()
    {
       Addressables.LoadAssetAsync<Sprite>(imgAssets[0]).Completed += (op) =>
       {
           mImg1.sprite = op.Result;
       };
    }

    private void Btn2Click()
    {
        Addressables.LoadAssetAsync<Sprite>(imgAssets[1]).Completed += (op) =>
        {
            mImg2.sprite = op.Result;
        };
    }

    private void Btn3Click()
    {
        Addressables.LoadAssetAsync<Sprite>(imgAssets[2]).Completed += (op) =>
        {
            mImg3.sprite = op.Result;
        };
    }



   
}
