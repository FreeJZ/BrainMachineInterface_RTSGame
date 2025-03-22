using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// UI������
/// ��̬��ʾ�������
/// </summary>
public class UIMgr : Singleton<UIMgr>
{
    //��ŵ�ǰ��ʾ�����
    private Dictionary<Type,PanelBase> panelDic = new Dictionary<Type,PanelBase>();
    private Transform canvasTrans;
    private UIMgr()
    {
        //��̬����CanvasԤ����
        GameObject canvas = GameObjFactory.Instance.GetItem(ResPathConfig.UIPath + "Canvas");
        GameObject.DontDestroyOnLoad(canvas);
        canvasTrans = canvas.transform;
    }

    /// <summary>
    /// ��ʾ���
    /// </summary>
    /// <typeparam name="T">�������</typeparam>
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
    /// �������
    /// </summary>
    /// <typeparam name="T">�������</typeparam>
    /// <param name="action">������غ��������¼�</param>
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
