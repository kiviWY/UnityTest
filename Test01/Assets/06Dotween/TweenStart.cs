using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TweenStart : MonoBehaviour
{
    private void Awake()
    {
        DOTween.Init(recycleAllByDefault: true,useSafeMode:true,LogBehaviour.ErrorsOnly).SetCapacity(300,100);
    }
}
