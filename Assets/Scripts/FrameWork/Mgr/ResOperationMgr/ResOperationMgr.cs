using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResOperationMgr : MonoSingleton<ResOperationMgr>
{
    private LinkedList<Team> m_TeamList;

    private void Awake()
    {
        m_TeamList = new LinkedList<Team>();
    }

    private void Update()
    {
        for(LinkedListNode<Team> cur = m_TeamList.First;cur != null;cur = cur.Next)
        {
            if(cur.Value.Count == 0)
            {
                m_TeamList.Remove(cur);
            }
        }
    }

    public void AddTeam(E_Command fristCmd, E_Command secondCmd, int fristCmd2SecondCmdFlag, int secondCmd2FristCmdFlag,params ArmBase[] arms)
    {
        //移除之前存在的小队
        for(int i = 0; i < arms.Length; i++)
        {
            if(arms[i].Team != null)
                arms[i].Team.RemoveMember(arms[i]);
            arms[i].SetCommand(fristCmd, secondCmd, arms[i], fristCmd2SecondCmdFlag, secondCmd2FristCmdFlag, -1, -1, -1, -1);
        }
        m_TeamList.AddLast(new Team(arms));
    }

    /// <summary>
    /// 设置指令
    /// </summary>
    /// <param name="fristCmd">第一指令</param>
    /// <param name="secondCmd">第二指令</param>
    /// <param name="arm">兵种自身</param>
    /// <param name="fristCmd2SecondCmdFlag">指令1->指令2的转换条件的标识，区分使用哪个转换条件</param>
    /// <param name="secondCmd2FristCmdFlag">指令2->指令1...</param>
    /// <param name="searchPath2FcFlag">寻路->指令1...</param>
    /// <param name="fc2SearchPathFlag">指令1->寻路...</param>
    public void SetCommand(ArmBase arm,E_Command fristCmd, E_Command secondCmd,int fristCmd2SecondCmdFlag, int secondCmd2FristCmdFlag, int searchPath2FcFlag = -1, int fc2SearchPathFlag = -1, int sreachPath2ScFlag = -1, int Sc2SreachPathFlag = -1)
    {
        arm.SetCommand(fristCmd, secondCmd, arm,fristCmd2SecondCmdFlag, secondCmd2FristCmdFlag, searchPath2FcFlag, fc2SearchPathFlag,sreachPath2ScFlag,Sc2SreachPathFlag);
    }
}
