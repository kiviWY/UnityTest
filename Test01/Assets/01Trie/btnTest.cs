using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnTest : MonoBehaviour
{
   [SerializeField] private Button btnTest1;

   private void Awake()
   {
      btnTest1.onClick.AddListener(OnClickTest);
   }

   private void OnClickTest()
   {
      RedPointSystem.Instance().AddRedNode("Shop|Cell1");
   }
}
