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
        AddTransilation(typeof(SearchPathState), () =>
        {
            return StateMachine.AIInfo.IsSerachPath;
        });
    }
    public override void Enter()
    {
        Debug.Log("IdleEnter");
    }
    public override void Update()
    {
        base.Update();
    }
    public override void Exit()
    {
    }
}