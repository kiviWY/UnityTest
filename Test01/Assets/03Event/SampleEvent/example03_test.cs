using System;
using System.Collections;
using System.Collections.Generic;
using Example_03;
using UnityEngine;

public class example03_test : MonoBehaviour
{
    private void Awake()
    {
        EventManager.Instance.RegisterEvent<int>("test03", TestEvent);
    }

    private void OnEnable()
    {
        EventManager.Instance.SendEvent("test03", 1);
        StartCoroutine(TestEventUnRegister());
    }

    private IEnumerator TestEventUnRegister()
    {
        yield return new WaitForSeconds(3f);
        EventManager.Instance.UnRegisterEvent<int>("test03", TestEvent);
        EventManager.Instance.SendEvent("test03", 2);
    }


    private void TestEvent(int parm)
    {
        Debug.Log(parm);
    }
}