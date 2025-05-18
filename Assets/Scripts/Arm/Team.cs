using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    private LinkedList<ArmBase> list;
    //小队击杀敌人总数
    private int hitEnmyCnt;
    public int HitEnmyCnt
    {
        get => hitEnmyCnt;
        set => hitEnmyCnt = value;
    }

    //成员数量
    public int Count=>list.Count;
    //小队击杀数和小队成员的数量之比
    public float KD
    {
        get
        {
            if(Count == 0) return 0;
            else
            {
                return hitEnmyCnt * 1.0f / list.Count;
            }
        }
    }

    public Team(params ArmBase[] arms)
    {
        list = new LinkedList<ArmBase>();
        for(int i = 0; i < arms.Length; i++)
        {
            arms[i].Team = this;
            AddMember(arms[i]);          
        }
    }

    public void AddMember(ArmBase arm)
    {
        if(!list.Contains(arm)) list.AddLast(arm);
    }

    public void RemoveMember(ArmBase arm)
    {
        if(list.Contains(arm)) list.Remove(arm);
    }
}
