using UnityEngine;

/// <summary>
/// 通用的待机状态
/// </summary>
public class IdleState : StateBase
{
    public IdleState() { }  

    public IdleState(StateMachine stateMachine) : base(stateMachine) { }
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        //添加Idle->SearchPath的转换条件
        AddTransilation(typeof(SearchPathState), (flag) =>
        {
            return StateMachine.AIInfo.IsSetCommand && !LevelMgr.Instance.EnmyIsDead && !LevelMgr.Instance.HomeIsDead;
        },0);
    }
    public override void Enter()
    {
        StateMachine.AIInfo.IdleStateEnter();
    }
    public override void Update()
    {
        StateMachine.AIInfo.IdleStateUpdate();
        base.Update();
    }
    public override void Exit()
    {
        stateMachine.AIInfo.IdleStateExit();
    }
}