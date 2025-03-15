/// <summary>
/// 状态基类
/// 所有状态派生自它
/// </summary>
public abstract class StateBase
{
    private StateMachine stateMachine;

    public StateMachine StateMachine=>stateMachine;
    public StateBase(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    /// <summary>
    /// 状态进入的初始化函数
    /// </summary>
    public abstract void Enter();
    /// <summary>
    /// 状态的主要循环逻辑
    /// </summary>
    public abstract void Update();
    /// <summary>
    /// 状态的退出逻辑
    /// </summary>
    public abstract void Exit();
}