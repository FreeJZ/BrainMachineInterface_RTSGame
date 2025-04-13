using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public ArmBase arm;
    private void Awake()
    {
        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.sreachPath, E_Command.rush, (aiInfo,flag) =>
        {
            switch(flag)
            {
                case 0:
                    return true;
            }
            return aiInfo.IsAtk;
        });
        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.rush, E_Command.sreachPath, (aiInfo, flag) =>
        {
            return false;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.back, E_Command.sreachPath, (aiInfo, flag) =>
        {
            return false;
        });
        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.sreachPath, E_Command.back, (aiInfo, flag) =>
        {
            return true;
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.rush, E_Command.back, (aiInfo, flag)  =>
        {
            return Input.GetKeyDown(KeyCode.W);
        });

        TranslitatoinInvokeEventFactory.Instance.AddTransilatoinEvent(E_Command.back, E_Command.rush, (aiInfo, flag) =>
        {
            return Input.GetKeyDown(KeyCode.S);
        });

        UIMgr.Instance.ShowPanel<TestPanel>();

    }
    // Start is called before the first frame update
    void Start()
    {
        arm.SetCommand(E_Command.rush, E_Command.back,arm,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            arm.SetCommand(E_Command.back, E_Command.rush, arm, 0, 0);
            UIMgr.Instance.HidePanel<TestPanel>(() =>
            {
                UIMgr.Instance.ShowPanel<TestPanel>();
                Debug.Log("TestPanel--Hide,Other--Show");
            });
        }

    }
}
