using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResOperationMgr : MonoSingleton<ResOperationMgr>
{
  
    /// <summary>
    /// 设置指令
    /// </summary>
    /// <param name="fristCmd">第一指令</param>
    /// <param name="secondCmd">第二指令</param>
    /// <param name="arm">兵种自身</param>
    /// <param name="fristCmd2SecondCmdFlag">指令1->指令2的转换条件的标识，区分使用哪个转换条件</param>
    /// <param name="secondCmd2FristCmdFlag">指令2->指令1...</param>
    /// <param name="searchPath2FcFlag">寻路->指令1...</param>
    /// <param name="fc2SearchPathFlag">指令1->寻路...</param>
    public void SetCommand(ArmBase arm,E_Command fristCmd, E_Command secondCmd,int fristCmd2SecondCmdFlag, int secondCmd2FristCmdFlag, int searchPath2FcFlag = 0, int fc2SearchPathFlag = 0)
    {
        arm.SetCommand(fristCmd, secondCmd, arm,fristCmd2SecondCmdFlag, secondCmd2FristCmdFlag, searchPath2FcFlag, fc2SearchPathFlag);
    }
}
