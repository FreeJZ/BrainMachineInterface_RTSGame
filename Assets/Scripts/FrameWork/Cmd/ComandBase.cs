
using UnityEngine.Events;

/// <summary>
/// ÃüÁî»ùÀà
/// </summary>
public abstract class ComandBase 
{
    public abstract void Enter();
    public abstract bool Excute();
    public abstract void Exit(UnityAction action);
}
