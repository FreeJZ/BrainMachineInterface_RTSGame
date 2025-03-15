using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����״̬�Ļ���
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
    /// ��ʼ��ָ��ö��
    /// ��Ǵ�״̬����ʲôָ����ʹ��
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
