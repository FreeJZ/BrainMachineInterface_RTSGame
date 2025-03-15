using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushCommandState : CommandBaseState
{
    public RushCommandState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    protected override void IntilCommand(out E_Command command)
    {
        command = E_Command.rush;
    }
}
