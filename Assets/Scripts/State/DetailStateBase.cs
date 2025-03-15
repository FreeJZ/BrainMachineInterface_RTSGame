public abstract class DetailStateBase : StateBase
{
    protected SubStateMachine subStateMachine;
    public DetailStateBase(StateMachine stateMachine) : base(stateMachine)
    {
        subStateMachine = stateMachine as SubStateMachine;
    }
}