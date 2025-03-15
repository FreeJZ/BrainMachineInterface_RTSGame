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
    /// <summary>
    /// ���øú���ִ��״̬���е�״̬�߼�
    /// </summary>
    public void Update()
    {
        if(curState != null) curState.Update();
    }
}
