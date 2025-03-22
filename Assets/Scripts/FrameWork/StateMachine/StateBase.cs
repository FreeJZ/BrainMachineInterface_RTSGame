using System;
using UnityEngine;

/// <summary>
/// 状态基类
/// 所有状态派生自它
/// </summary>
public abstract class StateBase
{
    protected StateMachine stateMachine;
    protected Transilations transilations;
    public StateMachine StateMachine=>stateMachine;
    
    public StateBase() { }
    public StateBase(StateMachine stateMachine)
    {
        transilations = new Transilations(stateMachine);
        Init(stateMachine);
    }

    /// <summary>
    /// 初始化函数
    /// 1.添加转换条件
    /// 2.初始化状态机
    /// </summary>
    public virtual void Init(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    /// <summary>
    /// 添加转换
    /// </summary>
    /// <param name="toStateType">目标状态类型</param>
    /// <param name="invokeEvent">启动转换的事件</param>
    protected void AddTransilation(Type toStateType,Func<bool> invokeEvent)
    {
        transilations.AddTransilation(toStateType, invokeEvent);
    }

    /// <summary>
    /// 添加转换
    /// 用于动态链接状态
    /// </summary>
    /// <param name="toStateType">目标状态类型</param>
    /// <param name="invokeEvent">启动转换的事件</param>
    public void AddTransilation(Type toStateType,Func<IAIInfo,bool> invokeEvent)
    {
        AddTransilation(toStateType, () => invokeEvent(StateMachine.AIInfo));
    }

    /// <summary>
    /// 删除转换
    /// </summary>
    /// <param name="toStateType">目标状态类型</param>
    public void RemoveTranslation(Type toStateType)
    {
        transilations.RemoveTransilation(toStateType);
    }

    /// <summary>
    /// 清空转换
    /// </summary>
    public void ClearTransilation()
    {
        transilations.Clear();
    }

    /// <summary>
    /// 清空转换 除了某个状态
    /// </summary>
    /// <param name="exceptState"></param>
    public void ClearTransilation(Type exceptState)
    {
        transilations.ClearExcept(exceptState);
    }

    /// <summary>
    /// 状态进入的初始化函数
    /// </summary>
    public abstract void Enter();
    /// <summary>
    /// 状态的主要循环逻辑
    /// </summary>
    public virtual void Update()
    {
        transilations.Update();
    }
    /// <summary>
    /// 状态的退出逻辑
    /// </summary>
    public abstract void Exit();
}