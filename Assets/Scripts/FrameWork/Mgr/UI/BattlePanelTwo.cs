using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePanelTwo : BattlePanelBase
{
    /// <summary>
    /// 进攻按钮点击事件
    /// </summary>
    public override void OnArmBuBingClick()
    {
        base.OnArmBuBingClick();
    }
    /// <summary>
    /// 撤退按钮点击事件
    /// </summary>
    public override void OnArmPaoBingClick()
    {
        base.OnArmPaoBingClick();
    }
    /// <summary>
    /// 防御按钮点击事件
    /// </summary>
    public override void OnArmZhuangJiaBingClick()
    {
        base.OnArmZhuangJiaBingClick();
    }
    /// <summary>
    /// 侦察按钮点击事件
    /// </summary>
    public override void OnArmZhanDouJiClick()
    {
        base.OnArmZhanDouJiClick();
    }
    /// <summary>
    /// 迂回按钮点击事件
    /// </summary>
    public override void OnArmWuRenJiClick()
    {
        base.OnArmWuRenJiClick();
    }
    /// <summary>
    /// 确认按钮点击事件
    /// </summary>
    public override void OnArmEnsureClick()
    {
        base.OnArmEnsureClick();
        UIMgr.Instance.HidePanel<BattlePanelTwo>();
        UIMgr.Instance.ShowPanel<BattlePanelOne>();


    }
    /// <summary>
    /// 取消按钮点击事件
    /// </summary>
    public override void OnArmCancelClick()
    {
        base.OnArmCancelClick();
        UIMgr.Instance.HidePanel<BattlePanelTwo>();
    }
}
