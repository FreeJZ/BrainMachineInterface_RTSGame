using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ȡ״̬��ʹ���ߵ� һЩ������Ϣ
/// </summary>
public interface IAIInfo 
{ 
    /// <summary>
    /// �Ƿ񹥻�
    /// </summary>
    bool IsAtk { get; }
    /// <summary>
    /// �Ƿ���
    /// </summary>
    bool IsBack { get; }
    /// <summary>
    /// �Ƿ����
    /// </summary>
    bool IsDefence { get; }
    /// <summary>
    /// �Ƿ��ػ�
    /// </summary>
    bool IsYuHui {  get; }
    /// <summary>
    /// �Ƿ����
    /// </summary>
    bool IsCheck { get; }
    /// <summary>
    /// �Ƿ�Ѱ·
    /// </summary>
    bool IsSerachPath { get; }
    /// <summary>
    /// �Ƿ����
    /// </summary>
    bool IsIdle { get; }
    /// <summary>
    /// �л�����
    /// </summary>
    /// <param name="animationName">������</param>
    void ChangeAnimation(string animationName);
    /// <summary>
    /// ������������
    /// </summary>
    /// <param name="targetNormalizedTime">������Ŀ��ʱ�䣨�����Ĳ��Ž���[0,1])</param>
    /// <returns></returns>
    bool AnimationListener(string curAniimationName, float targetNormalizedTime);

}
