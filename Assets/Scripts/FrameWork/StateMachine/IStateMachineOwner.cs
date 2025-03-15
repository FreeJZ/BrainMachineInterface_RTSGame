using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 状态机接口
/// 使用状态机需继承该接口
/// </summary>
public interface IStateMachineOwner
{
    //Idle
    
    /// <summary>
    /// 回调函数
    /// 参数用于 不同指令下的逻辑分类实现
    /// </summary>
    /// <param name="command"></param>
    void IdleStateEnter(E_Command command);
    /// <summary>
    /// 回调函数
    /// 参数用于 书写转换状态逻辑 和 不同指令下的逻辑分类实现
    /// </summary>
    /// <param name="stateMachine"></param>
    /// <param name="command"></param>
    void IdleStateUpdate(StateMachine stateMachine,E_Command command);
    //Idle
    /// <summary>
    /// 回调函数
    /// 参数用于 不同指令下的逻辑分类实现
    /// </summary>
    /// <param name="command"></param>
    void IdleStateExit(E_Command command);
   
    //Hurt
    void HurtStateEnter(E_Command command);
    void HurtStateUpdate(StateMachine stateMachine, E_Command command);
    void HurtStateExit(E_Command command);
   
}
