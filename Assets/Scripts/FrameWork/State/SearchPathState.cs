using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
public class SearchPathState : StateBase
{
    public SearchPathState() { }

    public SearchPathState(StateMachine stateMachine) : base(stateMachine) { }
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);

        AddTransilation(typeof(IdleState), (flag) =>
        {
            return false;
        },0);
    }
    public override void Enter()
    {
        StateMachine.AIInfo.SearchPathStateEnter();
    }
    public override void Update()
    {
        StateMachine.AIInfo.SearchPathStateUpdate();
        base.Update();
    }
    public override void Exit()
    {
        StateMachine.AIInfo.SearchPathStateExit();
    }
}