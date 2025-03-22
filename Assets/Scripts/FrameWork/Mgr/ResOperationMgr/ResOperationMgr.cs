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
    /// �������
    /// </summary>
    /// <param name="armType">����ö������</param>
    /// <return>�������ɵ�Team����</return>
    public Team DivArm(E_ArmType armType)
    {
        Team team = new Team(10, armType);
        teamList.Add(team);
        return team;
    }

    /// <summary>
    /// ����С�ӵ�����
    /// </summary>
    /// <param name="team">С�Ӷ���</param>
    /// <param name="fristCmd">ָ��һ</param>
    /// <param name="secondCmd">ָ���</param>
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
