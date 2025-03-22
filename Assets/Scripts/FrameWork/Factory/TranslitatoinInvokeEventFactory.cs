using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// 转换事件工厂
/// </summary>
public class TranslitatoinInvokeEventFactory : Singleton<TranslitatoinInvokeEventFactory>,IFactory<Dictionary<E_Command, Func<IAIInfo, bool>>,E_Command>
{
    private Dictionary<E_Command, Dictionary<E_Command, Func<IAIInfo, bool>>> eventDic;
    private TranslitatoinInvokeEventFactory()
    {
        eventDic = new Dictionary<E_Command, Dictionary<E_Command, Func<IAIInfo, bool>>> ();

        Array arr = Enum.GetValues(typeof(E_Command));
        foreach (E_Command key1 in arr)
        {
            Dictionary<E_Command,Func<IAIInfo,bool>> dic = new Dictionary<E_Command, Func<IAIInfo, bool>> ();
            eventDic.Add(key1, dic);
            foreach(E_Command key2 in arr)
            {
                dic.Add(key2, null);
            }
        }
    }

    /// <summary>
    /// 添加转换事件
    /// </summary>
    /// <param name="fromCmd">开始指令</param>
    /// <param name="toCmd">目标指令</param>
    /// <param name="invokeEvent">转换事件</param>
    public void AddTransilatoinEvent(E_Command fromCmd, E_Command toCmd,Func<IAIInfo,bool> invokeEvent)
    {
        eventDic[fromCmd][toCmd] = invokeEvent;
    }

    /// <summary>
    /// 获取从 开始指令 到 目标指令 的 转换事件
    /// </summary>
    /// <param name="fromCommand">开始指令</param>
    /// <param name="toCommand">目标指令</param>
    /// <returns>转换事件</returns>
    public Func<IAIInfo,bool> GetTransilatoinEvent(E_Command fromCommand,E_Command toCommand)
    {
        Dictionary<E_Command, Func<IAIInfo, bool>> dic = (this as IFactory<Dictionary<E_Command, Func<IAIInfo, bool>>, E_Command>).GetItem(fromCommand);
        if (dic[toCommand] == null) Debug.LogError($"不存在 {fromCommand}->{toCommand} 的转换事件");
        return dic[toCommand];
    }
  
    K IFactory<Dictionary<E_Command, Func<IAIInfo, bool>>,E_Command>.GetItem<K>(E_Command command)
    {
        throw new NotImplementedException();
    }

    Dictionary<E_Command, Func<IAIInfo, bool>> IFactory<Dictionary<E_Command, Func<IAIInfo, bool>>, E_Command>.GetItem(E_Command command)
    {
        if(eventDic.ContainsKey(command))
        {
            return eventDic[command];
        }
        return null;
    }
}
