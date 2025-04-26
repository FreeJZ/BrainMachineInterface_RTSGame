using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArmBase : AIBehaviour,IAtkerInfo,IHurt,ISelectable
{
    protected Animator animator;
    public float hp;
    public float walkHeight;
    public float checkRange;
    public float atkVal;
    public float atkSpeed;
    public float atkDis;
    public float moveSpeed;

    private ArmData armData;

    protected Vector3 targetPoint;

    protected NavMeshAgent agent;
    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        if(agent == null) agent = gameObject.AddComponent<NavMeshAgent>();
    }

    #region ISelectable接口的内容
    public virtual Vector3 BottomPoint => transform.position + Vector3.down*GetComponent<CapsuleCollider>().height/2;

    public virtual Vector3 TopPoint => transform.position + Vector3.up * GetComponent<CapsuleCollider>().height/2;

    public virtual Vector3 RightPoint => transform.position + Vector3.right * GetComponent<CapsuleCollider>().radius;

    public virtual Vector3 LeftPoint => transform.position  + Vector3.left * GetComponent<CapsuleCollider>().radius;

    public virtual bool IsSelected { get; set; }

    public virtual void SelectHighLight(Color color)
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Material[] materials = meshRenderer.materials;
        for(int i = 0;i< materials.Length;i++)
        {
            materials[i].color = color;
        }
    }
    #endregion

    #region IAIInfo接口的内容


    public override bool SearchPathToAtk(int flag)
    {
        throw new NotImplementedException();
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

    public override bool AtkToSreachPath(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool AtkToDefence(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool AtkToBack(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool AtkToYuHui(int flag)
    {
        throw new NotImplementedException();
    }

    public override bool AtkToCheck(int flag)
    {
        throw new NotImplementedException();
    }

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

    public override bool BackToSreachPath(int flag)
    {
        return true;
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

    public override void BackStateUpdate()
    {
        
    }

    public override void BackStateEnter()
    {
        //获取我方营地位置
        targetPoint = LevelMgr.Instance.LevelData.HomePoint;
    }

    public override void BackStateExit()
    {
    }

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

    public override void SearchPathStateUpdate()
    {
        //Test
        Debug.Log(Vector3.Distance(agent.pathEndPosition, transform.position));
        if(Vector3.Distance(agent.pathEndPosition,transform.position) == 1)
        {
            stateMachine.ChangeState<IdleState>();
        }
    }

    public override void SearchPathStateEnter()
    {
        agent.isStopped = false;
        agent.SetDestination(targetPoint);
    }

    public override void SearchPathStateExit()
    {
        agent.isStopped = true;
    }

    public override void IdleStateUpdate()
    {
        
    }

    public override void IdleStateEnter()
    {
        targetPoint = LevelMgr.Instance.LevelData.EnemyPoint;
    }

    public override void IdleStateExit()
    {
    }

    public override void DeadStateUpdate()
    {
        throw new NotImplementedException();
    }

    public override void DeadStateEnter()
    {
        throw new NotImplementedException();
    }

    public override void DeadStateExit()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region IAtkerInfo的内容
    public float AtkVal => atkVal;


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
}
