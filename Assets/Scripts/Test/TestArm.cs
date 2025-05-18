using UnityEngine;

public class TestArm : ArmBase
{
    private bool isDie = false;
    protected override void Update()
    {
        base.Update();
        if(!isDie && Input.GetKeyDown(KeyCode.V))
        {
           Debug.Log("死亡");
           isDie = true;
        }
    }
}