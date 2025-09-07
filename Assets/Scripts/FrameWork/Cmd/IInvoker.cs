using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
public interface IInvoker
{
    List<ComandBase> CmdList { get; set; }

    int curIndex { get; set; }

    Stack<int> undoStack { get; set; }

    Stack<int> redoStack { get; set; }    

    public void Init()
    {
        CmdList = new List<ComandBase>();
        undoStack = new Stack<int>();
        redoStack = new Stack<int>();
        curIndex = -1;
    }
    public void ChangeNextCmd()
    {
        if(curIndex != -1)
        {
            CmdList[curIndex].Exit(() =>
            {
                undoStack.Push(curIndex);
                ++curIndex;
                if(redoStack.Count > 0 && redoStack.Peek() == curIndex)
                {
                    redoStack.Pop();
                }
                if (curIndex < CmdList.Count)
                    CmdList[curIndex].Enter();
            });
        }
        else
        {
            ++curIndex;
            if (curIndex < CmdList.Count)
                CmdList[curIndex].Enter();
        }
    }

    /// <summary>
    /// 执行当前命令
    /// </summary>
    public bool Exute()
    {
        if (curIndex == CmdList.Count) return true;
        
        bool curCmdIsOver = CmdList[curIndex].Excute();
        if (curCmdIsOver)
        {
            ChangeNextCmd();
        }
        return false;
    }
    /// <summary>
    /// 回退上一个命令
    /// </summary>
    public void Undo()
    {
        if (undoStack.Count == 0)
        {
            Debug.Log("没有前一个命令可以回退");
            return;
        }
        redoStack.Push(curIndex);
        CmdList[curIndex].Exit(() =>
        {
            curIndex = undoStack.Pop();
            CmdList[curIndex].Enter();
        });
        
    }
    /// <summary>
    /// 前进下一个命令
    /// </summary>
    public void Redo()
    {
        if (redoStack.Count == 0)
        {
            Debug.Log("没有下一个命令可以前进");
            return;
        }
        undoStack.Push(curIndex);
        CmdList[curIndex].Exit(() =>
        {
            curIndex = redoStack.Pop();
            CmdList[curIndex].Enter();
        });
    }
    /// <summary>
    /// 添加命令
    /// </summary>
    /// <param name="cmd"></param>
    public void AddCmd(ComandBase cmd)
    {
        CmdList.Add(cmd);
    }
}
