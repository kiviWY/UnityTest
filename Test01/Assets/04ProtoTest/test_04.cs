using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_04 : MonoBehaviour
{
   private Person mPerson;

   private void Awake()
   {
      mPerson = new Person(){Age = 18, Name = "test_04"};
      
   }
}
