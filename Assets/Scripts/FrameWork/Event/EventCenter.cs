using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBase { }

public class Event : EventBase
{
    public UnityAction action;
    public Event(UnityAction action)
    {
        this.action = action;
    }
}

public class Event<T> : EventBase
{
    public UnityAction<T> action;
    public Event( UnityAction<T> action )
    {
        this.action = action;
    }
}

public class Event<T,k> : EventBase
{
    public UnityAction<T,k> action;
    public Event(UnityAction<T,k> action)
    {
        this.action = action;
    }
}

public class EventCenter : Singleton<EventCenter>
{
    private Dictionary<string,EventBase> eventDic = new Dictionary<string, EventBase>();
    private EventCenter()
    {
    }

    public void AddEventListener(string name, UnityAction action)
    {
        if(eventDic.ContainsKey(name))
        {
            (eventDic[name] as Event).action += action;
        }
        else
        {
            eventDic.Add(name, new Event(action));
        }
    }

    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as Event<T>).action += action;
        }
        else
        {
            eventDic.Add(name, new Event<T>(action));
        }
    }

    public void AddEventListener<T,K>(string name, UnityAction<T,K> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as Event<T,K>).action += action;
        }
        else
        {
            eventDic.Add(name, new Event<T,K>(action));
        }
    }

    /// <summary>
    /// 删除事件集合
    /// </summary>
    /// <param name="name">事件集合的枚举名</param>
    public void RemoveEventListener(string name)
    {
        if(eventDic.ContainsKey(name)) eventDic.Remove(name);
    }
    /// <summary>
    /// 删除事件集合中的子事件
    /// </summary>
    /// <param name="name">事件集合的枚举名</param>
    /// <param name="action">子事件</param>
    public void RemoveEventListener(string name,UnityAction action)
    {
        if(eventDic.ContainsKey(name))
        {
            (eventDic[name] as Event).action -= action; 
        }
    }

    public void RemoveEventListener<T>(string name,UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as Event<T>).action -= action;
        }
    }

    public void RemoveEventListener<T,K>(string name, UnityAction<T,K> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as Event<T,K>).action -= action;
        }
    }

    public void Clear()
    {
        eventDic.Clear();   
    }

    public void Invoke(string name)
    {
        if (eventDic[name] is not Event) Debug.LogError("传入的泛型类型不匹配");
        if (eventDic.ContainsKey(name)) (eventDic[name] as Event).action.Invoke();
        else Debug.LogError("name 事件不存在");
    }

    public void Invoke<T>(string name,T val)
    {
        if (eventDic[name] is not Event<T>) Debug.LogError("传入的泛型类型不匹配");
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as Event<T>).action.Invoke(val);
        }
        else Debug.LogError("name 事件不存在");
    }

    public void Invoke<T,K>(string name, T val1,K val2)
    {
        if (eventDic[name] is not Event<T,K>) Debug.LogError("传入的泛型类型不匹配");
        if (eventDic.ContainsKey(name)) (eventDic[name] as Event<T,K>).action.Invoke(val1,val2);
        else Debug.LogError("name 事件不存在");
    }
}
