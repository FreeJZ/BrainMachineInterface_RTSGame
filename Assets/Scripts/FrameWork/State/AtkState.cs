
using UnityEngine;

/// <summary>
/// 攻击状态
/// </summary>
public class AtkState : StateBase
{
    public AtkState() { }
    public AtkState(StateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
    }
    public override void Enter()
    {
        StateMachine.AIInfo.AtkStateEnter();
    }

    public override void Update()
    {
        StateMachine.AIInfo.AtkStateUpdate();
        base.Update();
    }

    public override void Exit()
    {
        StateMachine.AIInfo.AtkStateExit();
    }

}