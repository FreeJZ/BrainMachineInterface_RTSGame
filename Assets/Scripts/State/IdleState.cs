using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : DetailStateBase
{
    public IdleState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        StateMachine.Owner.IdleStateEnter(subStateMachine.Command);
    }

    public override void Exit()
    {
        StateMachine.Owner.IdleStateExit(subStateMachine.Command);
    }

    public override void Update()
    {
        StateMachine.Owner.IdleStateUpdate(StateMachine,subStateMachine.Command);
    }
}
