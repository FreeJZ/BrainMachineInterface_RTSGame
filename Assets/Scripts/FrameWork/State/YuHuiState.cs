/// <summary>
/// 迂回状态
/// </summary>
public class YuHuiState : StateBase
{
    public YuHuiState() { }
    public YuHuiState(StateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
    }
    public override void Enter()
    {
        StateMachine.AIInfo.YuHuiStateEnter();
    }

    public override void Update()
    {
        StateMachine.AIInfo.YuHuiStateUpdate();
        base.Update();
    }

    public override void Exit()
    {
        StateMachine.AIInfo.YuHuiStateExit();
    }

   
}