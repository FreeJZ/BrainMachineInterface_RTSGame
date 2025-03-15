using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 命令状态的基类
/// </summary>
public abstract class CommandBaseState : StateBase
{
    private SubStateMachine subStateMachine;

    private E_Command command;
    public CommandBaseState(StateMachine stateMachine) : base(stateMachine)
    {
        subStateMachine = new SubStateMachine(stateMachine.Owner,command);
        IntilCommand(out command);
    }

    /// <summary>
    /// 初始化指令枚举
    /// 标记此状态是在什么指令下使用
    /// </summary>
    /// <param name="command"></param>
    protected abstract void IntilCommand(out E_Command command);

    public override void Enter()
    {
        subStateMachine.ChangeState<IdleState>();
    }

    public override void Exit()
    {
        subStateMachine.ChangeState<IdleState>();
    }

    public override void Update()
    {
        subStateMachine.Update();
    }
}
