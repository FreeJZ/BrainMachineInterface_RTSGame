using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResOperationMgr : MonoSingleton<ResOperationMgr>
{
    private List<Team> teamList = new List<Team>();

    private void Update()
    {
        CheckTeam();
        Debug.Log("TeamListCount:" +  teamList.Count);
    }

    /// <summary>
    /// 分配兵种
    /// </summary>
    /// <param name="armType">兵种枚举类型</param>
    /// <return>返回生成的Team对象</return>
    public Team DivArm(E_ArmType armType)
    {
        Team team = new Team(10, armType);
        teamList.Add(team);
        return team;
    }

    /// <summary>
    /// 设置小队的命令
    /// </summary>
    /// <param name="team">小队对象</param>
    /// <param name="fristCmd">指令一</param>
    /// <param name="secondCmd">指令二</param>
    public void SetTeamCommand(Team team,E_Command fristCmd,E_Command secondCmd)
    {
        team.ChangeCommand(fristCmd, secondCmd);
    }

    private void CheckTeam()
    {
        for(int i = teamList.Count - 1; i >= 0; i--)
        {
            if(teamList[i].TeamIsDead) teamList.RemoveAt(i);    
        }
    }
}
