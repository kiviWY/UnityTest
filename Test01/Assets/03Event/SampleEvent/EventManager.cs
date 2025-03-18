using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Example_03
{

    public interface IRegister
    {
    }

    public class RegisterFunc : IRegister
    {
        public Action callBack=null;
    }

    public class RegisterFunc<T> : IRegister
    {
        public Action<T> callBack=null;
    }


    public class RegisterFunc<T, K> : IRegister
    {
        public Action<T, K> callBack=null;
    }



    public class EventManager : SingleTonBase<EventManager>
    {
        private Dictionary<string, IRegister> mDic = new Dictionary<string, IRegister>();

        /// <summary>
        /// 注册事件
        /// </summary>
        public void RegisterEvent<T>(string eventName, Action<T> callback)
        {
            if (mDic.ContainsKey(eventName))
            {
                (mDic[eventName] as RegisterFunc<T>).callBack += callback;
            }
            // if (mDic.TryGetValue(eventName, out tempEvent))   
            // { 
            //     tempEvent += callback;   // 这里的赋值无效
            // }
            else
            {
                mDic[eventName] = new RegisterFunc<T>();
                (mDic[eventName] as RegisterFunc<T>).callBack = callback;
            }
        }
        
        
        public void RegisterEvent<T,K>(string eventName, Action<T,K> callback)
        {
            if (mDic.ContainsKey(eventName))
            {
                (mDic[eventName] as RegisterFunc<T,K>).callBack += callback;
            }
            // if (mDic.TryGetValue(eventName, out tempEvent))   
            // { 
            //     tempEvent += callback;   // 这里的赋值无效
            // }
            else
            {
                mDic[eventName] = new RegisterFunc<T,K>();
                (mDic[eventName] as RegisterFunc<T,K>).callBack = callback;
            }
        }

        public void UnRegisterEvent(string eventName, Action callback)
        {
            // Action<object> tempEvent = null;
            // if (mDic.TryGetValue(eventName, out tempEvent))
            // {
            //     tempEvent -= callback;
            // }

            if (mDic.ContainsKey(eventName))
            {
                (mDic[eventName] as RegisterFunc).callBack -= callback;
            }
        }
        
        

        public void UnRegisterEvent<T>(string eventName, Action<T> callBack)
        {
            if (mDic.ContainsKey(eventName))
            {
                if ((mDic[eventName] as RegisterFunc<T>).callBack != null)
                {
                    (mDic[eventName] as RegisterFunc<T>).callBack -= callBack;
                }
            }
        }

        public void UnRegisterEvent<T, K>(string eventName, Action<T, K> callBack)
        {
            if (mDic.ContainsKey(eventName))
            {
                if ((mDic[eventName] as RegisterFunc<T, K>).callBack != null)
                {
                    (mDic[eventName] as RegisterFunc<T, K>).callBack -= callBack;
                }
            }
        }

        public void SendEvent(string eventName)
        {
            IRegister func = null;
            if (mDic.TryGetValue(eventName, out func))
            {
                (func as RegisterFunc).callBack?.Invoke();
            }
        }
        
        public void SendEvent<T>(string eventName, T parm)
        {
            IRegister func = null;
            if (mDic.TryGetValue(eventName, out func))
            {
                (func as RegisterFunc<T>).callBack?.Invoke(parm);
            }
        }

        public void SendEvent<T, K>(string eventName, T parm)
        {
            IRegister func = null;
            if (mDic.TryGetValue(eventName, out func))
            {
                (func as RegisterFunc<T>).callBack?.Invoke(parm);
            }
        }
    }
}
