using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 状态机
/// 初始化状态为null，使用时需在开始时调用ChangeState函数进入开始状态
/// </summary>
public class StateMachine
{
    private IStateMachineOwner owner;
   
    private Dictionary<Type, StateBase> stateDic;

    private StateBase curState;

    public IStateMachineOwner Owner { get { return owner; } }

    public StateMachine(IStateMachineOwner owner)
    {
        this.owner = owner;
        stateDic = new Dictionary<Type, StateBase>();
    }

    /// <summary>
    /// 转换状态
    /// </summary>
    /// <typeparam name="T">状态类名</typeparam>
    public void ChangeState<T>() where T : StateBase
    {
        T nextState = default(T);
        Type type = typeof(T);
        if(curState == null)
        {
            ConstructorInfo csr = type.GetConstructor(new Type[] { typeof(StateMachine) });
            nextState = csr.Invoke(new object[] { this }) as T;
            stateDic.Add(type, nextState);
        }
        else
        {
            if(stateDic.ContainsKey(type)) nextState = stateDic[type] as T;
            else
            {
                ConstructorInfo csr = type.GetConstructor(new Type[] { typeof(StateMachine) });
                nextState = csr.Invoke(new object[] { this }) as T;
                stateDic.Add(type, nextState);
            }
        }

        curState?.Exit();
        curState = nextState;
        curState.Enter();
    }
    /// <summary>
    /// 调用该函数执行状态机中的状态逻辑
    /// </summary>
    public void Update()
    {
        if(curState != null) curState.Update();
    }
}
