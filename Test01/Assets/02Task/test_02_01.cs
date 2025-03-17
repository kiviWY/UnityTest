using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class test_02_01 : MonoBehaviour
{
    private void Awake()
    {
        
        Console.WriteLine();
    }


    public async Task<int> CalculateAsync()
    {
        int a = await Task.Run(() => 10);
        int b = await Task.Run(() => 20);
        return a + b;
    }
}
