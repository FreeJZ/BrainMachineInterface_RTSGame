using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        throw new NotImplementedException();
    }

    public override void BackStateEnter()
    {
        throw new NotImplementedException();
    }

    public override void BackStateExit()
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public override void SearchPathStateEnter()
    {
        throw new NotImplementedException();
    }

    public override void SearchPathStateExit()
    {
        throw new NotImplementedException();
    }

    public override void IdleStateUpdate()
    {
        throw new NotImplementedException();
    }

    public override void IdleStateEnter()
    {
        throw new NotImplementedException();
    }

    public override void IdleStateExit()
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
        hp -= atkerInfo.AtkVal;
    }
    #endregion
}
