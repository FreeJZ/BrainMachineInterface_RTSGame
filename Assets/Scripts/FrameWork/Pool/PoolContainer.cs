using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolContainer : PoolContainerBase
{
    public PoolContainer(string name, int capacity = 10) : base(name, capacity)
    {
    }

    public GameObject PopItem()
    {
        return PopObject() as GameObject;
    }
    public void PushItem(GameObject item)
    {
        PushObjec(item);
    }
    public override Object PopObject()
    {
        Object item = null;
        if(Count < Capacity)
        {
            item = GameObjFactory.Instance.GetItem(name);
            usingItems.Add(item);
        }
        else if(waitItems.Count > 0)
        {
            item = waitItems.Pop();
            usingItems.Add(item);
        }
        else
        {
            item = usingItems[0];
            usingItems.RemoveAt(0);
            usingItems.Add(item);
        }
        (item as GameObject).transform.parent = null;
        (item as GameObject).SetActive(true);
        return item;
    }

    public override void PushObjec(Object item)
    {
        (item as GameObject).transform.SetParent(level);
        (item as GameObject).SetActive(false);
        waitItems.Push(item);
        usingItems.Remove(item);
    }
}
