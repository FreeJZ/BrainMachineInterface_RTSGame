using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ״̬��
/// ��ʼ��״̬Ϊnull��ʹ��ʱ���ڿ�ʼʱ����ChangeState�������뿪ʼ״̬
/// </summary>
public class StateMachine
{
    private IAIInfo aiInfo;
   
    private Dictionary<Type, StateBase> stateDic;

    private StateBase curState;

    public IAIInfo AIInfo { get { return aiInfo; } }

    public StateMachine(IAIInfo owner)
    {
        this.aiInfo = owner;
        stateDic = new Dictionary<Type, StateBase>();
    }

    /// <summary>
    /// ת��״̬
    /// </summary>
    /// <typeparam name="T">״̬����</typeparam>
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

    public void ChangeState(Type type)
    {
        if (!typeof(StateBase).IsAssignableFrom(type)) Debug.LogError("type ��������StateBase��������");
        StateBase nextState = null;
        if (curState == null)
        {
            ConstructorInfo csr = type.GetConstructor(new Type[] { typeof(StateMachine) });
            nextState = csr.Invoke(new object[] { this }) as StateBase;
            stateDic.Add(type, nextState);
        }
        else
        {
            if (stateDic.ContainsKey(type)) nextState = stateDic[type];
            else
            {
                ConstructorInfo csr = type.GetConstructor(new Type[] { typeof(StateMachine) });
                nextState = csr.Invoke(new object[] { this }) as StateBase;
                stateDic.Add(type, nextState);
            }
        }

        curState?.Exit();
        curState = nextState;
        curState.Enter();
    }
     
    /// <summary>
    /// ���øú���ִ��״̬���е�״̬�߼�
    /// </summary>
    public void Update()
    {
        if(curState != null) curState.Update();
    }

    public T GetState<T>() where T : StateBase
    {
        if(stateDic.ContainsKey(typeof(T))) return stateDic[typeof(T)] as T;
        
        Type type = typeof(T);
        StateBase state = null;
        ConstructorInfo csr = type.GetConstructor(new Type[] { typeof(StateMachine) });
        state = csr.Invoke(new object[] { this }) as StateBase;
        stateDic.Add(type, state);
        return state as T;
    }

    public StateBase GetState(Type type)
    {
        if (!typeof(StateMachine).IsAssignableFrom(type)) Debug.LogError("type ���� StateBase ��������");
        if(stateDic.ContainsKey(type)) return stateDic[type];
        
        StateBase state = null;
        ConstructorInfo csr = type.GetConstructor(new Type[] { typeof(StateMachine) });
        state = csr.Invoke(new object[] { this }) as StateBase;
        stateDic.Add(type, state);
        return state;
    }
}
