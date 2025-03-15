using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ״̬���ӿ�
/// ʹ��״̬����̳иýӿ�
/// </summary>
public interface IStateMachineOwner
{
    //Idle
    
    /// <summary>
    /// �ص�����
    /// �������� ��ָͬ���µ��߼�����ʵ��
    /// </summary>
    /// <param name="command"></param>
    void IdleStateEnter(E_Command command);
    /// <summary>
    /// �ص�����
    /// �������� ��дת��״̬�߼� �� ��ָͬ���µ��߼�����ʵ��
    /// </summary>
    /// <param name="stateMachine"></param>
    /// <param name="command"></param>
    void IdleStateUpdate(StateMachine stateMachine,E_Command command);
    //Idle
    /// <summary>
    /// �ص�����
    /// �������� ��ָͬ���µ��߼�����ʵ��
    /// </summary>
    /// <param name="command"></param>
    void IdleStateExit(E_Command command);
   
    //Hurt
    void HurtStateEnter(E_Command command);
    void HurtStateUpdate(StateMachine stateMachine, E_Command command);
    void HurtStateExit(E_Command command);
   
}
