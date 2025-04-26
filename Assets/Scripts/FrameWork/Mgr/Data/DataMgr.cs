using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DataMgr : Singleton<DataMgr>
{
    //兵种配置数据
    private Dictionary<string, ArmData> armDataDic;
    //关卡配置数据
    private Dictionary<string, LevelData> levelDataDic;
    //转换条件配置数据
    private Dictionary<E_Command, Dictionary<E_Command, TslData>> tslDataDic;
    private DataMgr()
    {
        armDataDic = new Dictionary<string, ArmData>();
        levelDataDic = new Dictionary<string, LevelData>();
        tslDataDic = new Dictionary<E_Command, Dictionary<E_Command, TslData>>();
    }

    public ArmData GetArmData(string key)
    {
        if(!armDataDic.ContainsKey(key)) return null;
        return armDataDic[key];
    }

    public LevelData GetLevelData(string key)
    {
        if (!levelDataDic.ContainsKey(key)) return null;
        return levelDataDic[key];
    }

    public TslData GetTslData(E_Command from,E_Command to)
    {
        if (!tslDataDic.ContainsKey(from)) return null;
        Dictionary<E_Command,TslData> dic = tslDataDic[from];
        if (dic == null || !dic.ContainsKey(to)) return null;
        return tslDataDic[from][to];
    }
    public void LoadTslData()
    {
        Array enumArr = Enum.GetValues(typeof(E_Command));
        foreach(E_Command fc in enumArr)
        {
            foreach(E_Command sc in enumArr)
            {
                if(fc != sc)
                {
                    TslData data = new TslData();
                    string fileName = fc + "To" + sc;
                    List<Pair> list = JsonMgr.Instance.Load<List<Pair>>(fileName);
                    if (list == null) continue;
                    
                    data.pairsList = list;
                    
                    if (!tslDataDic.ContainsKey(fc))
                    {
                        tslDataDic.Add(fc, new Dictionary<E_Command, TslData>());
                    }
                    tslDataDic[fc].Add(sc, data);
                }
            }
        }
    }

    public void LoadLevelData()
    {
        List<LevelData> list = JsonMgr.Instance.Load<List<LevelData>>("Level");
        for(int i = 0;i< list.Count;i++)
        {
            levelDataDic.Add(list[i].id, list[i]);
        }
    }

    public void LoadArmData()
    {
        List<ArmData> list = JsonMgr.Instance.Load<List<ArmData>>("Arm");
        for (int i = 0; i < list.Count; i++)
        {
            armDataDic.Add(list[i].id, list[i]);
        }
    }

    public void LoadAllData()
    {
        LoadTslData();
        LoadLevelData();
        LoadArmData();
    }

    public void SaveAllData()
    {

    }

}
