/// <summary>
/// 防御状态
/// </summary>
public class  DefenceState : StateBase
{
    public DefenceState() { }
    public DefenceState(StateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
    }
    public override void Enter()
    {
        StateMachine.AIInfo.DefenceStateEnter();
    }

    public override void Update()
    {
        StateMachine.AIInfo.DefenceStateUpdate();
        base.Update();
    }

    public override void Exit()
    {
        StateMachine.AIInfo.DefenceStateExit();
    }
}