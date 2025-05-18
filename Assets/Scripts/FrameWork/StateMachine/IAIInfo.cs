using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 获取状态机使用者的 一些属性信息
/// </summary>
public interface IAIInfo 
{
    E_Command CurCommand { get; set; }
    bool IsSetCommand { get; }
    bool SearchPathToAtk(int flag);
    bool SearchPathToDefence(int flag);  
    bool SearchPathToBack(int flag);
    bool SearchPathToYuHui(int flag);
    bool SearchPathToCheck(int flag);

    bool AtkToSreachPath(int flag);
    bool AtkToDefence(int flag);
    bool AtkToBack(int flag);
    bool AtkToYuHui(int flag);
    bool AtkToCheck(int flag);

    bool DefenceToSearchPath(int flag);
    bool DefenceToAtk(int flag);
    bool DefenceToBack(int flag);
    bool DefenceToYuHui(int flag); 
    bool DefenceToCheck(int flag);

    bool BackToSreachPath(int flag);
    bool BackToAtk(int flag);   
    bool BackToDefence(int flag);
    bool BackToYuHui(int flag);
    bool BackToCheck(int flag);

    bool YuHuiToSreachPath(int flag);
    bool YuHuiToAtk(int flag);
    bool YuHuiToDefence(int flag);  
    bool YuHuiToBack(int flag);
    bool YuHuiToCheck(int flag);

    bool CheckToSreachPath(int flag);
    bool CheckToAtk(int flag);
    bool CheckToDefence(int flag);
    bool CheckToBack(int flag);
    bool CheckToYuHui(int flag);

    /// <summary>
    /// 切换动画
    /// </summary>
    /// <param name="animationName">动画名</param>
    void ChangeAnimation(string animationName);
    /// <summary>
    /// 动画监听函数
    /// </summary>
    /// <param name="targetNormalizedTime">监听的目标时间（动画的播放进度[0,1])</param>
    /// <returns></returns>
    bool AnimationListener(string curAniimationName, float targetNormalizedTime);

    //攻击状态回调函数 书写具体逻辑
    void AtkStateUpdate();
    //攻击状态回调函数 书写具体逻辑
    void AtkStateEnter();
    //攻击状态回调函数 书写具体逻辑
    void AtkStateExit();


    //撤退状态回调函数 书写具体逻辑
    void BackStateUpdate();
    //撤退状态回调函数 书写具体逻辑
    void BackStateEnter();
    //撤退状态回调函数 书写具体逻辑
    void BackStateExit();


    //防御状态回调函数 书写具体逻辑
    void DefenceStateUpdate();
    //防御状态回调函数 书写具体逻辑
    void DefenceStateEnter();
    //防御状态回调函数 书写具体逻辑
    void DefenceStateExit();


    //迂回状态回调函数 书写具体逻辑
    void YuHuiStateUpdate();
    //迂回状态回调函数 书写具体逻辑
    void YuHuiStateEnter();
    //迂回状态回调函数 书写具体逻辑
    void YuHuiStateExit();


    //侦查状态回调函数 书写具体逻辑
    void CheckStateUpdate();
    //侦查状态回调函数 书写具体逻辑
    void CheckStateEnter();
    //侦查状态回调函数 书写具体逻辑
    void CheckStateExit();

    //寻路状态回调函数 书写具体逻辑
    void SearchPathStateUpdate();
    //寻路状态回调函数 书写具体逻辑
    void SearchPathStateEnter();
    //寻路状态回调函数 书写具体逻辑
    void SearchPathStateExit();



    //待机状态回调函数 书写具体逻辑
    void IdleStateUpdate();
    //待机状态回调函数 书写具体逻辑
    void IdleStateEnter();
    //待机状态回调函数 书写具体逻辑
    void IdleStateExit();
   

    //死亡状态回调函数 书写具体逻辑
    void DeadStateUpdate();
    //死亡状态回调函数 书写具体逻辑
    void DeadStateEnter();
    //死亡状态回调函数 书写具体逻辑
    void DeadStateExit();

}
