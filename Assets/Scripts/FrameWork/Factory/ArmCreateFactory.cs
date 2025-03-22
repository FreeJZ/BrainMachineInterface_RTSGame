using UnityEngine;

public class ArmCreateFactory : Singleton<ArmCreateFactory>, IFactory<ArmBase, E_ArmType>
{
    public ArmBase GetItem(E_ArmType flag)
    {
        GameObject obj = GameObjFactory.Instance.GetItem(ResPathConfig.ArmPrefabPath + flag.ToString());
        return obj.GetComponent<ArmBase>();
    }

    public K GetItem<K>(E_ArmType flag) where K : ArmBase
    {
        return GetItem(flag) as K;
    }
}