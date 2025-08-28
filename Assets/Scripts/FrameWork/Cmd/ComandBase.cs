
using UnityEngine.Events;

/// <summary>
/// 命令基类
/// </summary>
public abstract class ComandBase 
{
    public abstract void Enter();
    public abstract bool Excute();
    public abstract void Exit(UnityAction action);
}
