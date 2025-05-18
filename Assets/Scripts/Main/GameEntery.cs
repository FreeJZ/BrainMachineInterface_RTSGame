using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏入口
/// </summary>
public class GameEntery : MonoBehaviour
{
    private void Awake()
    {
        //数据加载
        DataMgr.Instance.LoadAllData();

        //SreachPath to other
        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.sreachPath, E_Command.rush, (aiInfo, flag) =>
        {
            return aiInfo.CurCommand == E_Command.rush && aiInfo.SearchPathToAtk(flag);
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.sreachPath, E_Command.back, (aiInfo, flag) =>
        {
            return aiInfo.CurCommand == E_Command.back && aiInfo.SearchPathToBack(flag);
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.sreachPath, E_Command.check, (aiInfo, flag) =>
        {
            return aiInfo.CurCommand == E_Command.check && aiInfo.SearchPathToCheck(flag);
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.sreachPath, E_Command.yuhui, (aiInfo, flag) =>
        {
            return aiInfo.CurCommand == E_Command.yuhui && aiInfo.SearchPathToYuHui(flag);
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.sreachPath, E_Command.defence, (aiInfo, flag) =>
        {
            return aiInfo.CurCommand == E_Command.defence && aiInfo.SearchPathToDefence(flag);
        });

        //rush to other
        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.rush, E_Command.sreachPath, (aiInfo, flag) =>
        {
            return aiInfo.AtkToSreachPath(flag);
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.rush, E_Command.back, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.AtkToBack(flag);
            if(canChange)
            {
                aiInfo.CurCommand = E_Command.back;
            }
            return canChange;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.rush, E_Command.check, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.AtkToCheck(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.check;
            }
            return canChange;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.rush, E_Command.yuhui, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.AtkToYuHui(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.yuhui;
            }
            return canChange;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.rush, E_Command.defence, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.AtkToDefence(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.defence;
            }
            return canChange;
        });

        //back to other
        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.back, E_Command.sreachPath, (aiInfo, flag) =>
        {
            return aiInfo.BackToSreachPath(flag);
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.back, E_Command.rush, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.BackToAtk(flag);
            if(canChange)
            {
                aiInfo.CurCommand = E_Command.rush;
            }

            return canChange;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.back, E_Command.check, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.BackToCheck(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.check;
            }

            return canChange;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.back, E_Command.yuhui, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.BackToYuHui(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.yuhui;
            }

            return canChange;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.back, E_Command.defence, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.BackToDefence(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.defence;
            }

            return canChange;
        });

        //check to other

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.check, E_Command.sreachPath, (aiInfo, flag) =>
        {
            return aiInfo.CheckToSreachPath(flag);
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.check, E_Command.rush, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.CheckToAtk(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.rush;
            }

            return canChange;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.check, E_Command.back, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.CheckToBack(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.back;
            }

            return canChange;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.check, E_Command.yuhui, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.CheckToYuHui(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.yuhui;
            }

            return canChange;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.check, E_Command.defence, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.CheckToDefence(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.defence;
            }

            return canChange;
        });

        //yuhui to other

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.yuhui, E_Command.sreachPath, (aiInfo, flag) =>
        {
            return aiInfo.YuHuiToSreachPath(flag);
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.yuhui, E_Command.rush, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.YuHuiToAtk(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.rush;
            }

            return canChange;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.yuhui, E_Command.back, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.YuHuiToBack(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.back;
            }

            return canChange;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.yuhui, E_Command.check, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.YuHuiToCheck(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.check;
            }

            return canChange;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.yuhui, E_Command.defence, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.YuHuiToDefence(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.defence;
            }

            return canChange;
        });

        //defence to other

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.defence, E_Command.sreachPath, (aiInfo, flag) =>
        {
            return aiInfo.DefenceToSearchPath(flag);
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.defence, E_Command.rush, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.DefenceToAtk(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.rush;
            }

            return canChange;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.defence, E_Command.back, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.DefenceToBack(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.back;
            }

            return canChange;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.defence, E_Command.check, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.DefenceToCheck(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.check;
            }

            return canChange;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.defence, E_Command.yuhui, (aiInfo, flag) =>
        {
            bool canChange = aiInfo.DefenceToYuHui(flag);
            if (canChange)
            {
                aiInfo.CurCommand = E_Command.yuhui;
            }

            return canChange;
        });
    }
}
