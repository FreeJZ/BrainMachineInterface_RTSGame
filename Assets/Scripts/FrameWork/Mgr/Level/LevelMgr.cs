using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr : Singleton<LevelMgr>
{
    private LevelData levelData;
    public LevelData LevelData => levelData;

    //我方营地是否死亡
    private bool homeIsDead;
    public bool HomeIsDead => homeIsDead;
    //地方营地是否死亡
    private bool enmyIsDead;
    public bool EnmyIsDead => enmyIsDead;
    private LevelMgr()
    {
        //Test
        levelData = DataMgr.Instance.GetLevelData("Test1");

        MonoMgr.Instance.AddUpdateEvent(LevelStateUpdate);
        EventCenter.Instance.AddEventListener<bool>("SetLevelData_setHomeState", SetHomeIsDead);
        EventCenter.Instance.AddEventListener<bool>("SetLevelData_setEnmyState", SetEnmyIsDead);
    }

    ~LevelMgr()
    {
        MonoMgr.Instance.RemoveUpdateEvent(LevelStateUpdate);
        EventCenter.Instance.RemoveEventListener("SetLevelData_setHomeState");
        EventCenter.Instance.RemoveEventListener("SetLevelData_setEnmyState");
    }
    /// <summary>
    /// 设置我方营地状态的回调函数
    /// </summary>
    /// <param name="state"></param>
    private void SetHomeIsDead(bool state)
    {
        homeIsDead = state;
    }
    /// <summary>
    /// 设置地方营地状态的回调函数
    /// </summary>
    /// <param name="state"></param>
    private void SetEnmyIsDead(bool state)
    {
        enmyIsDead = state;
    }

    /// <summary>
    /// 关卡状态回调函数
    /// </summary>
    private void LevelStateUpdate()
    {
        if(homeIsDead)
        {
            //显示提示面板 失败
            Debug.Log("游戏失败");
        }

        if(EnmyIsDead)
        {
            //显示提示面板 胜利
            Debug.Log("游戏胜利");
        }
    }

}
