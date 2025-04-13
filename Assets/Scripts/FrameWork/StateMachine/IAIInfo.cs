using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 获取状态机使用者的 一些属性信息
/// </summary>
public interface IAIInfo 
{ 
    /// <summary>
    /// 是否攻击
    /// </summary>
    bool IsAtk { get; }
    /// <summary>
    /// 是否撤退
    /// </summary>
    bool IsBack { get; }
    /// <summary>
    /// 是否防御
    /// </summary>
    bool IsDefence { get; }
    /// <summary>
    /// 是否迂回
    /// </summary>
    bool IsYuHui {  get; }
    /// <summary>
    /// 是否侦查
    /// </summary>
    bool IsCheck { get; }
    /// <summary>
    /// 是否寻路
    /// </summary>
    bool IsSerachPath { get; }
    /// <summary>
    /// 是否待机
    /// </summary>
    bool IsIdle { get; }
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

}
