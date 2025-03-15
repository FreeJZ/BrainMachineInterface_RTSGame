public class CheckCommandState : CommandBaseState
{
    public CheckCommandState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    protected override void IntilCommand(out E_Command command)
    {
        command = E_Command.check;
    }
}