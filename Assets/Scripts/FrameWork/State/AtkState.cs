
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
        Debug.Log("AtkEnter");
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
    }

}