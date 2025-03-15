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

    //����

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
    /// �ṩ���ⲿ�ı����ָ��ĺ���
    /// </summary>
    /// <param name="command">ָ��ö��</param>
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
    /// ����ָ���ʼ����������
    /// </summary>
    /// <param name="command"></param>
    protected abstract void IntialData(E_Command command);
}
