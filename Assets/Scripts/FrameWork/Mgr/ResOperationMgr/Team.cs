using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    private List<ArmBase> armList;
    private int count;

    private static int id = -1;
    public int ID => id;

    public Team(int count,E_ArmType armType)
    {
        id++;
        this.count = count;
        armList = new List<ArmBase>();
        for(int i = 0; i < count; i++)
        {
            //生成兵种实例
            ArmBase arm = ArmCreateFactory.Instance.GetItem(armType);
            arm.SetTeam(this);
            armList.Add(arm);
        }

        //TODO 注册事件
        EventCenter.Instance.AddEventListener<ArmBase>("Team" + id, DelArm);
    }

    public bool TeamIsDead
    {
        get
        {
            if(count==0)
            {
                EventCenter.Instance.RemoveEventListener("Team" + id);
            }

            return count == 0;
        }
    }

    /// <summary>
    /// 用于单个士兵死亡后，删除在Team中的引用
    /// 配合事件中心使用
    /// </summary>
    /// <param name="arm"></param>
    private void DelArm(ArmBase arm)
    {
        armList.Remove(arm);
        --count;
    }

    /// <summary>
    /// 更改指令
    /// </summary>
    /// <param name="cmd"></param>
    public void ChangeCommand(E_Command fristCmd,E_Command secondCmd)
    {
        for(int i = 0;i<count;i++) armList[i].SetCommand(fristCmd, secondCmd, armList[i]);
    }
}
