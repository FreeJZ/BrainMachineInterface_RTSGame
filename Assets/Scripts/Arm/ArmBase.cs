using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ArmBase : AIBehaviour,IAtkerInfo,IHurt,IHurterInfo,ISelectable
{
    protected Animator animator;
    public float hp;
    public float walkHeight;
    public float checkRange;
    public float atkVal;
    public float atkSpeed;
    public float atkDis;
    public float moveSpeed;
    public int maxAtkCnt;
    public LayerMask atklayer;
    protected ArmData armData;
    protected Vector3 targetPoint;

    protected NavMeshAgent agent;
    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        if(agent == null) agent = gameObject.AddComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public Team Team { get; set; }

    #region ISelectable接口的内容
    public virtual Vector3 BottomPoint => transform.position + Vector3.down*GetComponent<CapsuleCollider>().height/2;

    public virtual Vector3 TopPoint => transform.position + Vector3.up * GetComponent<CapsuleCollider>().height/2;

    public virtual Vector3 RightPoint => transform.position + Vector3.right * GetComponent<CapsuleCollider>().radius;

    public virtual Vector3 LeftPoint => transform.position  + Vector3.left * GetComponent<CapsuleCollider>().radius;

    public virtual bool IsSelected { get; set; }

    public virtual void SelectHighLight(bool isShow)
    {
        
    }
    #endregion

    #region IAIInfo接口的内容

    //寻路到其他的转换
    public override bool SearchPathToAtk(int flag)
    {
        return false;
    }

    public override bool SearchPathToDefence(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool SearchPathToBack(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool SearchPathToYuHui(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool SearchPathToCheck(int flag)
    {
        throw new NotImplementedException();
    }

    //攻击到其他的转换
    public override bool AtkToSreachPath(int flag)
    {
        return false;
    }

    public override bool AtkToDefence(int flag)
    {
        switch (flag)
        {
            case 0:
                return Team.KD >= 0.5f;
            case 1:
                return Team.KD >= 0.7f;
        }
        return false;
    }

    public override bool AtkToBack(int flag)
    {
        switch (flag)
        {
            case 0:
                return hp / armData.hp <= 0.3f;
            case 1:
                return hp / armData.hp <= 0.5f;
        }
        return false;
    }

    public override bool AtkToYuHui(int flag)
    {
        return false;
    }

    public override bool AtkToCheck(int flag)
    {
        return false;
    }
    //防御到其他的转换
    public override bool DefenceToSearchPath(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool DefenceToAtk(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool DefenceToBack(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool DefenceToYuHui(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool DefenceToCheck(int flag)
    {
        throw new NotImplementedException();
    }

    //撤退到其他的转换
    public override bool BackToSreachPath(int flag)
    {
        return false;
    }

    public override bool BackToAtk(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool BackToDefence(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool BackToYuHui(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool BackToCheck(int flag)
    {
        throw new NotImplementedException();
    }

    //迂回到其他的转换
    public override bool YuHuiToSreachPath(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool YuHuiToAtk(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool YuHuiToDefence(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool YuHuiToBack(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool YuHuiToCheck(int flag)
    {
        throw new NotImplementedException();
    }
    //侦查到其他的转换
    public override bool CheckToSreachPath(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool CheckToAtk(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool CheckToDefence(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool CheckToBack(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool CheckToYuHui(int flag)
    {
        throw new NotImplementedException();
    }

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
    //攻击状态
    public override void AtkStateUpdate()
    {
        throw new NotImplementedException();
    }

    public override void AtkStateEnter()
    {
        throw new NotImplementedException();
    }

    public override void AtkStateExit()
    {
        throw new NotImplementedException();
    }

    //撤退状态
    public override void BackStateUpdate()
    {
        
    }

    public override void BackStateEnter()
    {
        ChangeAnimation("run");
        //获取我方营地位置
        if (atklayer == 1 << LayerMask.NameToLayer("Enmy"))
            targetPoint = LevelMgr.Instance.LevelData.HomePoint;
        else
            targetPoint = LevelMgr.Instance.LevelData.EnemyPoint;
        //寻路
        agent.SetDestination(targetPoint);
        agent.isStopped = false;
        //回血逻辑
        MonoMgr.Instance.InvokeRepeating("RestoreHP", 0, 1);
    }

    public override void BackStateExit()
    {
        agent.isStopped = true;
        MonoMgr.Instance.CancelInvoke("RestoreHP");
    }

    protected void RestoreHP()
    {
        hp += armData.hp * 0.1f;
    }
    //防御状态
    public override void DefenceStateUpdate()
    {
        throw new NotImplementedException();
    }

    public override void DefenceStateEnter()
    {
        throw new NotImplementedException();
    }

    public override void DefenceStateExit()
    {
        throw new NotImplementedException();
    }
    //迂回状态
    public override void YuHuiStateUpdate()
    {
        throw new NotImplementedException();
    }

    public override void YuHuiStateEnter()
    {
        throw new NotImplementedException();
    }

    public override void YuHuiStateExit()
    {
        throw new NotImplementedException();
    }

    //侦查状态
    public override void CheckStateUpdate()
    {
        throw new NotImplementedException();
    }

    public override void CheckStateEnter()
    {
        throw new NotImplementedException();
    }

    public override void CheckStateExit()
    {
        throw new NotImplementedException();
    }

    //寻路状态
    public override void SearchPathStateUpdate()
    {
       
    }

    public override void SearchPathStateEnter()
    {
        ChangeAnimation("run");
        agent.isStopped = false;
        agent.SetDestination(targetPoint);
    }

    public override void SearchPathStateExit()
    {
        agent.isStopped = true;
    }

    //待机状态
    public override void IdleStateUpdate()
    {
        
    }

    public override void IdleStateEnter()
    {
        targetPoint = LevelMgr.Instance.LevelData.EnemyPoint;
        ChangeAnimation("idle");
    }

    public override void IdleStateExit()
    {
    }
    //死亡状态
    public override void DeadStateUpdate()
    {
        
    }

    public override void DeadStateEnter()
    {
        ChangeAnimation("Dead");
    }

    public override void DeadStateExit()
    {
        
    }

    #endregion

    #region IAtkerInfo的内容
    public float AtkVal => atkVal;

    public Transform AtkTarget { get; set; }




    #endregion

    #region IHurterInfo
    public int MaxAtkCnt => maxAtkCnt;

    public int CurAtkCnt { get; set; }
    #endregion

    #region IHurt的内容
    public virtual void Hurt(IAtkerInfo atkerInfo)
    {
        if(hp > 0)
        {
            hp -= atkerInfo.AtkVal;
            //死亡
            if (hp <= 0)
            {
                if(AtkTarget != null)
                {
                    IHurterInfo info = AtkTarget.GetComponent<IHurterInfo>();
                    --info.CurAtkCnt;
                }

                ++atkerInfo.Team.HitEnmyCnt;
                Team.RemoveMember(this);
                stateMachine.ChangeState<DeadState>();
            }
        }
    }

   


    #endregion

    public void RestoreHP(float val)
    {
        Debug.Log("回血 + " + val);
        //if(this.hp < armData.HP)
        //    this.hp += val;
    }

   

    protected virtual void OnDrawGizmos()
    {
        //绘制攻击范围
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, atkDis);
    }
}
