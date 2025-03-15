public class SubStateMachine : StateMachine
{
    public E_Command Command
    {
        get;
        protected set;
    }
    public SubStateMachine(IStateMachineOwner owner,E_Command command) : base(owner)
    {
        Command = command;
    }
}