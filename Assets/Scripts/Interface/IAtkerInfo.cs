using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻击者的信息接口
/// </summary>
public interface IAtkerInfo
{
    /// <summary>
    /// 攻击值
    /// </summary>
    float AtkVal { get;}
    /// <summary>
    /// 攻击目标
    /// </summary>
    Transform AtkTarget { get; set; }

    Team Team { get; set; }
}
