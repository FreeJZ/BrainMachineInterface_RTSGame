using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBase : AIBehaviour,IAtkerInfo,IHurt
{
    protected Animator animator;
    protected Team team;
    public float hp;
    public float walkHeight;
    public float checkRange;
    public float atkVal;
    public float atkSpeed;
    public float atkDis;
    public float moveSpeed;
    
    #region IAIInfo�ӿڵ�����
    public override bool IsBack => throw new System.NotImplementedException();

    public override bool IsDefence => throw new System.NotImplementedException();

    public override bool IsYuHui => throw new System.NotImplementedException();

    public override bool IsCheck => throw new System.NotImplementedException();

    public override bool IsSerachPath
    {
        get
        {
            //�з�û����ͬʱû��ʩչָ��ķ�Χ
            return true;
        }
    }

    public override bool IsIdle
    {
        get
        {
            //�з�����
            return false;
        }
    }

    public override bool IsAtk => true;
    public override bool AnimationListener(string curAnimationName, float targetNormalizedTime)
    {
        AnimatorStateInfo nextStateInfo = animator.GetNextAnimatorStateInfo(0);
        AnimatorStateInfo curStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (nextStateInfo.IsName(curAnimationName)) return false;

        if (curStateInfo.IsName(curAnimationName) && curStateInfo.normalizedTime >= targetNormalizedTime) return true;
        return false;
    }

    public override void ChangeAnimation(string animationName)
    {
        animator.CrossFadeInFixedTime(animationName, 0.2f);
    }
    #endregion

    #region IAtkerInfo������
    public float AtkVal => atkVal;
    #endregion

    #region IHurt������
    public virtual void Hurt(IAtkerInfo atkerInfo)
    {
        hp -= atkerInfo.AtkVal;
    }
    #endregion

    /// <summary>
    /// ����С��
    /// </summary>
    /// <param name="team">����С�Ӷ���</param>
    public void SetTeam(Team team)
    {
        this.team = team;
    }

  

  
}
