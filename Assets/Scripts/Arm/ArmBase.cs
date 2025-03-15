using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmBase : MonoBehaviour,IHurt,IAtkerInfo,IStateMachineOwner
{
    private float hp;
    private float atkVal;
    private float atkSpeed;
    private float atkRange;
    private float moveSpeed;

    //数据

    private StateMachine stateMachine;

    public float AtkVal { get=>atkVal; }

    public abstract void Hurt(IAtkerInfo atkerInfo);
    public abstract void HurtStateEnter(E_Command command);
    public abstract void HurtStateExit(E_Command command);
    public abstract void HurtStateUpdate(StateMachine stateMachine, E_Command command);
    public abstract void IdleStateEnter(E_Command command);
    public abstract void IdleStateExit(E_Command command);
    public abstract void IdleStateUpdate(StateMachine stateMachine, E_Command command);

    /// <summary>
    /// 提供给外部改变兵种指令的函数
    /// </summary>
    /// <param name="command">指令枚举</param>
    public void GetCommand(E_Command command)
    {
        switch (command)
        {
            case E_Command.rush:
                stateMachine.ChangeState<RushCommandState>();
                break;
            case E_Command.back:
                stateMachine.ChangeState<BackCommandState>();
                break;
            case E_Command.check:
                stateMachine.ChangeState<CheckCommandState>();
                break;
            case E_Command.yuhui:
                stateMachine.ChangeState<YuHuiCommandState>();
                break;
        }
    }

    /// <summary>
    /// 根据指令初始化兵种数据
    /// </summary>
    /// <param name="command"></param>
    protected abstract void IntialData(E_Command command);
}
