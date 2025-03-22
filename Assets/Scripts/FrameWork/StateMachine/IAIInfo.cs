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

}
