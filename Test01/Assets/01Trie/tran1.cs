using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tran1 : MonoBehaviour
{
    [SerializeField] private Transform redPoint;

    private void OnEnable()
    {
        var redNum = RedPointSystem.Instance().GetUINodeRedNum("Shop");
        RefreshRedNum(redNum);
        RedPointSystem.Instance().AddUINode("Shop",RefreshRedNum);
    }

    private void RefreshRedNum(int num)
    {
        if (num <= 0)
        {
            this.redPoint.gameObject.SetActive(false);
        }
        else
        {
            this.redPoint.gameObject.SetActive(true);
        }
    }
    
}
