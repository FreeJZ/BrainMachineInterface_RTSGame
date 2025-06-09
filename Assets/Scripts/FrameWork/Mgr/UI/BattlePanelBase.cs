using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattlePanelBase : PanelBase
{
    [Tooltip("进攻")]
    public Button armBuBing;
    [Tooltip("撤退")]
    public Button armPaoBing;
    [Tooltip("防御")]
    public Button armZhuangJiaBing;
    [Tooltip("侦察")]
    public Button armZhanDouJi;
    [Tooltip("迂回")]
    public Button armWuRenJi;
    [Tooltip("确定")]
    public Button armEnsure;
    [Tooltip("取消")]
    public Button armCancel;

    void Start()
    {
        armBuBing.onClick.AddListener(OnArmBuBingClick);
        armPaoBing.onClick.AddListener(OnArmPaoBingClick);
        armZhuangJiaBing.onClick.AddListener(OnArmZhuangJiaBingClick);
        armZhanDouJi.onClick.AddListener(OnArmZhanDouJiClick);
        armWuRenJi.onClick.AddListener(OnArmWuRenJiClick);
        armEnsure.onClick.AddListener(OnArmEnsureClick);
        armCancel.onClick.AddListener(OnArmCancelClick);
    }

    public virtual void OnArmBuBingClick()
    {
        Debug.Log("OnArmBuBingClick");
    }

    public virtual void OnArmPaoBingClick()
    {
        Debug.Log("OnArmPaoBingClick");
    }

    public virtual void OnArmZhuangJiaBingClick()
    {
        Debug.Log("OnArmZhuangJiaBingClick");
    }

    public virtual void OnArmZhanDouJiClick()
    {
        Debug.Log("OnArmZhanDouJiClick");
    }

    public virtual void OnArmWuRenJiClick()
    {
        Debug.Log("OnArmWuRenJiClick");
    }

    public virtual void OnArmEnsureClick()
    {
        Debug.Log("OnArmEnsureClick");
    }

    public virtual void OnArmCancelClick()
    {
        Debug.Log("OnArmCancelClick");
    }
}
