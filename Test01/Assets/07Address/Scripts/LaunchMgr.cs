using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public delegate void ProgressHandler(float progress);
public class LaunchMgr : MonoBehaviour
{
    private static LaunchMgr _instance;
    
    private ProgressHandler _progressHandler;
    
    
    private void Awake()
    {
        _instance = this;
    }

    public static LaunchMgr Instance => _instance;


    public void RegisterProgressHandler(ProgressHandler handler)
    {
        _progressHandler = handler;
    }

    IEnumerator Start()
    {
        Init();
        yield return InitAddressable();
        yield return LoadAddressableAsset();
        _progressHandler(1);
        yield return new WaitForSeconds(0.5f);
        yield return LoadGameScene();
    }

// 初始化
    private void Init()
    {
        _progressHandler(0);
        // todo 做一些基本工作
    }

    private IEnumerator InitAddressable()
    {
       var initOperation = Addressables.InitializeAsync();
       yield return initOperation;
       if (initOperation.Status == AsyncOperationStatus.Succeeded)
       {
           Debug.Log("Addressable inited");
       }
    }

// todo 加载数据并同步进度条
    private IEnumerator LoadAddressableAsset()
    {
        yield return null;
    }


// todo 加载完成数据后进入游戏界面
    private IEnumerator LoadGameScene()
    {
        yield return null;
    }
}