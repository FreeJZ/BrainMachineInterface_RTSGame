using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 受伤行为的接口
/// </summary>
public interface IHurt
{
    void Hurt(IAtkerInfo atkerInfo);
}
