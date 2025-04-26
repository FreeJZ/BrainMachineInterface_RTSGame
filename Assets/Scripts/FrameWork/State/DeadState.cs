public class DeadState : StateBase
{
    public DeadState() { }
    
    public DeadState(StateMachine stateMachine) : base(stateMachine) { }
    public override void Enter()
    {
    }
    public override void Update()
    {
        base.Update();
    }
    public override void Exit()
    {
    }
}