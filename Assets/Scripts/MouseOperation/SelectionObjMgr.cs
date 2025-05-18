using System.Collections.Generic;
using UnityEngine;

public class SelectionObjMgr : Singleton<SelectionObjMgr>
{
    private List<ArmBase> m_ArmBaseList;
    private SelectionObjMgr()
    {
        m_ArmBaseList = new List<ArmBase>();
    }

    public List<ArmBase> ArmBaseList => m_ArmBaseList;

    public void AddSelecctionObj(Collider collider)
    {
        ArmBase armBase;
        if (!collider.TryGetComponent<ArmBase>(out armBase)) Debug.LogError(collider.name + "没有挂载 " + typeof(ArmBase).Name + " 脚本");
        if(!m_ArmBaseList.Contains(armBase)) m_ArmBaseList.Add(armBase);
    }

    public void AddSelectionObjs(params Collider[] cols)
    {
        for(int i = 0;i < cols.Length;i++)
        {
            AddSelecctionObj(cols[i]);
        }
    }

    public void AddSelectionObjsRange(List<ArmBase> armList)
    {
        for(int i = 0;i<armList.Count;i++)
        {
            if(!m_ArmBaseList.Contains(armList[i])) m_ArmBaseList.Add(armList[i]);
        }
    }

    public void Clear()
    {
        m_ArmBaseList.Clear();
    }
}