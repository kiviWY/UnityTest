using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GenericTest : MonoBehaviour
{
    [SerializeField] private Transform cube;

    private float tempValue=0;
    
    public Vector3 getCubeTransform()
    {
        return cube.transform.position;
    }

    public void setCubeTransform(Vector3 vec3)
    {
        this.cube.transform.position = vec3;
    }


    private void Start()
    {
        DOTween.To(() => getCubeTransform(), x => setCubeTransform(x), new Vector3(10, 10, 10), 2f);
        DOTween.To(()=>tempValue,x=>tempValue=x,200f,2f);
    }

    private void Update()
    {
        Debug.Log(tempValue);
    }
}
