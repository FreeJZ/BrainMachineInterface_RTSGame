public class YuHuiCommandState : CommandBaseState
{
    public YuHuiCommandState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    protected override void IntilCommand(out E_Command command)
    {
        command = E_Command.yuhui;
    }
}