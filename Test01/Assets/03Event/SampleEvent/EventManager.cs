using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Example_03
{

    
    
    
    
    

    public class EventManager : SingleTonBase<EventManager>
    {
        private Dictionary<string, Action<object>> mDic = new Dictionary<string, Action<object>>();

        /// <summary>
        /// 注册事件
        /// </summary>
        public void RegisterEvent(string eventName, Action<object> callback)
        {
            Action<object> tempEvent = null;
            if (mDic.ContainsKey(eventName))
            {
                mDic[eventName] += callback;
            }
            // if (mDic.TryGetValue(eventName, out tempEvent))   
            // { 
            //     tempEvent += callback;   // 这里的赋值无效
            // }
            else
            {
                mDic.Add(eventName, callback);
            }
        }

        public void UnRegisterEvent(string eventName, Action<object> callback)
        {
            // Action<object> tempEvent = null;
            // if (mDic.TryGetValue(eventName, out tempEvent))
            // {
            //     tempEvent -= callback;
            // }

            if (mDic.ContainsKey(eventName))
            {
                mDic[eventName] -= callback;
            }
        }

        public void SendEvent(string eventName, object param = null)
        {
            Action<object> tempEvent = null;
            if (mDic.TryGetValue(eventName, out tempEvent))
            {
                tempEvent?.Invoke(param);
            }
        }
    }
}
