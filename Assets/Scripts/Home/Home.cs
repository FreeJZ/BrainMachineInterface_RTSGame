using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ÓªµØÀà
/// </summary>
public class Home : MonoBehaviour, IHurt
{
    private float hp;
    public void Hurt(IAtkerInfo atkerInfo)
    {
        hp -= atkerInfo.AtkVal;
    }
}
