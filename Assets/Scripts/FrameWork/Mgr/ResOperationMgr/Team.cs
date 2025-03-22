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
            //���ɱ���ʵ��
            ArmBase arm = ArmCreateFactory.Instance.GetItem(armType);
            arm.SetTeam(this);
            armList.Add(arm);
        }

        //TODO ע���¼�
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
    /// ���ڵ���ʿ��������ɾ����Team�е�����
    /// ����¼�����ʹ��
    /// </summary>
    /// <param name="arm"></param>
    private void DelArm(ArmBase arm)
    {
        armList.Remove(arm);
        --count;
    }

    /// <summary>
    /// ����ָ��
    /// </summary>
    /// <param name="cmd"></param>
    public void ChangeCommand(E_Command fristCmd,E_Command secondCmd)
    {
        for(int i = 0;i<count;i++) armList[i].SetCommand(fristCmd, secondCmd, armList[i]);
    }
}
