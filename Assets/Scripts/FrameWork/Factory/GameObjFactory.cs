using UnityEngine;

/// <summary>
/// 游戏对象和资源工厂
/// </summary>
public class GameObjFactory : Singleton<GameObjFactory>,IFactory<GameObject,string>
{
    /// <summary>
    /// 获取游戏对象
    /// </summary>
    /// <param name="path">预制体路径</param>
    /// <returns></returns>
    public GameObject GetItem(string path)
    {
        GameObject obj = Resources.Load<GameObject>(path);
        obj = GameObject.Instantiate(obj);
        return obj;
    }
    /// <summary>
    /// 获取资源
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    /// <param name="path">资源路径</param>
    /// <returns></returns>
    public T GetRes<T>(string path) where T : Object
    {
        T res = Resources.Load<T>(path);
        return res;
    }

    K IFactory<GameObject, string>.GetItem<K>(string flag)
    {
        throw new System.NotImplementedException();
    }
}