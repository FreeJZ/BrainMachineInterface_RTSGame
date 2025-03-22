using UnityEngine;
/// <summary>
/// 撤退状态
/// </summary>
public class BackState :StateBase
{
    public BackState() { }
    public BackState(StateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
    }
    public override void Enter()
    {
        Debug.Log("BackEnter");
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
    }
}