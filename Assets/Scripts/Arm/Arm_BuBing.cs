using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 步兵
/// </summary>
public class Arm_BuBing : ArmBase
{
    //子弹出发的点
    public Transform BulteStartPoint;
    public GameObject selectedHightLight;
    protected override void Awake()
    {
        base.Awake();
        isSetCommand = false;
    }
    protected override void Start()
    {
        base.Start();
        armData = DataMgr.Instance.GetArmData("bb");
    }
    #region ISelectable接口的内容
    public override Vector3 LeftPoint => transform.position + Vector3.up* GetComponent<CapsuleCollider>().height/2 + Vector3.left * GetComponent<CapsuleCollider>().radius;
    public override Vector3 RightPoint => transform.position + Vector3.up * GetComponent<CapsuleCollider>().height / 2 + Vector3.right * GetComponent<CapsuleCollider>().radius;
    public override Vector3 BottomPoint => transform.position;
    public override Vector3 TopPoint => transform.position + Vector3.up * GetComponent<CapsuleCollider>().height;

    public override void SelectHighLight(bool isShow)
    {
        selectedHightLight.SetActive(isShow);
    }

    #endregion


    #region 寻路到其他
    public override bool SearchPathToAtk(int flag)
    {
        return IsOnAtkRange();
    }

    public override bool SearchPathToBack(int flag)
    {
        //下达撤退指令
        return true;
    }
    public override bool SearchPathToDefence(int flag)
    {
        return IsOnAtkRange();
    }

    public override bool SearchPathToCheck(int flag)
    {
        return IsOnCheckRange();
    }

    public override bool SearchPathToYuHui(int flag)
    {
        //下达迂回指令
        return true;
    }
    #endregion

    #region 攻击到其他
    public override bool AtkToSreachPath(int flag)
    {
        return !IsOnAtkRange();
    }

    public override bool AtkToCheck(int flag)
    {
        switch (flag)
        {
            case 0:
                return IsOnCheckRange();
        }
        return false;
    }

    public override bool AtkToYuHui(int flag)
    {
        switch(flag)
        {
            case 0:
                return !IsOnAtkRange();
        }
        return false;
    }

    #endregion

    #region 撤退到其他
    public override bool BackToAtk(int flag)
    {
        switch (flag)
        {
            case 0:
                return hp / armData.hp >= 0.9f; 
            case 1:
                return hp / armData.hp >= 0.8f;
        }

        return false;
    }

    public override bool BackToDefence(int flag)
    {
        switch (flag)
        {
            case 0:
                return hp / armData.hp >= 0.8f;
        }

        return false;
    }

    public override bool BackToYuHui(int flag)
    {
        switch (flag)
        {
            case 0:
                return IsOnCheckRange();
            case 1:
                return hp / armData.hp >= 0.8f;
        }

        return false;
    }

    public override bool BackToCheck(int flag)
    {
        switch (flag)
        {
            case 0:
                return hp / armData.hp >= 0.9f;
        }

        return false;
    }
    #endregion

    #region 攻击状态
    public override void AtkStateEnter()
    {
        ChangeAnimation("shoot");
    }

    public override void AtkStateUpdate()
    {
        Vector3 lookdir = (AtkTarget.position - transform.position).normalized;
        lookdir.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookdir), Time.deltaTime * 10);
    }
    public override void AtkStateExit()
    {
        --AtkTarget.GetComponent<IHurterInfo>().CurAtkCnt;
        AtkTarget = null;
    }


    #endregion
    private void OnAnimatorIK(int layerIndex)
    {
        if (AtkTarget == null) return;
        animator.SetLookAtWeight(1, 1, 1, 1, 0);
        animator.SetLookAtPosition(AtkTarget.position);



    }
    /// <summary>
    /// 攻击的动画事件
    /// </summary>
    public void AtkAnimationEvent()
    {
        GameObject bulte = PoolMgr.Instance.PopObj(ResPathConfig.BultefabPath + "BuBingBulte");
        bulte.transform.position = BulteStartPoint.position;
        BuBingBulte butleCs = bulte.GetComponent<BuBingBulte>();
        butleCs.Init(this, AtkTarget, atklayer);
    }

    protected  bool IsOnAtkRange()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, atkDis, atklayer, QueryTriggerInteraction.Ignore);
        Array.Sort(cols, (a, b) =>
        {
            IHurterInfo aInfo = a.GetComponent<IHurterInfo>();
            IHurterInfo bInfo = b.GetComponent<IHurterInfo>();
            return aInfo.CurAtkCnt - bInfo.CurAtkCnt;
        });
        for (int i = 0; i < cols.Length; i++)
        {
            Vector3 dir = (cols[i].transform.position - transform.position).normalized;
            if (Physics.Raycast(transform.position, dir, out RaycastHit hit, 1000))
            {
                if (hit.collider == cols[i])
                {
                    IHurterInfo info = cols[i].GetComponent<IHurterInfo>();
                    if (info.CurAtkCnt >= info.MaxAtkCnt) continue;
                    ++info.CurAtkCnt;
                    AtkTarget = cols[i].transform;
                    return true;
                }
            }
        }
        return false;
    }

    protected bool IsOnCheckRange()
    {
        //有迷雾遮盖的地方就可以进行侦查
        return false;

    }
}