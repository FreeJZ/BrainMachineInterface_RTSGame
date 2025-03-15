using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCommandState : CommandBaseState
{
    public BackCommandState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    protected override void IntilCommand(out E_Command command)
    {
        command = E_Command.back;
    }
}
