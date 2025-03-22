using UnityEngine;
public class SearchPathState : StateBase
{
    public SearchPathState() { }

    public SearchPathState(StateMachine stateMachine) : base(stateMachine) { }
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);

        AddTransilation(typeof(IdleState), () =>
        {
            return StateMachine.AIInfo.IsIdle;
        });
    }
    public override void Enter()
    {
        Debug.Log("SerachPathEnter");
    }
    public override void Update()
    {
        base.Update();
    }
    public override void Exit()
    {
    }
}