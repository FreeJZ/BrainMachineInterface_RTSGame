using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMgr : Singleton<PoolMgr>
{
    private Dictionary<string, PoolContainer> poolDic;
    private Transform levelRoot;
    private PoolMgr()
    {
        poolDic = new Dictionary<string, PoolContainer>();
        levelRoot = new GameObject(typeof(PoolMgr).Name).transform;
    }


    public GameObject PopObj(string name)
    {
        GameObject obj = null;
        if(poolDic.ContainsKey(name))
        {
            obj = poolDic[name].PopItem();
        }
        else
        {
            obj = GameObjFactory.Instance.GetItem(name);
            PoolObj poolObj;
            if (!obj.TryGetComponent<PoolObj>(out poolObj))
            {
                Debug.LogError(obj.name + "没有挂载PoolObj");
            }
            PoolContainer poolContainer = new PoolContainer(name, poolObj.maxCnt);
            poolContainer.Level.SetParent(levelRoot);
            poolDic.Add(name, poolContainer);
            PushObj(obj);
            obj = poolDic[name].PopItem();
        }
        return obj;
    }

    public void PushObj(GameObject obj)
    {
        PoolObj poolObj;
        if(!obj.TryGetComponent<PoolObj>(out poolObj))
        {
            Debug.LogError(obj.name + "没有挂载PoolObj");
        }
        if(poolDic.ContainsKey(poolObj.pathName))
        {
            poolDic[poolObj.pathName].PushItem(obj);
        }
    }

    public void Clear()
    {
        poolDic.Clear();
    }
}
