using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// UI管理器
/// 动态显示隐藏面板
/// </summary>
public class UIMgr : Singleton<UIMgr>
{
    //存放当前显示的面板
    private Dictionary<Type,PanelBase> panelDic = new Dictionary<Type,PanelBase>();
    private Transform canvasTrans;
    private UIMgr()
    {
        //动态生成Canvas预设体
        GameObject canvas = GameObjFactory.Instance.GetItem(ResPathConfig.UIPath + "Canvas");
        GameObject.DontDestroyOnLoad(canvas);
        canvasTrans = canvas.transform;
    }

    /// <summary>
    /// 显示面板
    /// </summary>
    /// <typeparam name="T">面板类型</typeparam>
    public void ShowPanel<T>()
    {
        if (panelDic.ContainsKey(typeof(T))) return;
        GameObject panel = GameObjFactory.Instance.GetItem(ResPathConfig.UIPath + typeof(T).Name);
        panel.transform.SetParent(canvasTrans, false);
        PanelBase panelBase = panel.GetComponent<PanelBase>();
        panelDic.Add(typeof(T),panelBase);
        panelBase.ShowMe();
    }
    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <typeparam name="T">面板类型</typeparam>
    /// <param name="action">面板隐藏后所做的事件</param>
    public void HidePanel<T>(UnityAction action = null)
    {
        if (!panelDic.ContainsKey(typeof(T))) return;
        PanelBase panelBase = panelDic[typeof(T)];
        panelBase.HideMe(() =>
        {
            panelBase.transform.SetParent(null);
            GameObject.Destroy(panelBase.gameObject);
            action?.Invoke();
        });
        panelDic.Remove(typeof(T));
    }
}
