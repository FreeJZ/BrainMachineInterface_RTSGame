using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ӫ����
/// </summary>
public class Home : MonoBehaviour, IHurt
{
    private float hp;
    public void Hurt(IAtkerInfo atkerInfo)
    {
        hp -= atkerInfo.AtkVal;
    }
}
