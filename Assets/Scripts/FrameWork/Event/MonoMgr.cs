using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoMgr : MonoSingleton<MonoMgr>
{
    private UnityAction updateEvents;
    private UnityAction fixedUpdateEvents;
    private UnityAction lateUpdateEvents;

    private void FixedUpdate()
    {
        fixedUpdateEvents?.Invoke();
    }

    private void Update()
    {
        updateEvents?.Invoke();
    }

    private void LateUpdate()
    {
        lateUpdateEvents?.Invoke();
    }

    public void AddUpdateEvent(UnityAction action)
    {
        updateEvents += action;
    }

    public void RemoveUpdateEvent(UnityAction action) 
    {
        updateEvents -= action;
    }


    public void AddFixedUpdateEvent(UnityAction action)
    {
        fixedUpdateEvents += action;
    }

    public void RemoveFixedUpdateEvent(UnityAction action)
    {
        fixedUpdateEvents -= action;
    }

    public void AddLateUpdateEvent(UnityAction action)
    {
        lateUpdateEvents += action;
    }

    public void RemoveLateUpdateEvent(UnityAction action)
    {
        lateUpdateEvents -= action;
    }
}
