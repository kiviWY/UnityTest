using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tran2 : MonoBehaviour
{
    [SerializeField] private Transform redPoint;

    private void OnEnable()
    {
        var redNum = RedPointSystem.Instance().GetUINodeRedNum("Shop|Cell1");
        RefreshRedNum(redNum);
        RedPointSystem.Instance().AddUINode("Shop|Cell1",RefreshRedNum);
        StartCoroutine(DelteTest());
    }

    private IEnumerator DelteTest()
    {
        yield return new WaitForSeconds(3f);
        RedPointSystem.Instance().DeleteUIRedNoteRedNum("Shop|Cell1");
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
