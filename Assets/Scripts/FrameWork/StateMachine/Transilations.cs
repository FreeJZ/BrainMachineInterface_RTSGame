using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ת����
/// ���Ӳ�ͬ״̬��ת��
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
    /// ���ת��
    /// </summary>
    /// <param name="toStateType">Ŀ��״̬����</param>
    /// <param name="invokEvent">����ת�����¼�</param>
    public void AddTransilation(Type toStateType,Func<bool> invokEvent)
    {
        if (toStateType == null || invokEvent == null) Debug.Log("��Ч����,����Ϊnull");
        if(!transDic.ContainsKey(toStateType))
        {
            transDic.Add(toStateType, invokEvent);
        }
    }

    /// <summary>
    /// ɾ��ת��
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
    /// ���ת���ֵ�
    /// </summary>
    public void Clear()
    {
        transDic.Clear();
    }
    /// <summary>
    /// ���ת���ֵ����
    /// </summary>
    /// <param name="toStateType">��ȥ��ת��</param>
    public void ClearExcept(Type toStateType)
    {
        Func<bool> invokEvent = GetTransilation(toStateType);
        Clear();
        if(invokEvent != null) transDic.Add(toStateType,invokEvent);
    }

    /// <summary>
    /// ���ת�������ں���
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
