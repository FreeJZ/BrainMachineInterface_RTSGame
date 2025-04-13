/// <summary>
/// 侦查状态
/// </summary>
public class CheckState : StateBase
{
    public CheckState() { }
    public CheckState(StateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
    }
    public override void Enter()
    {
        StateMachine.AIInfo.CheckStateEnter();
    }

    public override void Update()
    {
        base.Update();
        StateMachine.AIInfo.CheckStateUpdate();
    }

    public override void Exit()
    {
        StateMachine.AIInfo.CheckStateExit();
    }

}