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
    
    #region IAIInfo接口的内容
    public override bool IsBack => throw new System.NotImplementedException();

    public override bool IsDefence => throw new System.NotImplementedException();

    public override bool IsYuHui => throw new System.NotImplementedException();

    public override bool IsCheck => throw new System.NotImplementedException();

    public override bool IsSerachPath
    {
        get
        {
            //敌方没消灭同时没到施展指令的范围
            return true;
        }
    }

    public override bool IsIdle
    {
        get
        {
            //敌方消灭
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

    #region IAtkerInfo的内容
    public float AtkVal => atkVal;
    #endregion

    #region IHurt的内容
    public virtual void Hurt(IAtkerInfo atkerInfo)
    {
        hp -= atkerInfo.AtkVal;
    }
    #endregion

    /// <summary>
    /// 设置小队
    /// </summary>
    /// <param name="team">所属小队对象</param>
    public void SetTeam(Team team)
    {
        this.team = team;
    }

  

  
}
