using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 转换类
/// 连接不同状态的转换
/// </summary>
public class Transilations 
{
    private StateMachine stateMachine;
    private Dictionary<Type, Func<bool>> transDic;

    public Transilations(StateMachine stateMachine)
    {
        transDic = new Dictionary<Type, Func<bool>>();
        this.stateMachine = stateMachine;
    }

    /// <summary>
    /// 添加转换
    /// </summary>
    /// <param name="toStateType">目标状态类型</param>
    /// <param name="invokEvent">启动转换的事件</param>
    public void AddTransilation(Type toStateType,Func<bool> invokEvent)
    {
        if (toStateType == null || invokEvent == null) Debug.Log("无效操作,参数为null");
        if(!transDic.ContainsKey(toStateType))
        {
            transDic.Add(toStateType, invokEvent);
        }
    }

    /// <summary>
    /// 删除转换
    /// </summary>
    /// <param name="toStateType"></param>
    public void RemoveTransilation(Type toStateType)
    {
        if(transDic.ContainsKey(toStateType))
        {
            transDic.Remove(toStateType);
        }
    }

    public Func<bool> GetTransilation(Type toStateType)
    {
        if(transDic.ContainsKey((Type)toStateType)) return transDic[toStateType];
        return null;
    }

    /// <summary>
    /// 清空转换字典
    /// </summary>
    public void Clear()
    {
        transDic.Clear();
    }
    /// <summary>
    /// 清空转换字典除了
    /// </summary>
    /// <param name="toStateType">出去的转换</param>
    public void ClearExcept(Type toStateType)
    {
        Func<bool> invokEvent = GetTransilation(toStateType);
        Clear();
        if(invokEvent != null) transDic.Add(toStateType,invokEvent);
    }

    /// <summary>
    /// 检测转换的周期函数
    /// </summary>
    public void Update()
    {
        foreach(KeyValuePair<Type, Func<bool>> pair in transDic)
        {
            if (pair.Value != null && pair.Value())
            {
                stateMachine.ChangeState(pair.Key);
                return;
            }
        }
    }
}
