using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Example_02
{
    [AsyncMethodBuilder(typeof(MyTaskMethodBuilder<>))]  // 该标记用来与异步状态机 建立联系
    public class MyTask<T>
    {
       
    }


    public class Awaiter<T> : INotifyCompletion
    {
        public bool IsCompleted { get; private set; }
        public T GetResult();
        public void OmComplete(Action completion);
    }
    
    
    
    public class 
}