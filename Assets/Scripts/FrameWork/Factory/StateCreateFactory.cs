using System.Collections.Generic;

/// <summary>
/// 状态创建工厂
/// </summary>
public class StateCreateFactory : Singleton<StateCreateFactory>, IFactory<StateBase,E_Command>
{
    private Dictionary<E_Command, StateBase> stateDic;

    private StateCreateFactory()
    {
        stateDic = new Dictionary<E_Command, StateBase>();
    }
    /// <summary>
    /// 获取状态
    /// </summary>
    /// <param name="command">指令</param>
    /// <returns>状态的基类</returns>
    public StateBase GetItem(E_Command command)
    {
        if(stateDic.ContainsKey(command)) return stateDic[command];
        StateBase state = null;
        switch (command)
        {
            case E_Command.rush:
                state = new AtkState();
                break;
            case E_Command.back:
                state = new BackState();
                break;
            case E_Command.check:
                state = new CheckState();
                break;
            case E_Command.yuhui:
                state = new YuHuiState();
                break;
            case E_Command.defence:
                state = new DefenceState();
                break;
        }
        stateDic.Add(command, state);
        return state;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <param name="command"></param>
    /// <returns></returns>
    public K GetItem<K>(E_Command command) where K : StateBase
    {
        return GetItem(command) as K;
    }
}