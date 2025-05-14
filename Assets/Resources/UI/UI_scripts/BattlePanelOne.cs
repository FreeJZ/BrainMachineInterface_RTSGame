using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePanelOne : BattlePanelBase
{
    /// <summary>
    /// 步兵按钮点击事件
    /// </summary>
    public override void OnArmBuBingClick()
    {
        base.OnArmBuBingClick();
    }
    /// <summary>
    /// 炮兵按钮点击事件
    /// </summary>
    public override void OnArmPaoBingClick()
    {
        base.OnArmPaoBingClick();
    }
    /// <summary>
    /// 装甲兵按钮点击事件
    /// </summary>
    public override void OnArmZhuangJiaBingClick()
    {
        base.OnArmZhuangJiaBingClick();
    }
    /// <summary>
    /// 战斗机按钮点击事件
    /// </summary>
    public override void OnArmZhanDouJiClick()
    {
        base.OnArmZhanDouJiClick();
    }
    /// <summary>
    /// 无人机按钮点击事件
    /// </summary>
    public override void OnArmWuRenJiClick()
    {
       base.OnArmWuRenJiClick();
    }
    /// <summary>
    /// 确定按钮点击事件
    /// </summary>
    public override void OnArmEnsureClick()
    {
        base.OnArmEnsureClick();
        UIMgr.Instance.HidePanel<BattlePanelOne>();
        UIMgr.Instance.ShowPanel<BattlePanelTwo>();
       
    }
    /// <summary>
    /// 取消按钮点击事件
    /// </summary>
    public override void OnArmCancelClick()
    {
       base.OnArmCancelClick();
       UIMgr.Instance.HidePanel<BattlePanelOne>();
    }
}
