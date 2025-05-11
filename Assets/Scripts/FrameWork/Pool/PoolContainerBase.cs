using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolContainerBase
{
    protected string name;
    //存放未使用物品的容器
    protected Stack<Object> waitItems;
    //存放使用中的物品
    protected List<Object> usingItems;
    //容器容量
    protected int capacity;

    protected Transform level;


    public Transform Level => level;
    //容器容量
    public int Capacity { get => capacity; }
    //物品容量
    public int Count { get => waitItems.Count + usingItems.Count; }

    public PoolContainerBase(string name, int capacity = 10)
    {
        this.name = name;
        this.capacity = capacity;
        waitItems = new Stack<Object>();
        usingItems = new List<Object>();
        level = new GameObject(name).transform;
    }

    public abstract Object PopObject();

    public abstract void PushObjec(Object item);

    public void Clear()
    {
        waitItems.Clear();
        usingItems.Clear();
    }
}
