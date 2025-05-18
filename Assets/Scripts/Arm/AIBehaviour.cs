using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class AIBehaviour : MonoBehaviour,IAIInfo
{
    protected StateMachine stateMachine;
    protected bool isSetCommand;
    protected E_Command curCommand;
    public bool IsSetCommand => isSetCommand;

    public E_Command CurCommand { get => curCommand; set => curCommand = value; }

    protected virtual void Awake()
    {
        stateMachine = new StateMachine(this);
    }

    protected virtual void OnEnable()
    {

    }

    protected virtual void Start()
    {
        stateMachine.ChangeState<IdleState>();
    }

    protected virtual void Update()
    {
        stateMachine.Update();
    }

    public abstract void ChangeAnimation(string animationName);
    public abstract bool AnimationListener(string curAniimationName, float targetNormalizedTime);

    /// <summary>
    /// 状态链接函数
    /// </summary>
    /// <param name="firstCmd">第一指令</param>
    /// <param name="secondCmd">第二指令</param>
    private void StateLink(E_Command firstCmd, E_Command secondCmd,int fristCmd2SecondCmdFlag,int secondCmd2FristCmdFlag,int searchPath2FcFlag, int fc2SearchPathFlag,int sreachPath2ScFlag,int Sc2SreachPathFlag)
    {

        stateMachine.ChangeState<IdleState>();

        //清空之前的转换连线
        StateBase sreachPathState = GetStateByCommand(E_Command.sreachPath);
        StateBase state1 = GetStateByCommand(firstCmd);
        StateBase state2 = GetStateByCommand(secondCmd);
        sreachPathState.ClearTransilation(typeof(IdleState));
        state1.ClearTransilation();
        state2.ClearTransilation();

        Func<IAIInfo, int, bool> invokeEnvent;
        if(state1 != state2)
        {
            //state1 和 state2 连接
            invokeEnvent = TranslitatoinInvokeEventFactory.Instance.GetTransilatoinEvent(firstCmd, secondCmd);
            state1.AddTransilation(state2.GetType(), invokeEnvent, fristCmd2SecondCmdFlag);

            invokeEnvent = TranslitatoinInvokeEventFactory.Instance.GetTransilatoinEvent(secondCmd, firstCmd);
            state2.AddTransilation(state1.GetType(), invokeEnvent, secondCmd2FristCmdFlag);

            //state2 和 sreachPath
            invokeEnvent = TranslitatoinInvokeEventFactory.Instance.GetTransilatoinEvent(secondCmd, E_Command.sreachPath);
            state2.AddTransilation(sreachPathState.GetType(), invokeEnvent, Sc2SreachPathFlag);

            invokeEnvent = TranslitatoinInvokeEventFactory.Instance.GetTransilatoinEvent(E_Command.sreachPath, secondCmd);
            sreachPathState.AddTransilation(state2.GetType(), invokeEnvent, sreachPath2ScFlag);
        }

        //sreachPath 和 state1 连接
        invokeEnvent = TranslitatoinInvokeEventFactory.Instance.GetTransilatoinEvent(E_Command.sreachPath, firstCmd);
        sreachPathState.AddTransilation(state1.GetType(),invokeEnvent,secondCmd2FristCmdFlag);
        
        invokeEnvent = TranslitatoinInvokeEventFactory.Instance.GetTransilatoinEvent(firstCmd,E_Command.sreachPath);
        state1.AddTransilation(sreachPathState.GetType(),invokeEnvent, fristCmd2SecondCmdFlag);

    }

    /// <summary>
    /// 设置指令
    /// </summary>
    /// <param name="fristCmd">第一指令</param>
    /// <param name="secondCmd">第二指令</param>
    /// <param name="arm">兵种自身</param>
    /// <param name="fristCmd2SecondCmdFlag">指令1->指令2的转换条件的标识，区分使用哪个转换条件</param>
    /// <param name="secondCmd2FristCmdFlag">指令2->指令1...</param>
    /// <param name="searchPath2FcFlag">寻路->指令1...</param>
    /// <param name="fc2SearchPathFlag">指令1->寻路...</param>
    public void SetCommand(E_Command fristCmd,E_Command secondCmd,ArmBase arm, int fristCmd2SecondCmdFlag, int secondCmd2FristCmdFlag, int searchPath2FcFlag, int fc2SearchPathFlag ,int sreachPath2ScFlag, int Sc2SreachPathFlag)
    {
        //设置当前的指令
        CurCommand = fristCmd;
        //处理Buffer
        BufferHandle.Handle(fristCmd, secondCmd, arm);
        //动态更新状态机
        StateLink(fristCmd, secondCmd,fristCmd2SecondCmdFlag,secondCmd2FristCmdFlag,searchPath2FcFlag,fc2SearchPathFlag,sreachPath2ScFlag,Sc2SreachPathFlag);
        //标记被设置指令
        isSetCommand = true;
    }

    private StateBase GetStateByCommand(E_Command cmd)
    {
        StateBase state = null;
        switch (cmd)
        {
            case E_Command.sreachPath:
                state = stateMachine.GetState<SearchPathState>();
                break;
            case E_Command.rush:
                state = stateMachine.GetState<AtkState>();
                break;
            case E_Command.back:
                state = stateMachine.GetState<BackState>();   
                break;
            case E_Command.check:
                state = stateMachine.GetState<CheckState>();
                break;
            case E_Command.yuhui:
                state = stateMachine.GetState<YuHuiState>();
                break;
            case E_Command.defence:
                state = stateMachine.GetState<DefenceState>();
                break;
        }
        return state;
    }

    public abstract void AtkStateUpdate();
    public abstract void AtkStateEnter();
    public abstract void AtkStateExit();
    public abstract void BackStateUpdate();
    public abstract void BackStateEnter();
    public abstract void BackStateExit();
    public abstract void DefenceStateUpdate();
    public abstract void DefenceStateEnter();
    public abstract void DefenceStateExit();
    public abstract void YuHuiStateUpdate();
    public abstract void YuHuiStateEnter();
    public abstract void YuHuiStateExit();
    public abstract void CheckStateUpdate();
    public abstract void CheckStateEnter();
    public abstract void CheckStateExit();
    public abstract void SearchPathStateUpdate();
    public abstract void SearchPathStateEnter();
    public abstract void SearchPathStateExit();
    public abstract void IdleStateUpdate();
    public abstract void IdleStateEnter();
    public abstract void IdleStateExit();
    public abstract void DeadStateUpdate();
    public abstract void DeadStateEnter();
    public abstract void DeadStateExit();

    public abstract bool SearchPathToAtk(int flag);
    public abstract bool SearchPathToDefence(int flag);
    public abstract bool SearchPathToBack(int flag);
    public abstract bool SearchPathToYuHui(int flag);
    public abstract bool SearchPathToCheck(int flag);
    public abstract bool AtkToSreachPath(int flag);
    public abstract bool AtkToDefence(int flag);
    public abstract bool AtkToBack(int flag);
    public abstract bool AtkToYuHui(int flag);
    public abstract bool AtkToCheck(int flag);
    public abstract bool DefenceToSearchPath(int flag);
    public abstract bool DefenceToAtk(int flag);
    public abstract bool DefenceToBack(int flag);
    public abstract bool DefenceToYuHui(int flag);
    public abstract bool DefenceToCheck(int flag);
    public abstract bool BackToSreachPath(int flag);
    public abstract bool BackToAtk(int flag);
    public abstract bool BackToDefence(int flag);
    public abstract bool BackToYuHui(int flag);
    public abstract bool BackToCheck(int flag);
    public abstract bool YuHuiToSreachPath(int flag);
    public abstract bool YuHuiToAtk(int flag);
    public abstract bool YuHuiToDefence(int flag);
    public abstract bool YuHuiToBack(int flag);
    public abstract bool YuHuiToCheck(int flag);
    public abstract bool CheckToSreachPath(int flag);
    public abstract bool CheckToAtk(int flag);
    public abstract bool CheckToDefence(int flag);
    public abstract bool CheckToBack(int flag);
    public abstract bool CheckToYuHui(int flag);
   
}