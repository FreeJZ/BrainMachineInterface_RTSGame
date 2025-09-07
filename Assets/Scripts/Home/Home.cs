using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 营地类
/// </summary>
public class Home : MonoBehaviour, IHurt,IHurterInfo
{
    public LayerMask layerMask;
    //回血半径
    [SerializeField] private float hpRudis;
    //回血间隔时间
    [SerializeField]private float restoreHPDeltaTime;
    [SerializeField]private float restoreHP;
                    private float cutTime;
    
    [SerializeField] private float hp;
    public int maxAtCnt = 500;
    private List<ArmBase> arms;
    private Collider selfCol;

    int IHurterInfo.MaxAtkCnt => maxAtCnt;

    int IHurterInfo.CurAtkCnt { get; set; }

    private void Awake()
    {
        arms = new List<ArmBase>();
        selfCol = GetComponent<Collider>();
    }
    public void Hurt(IAtkerInfo atkerInfo)
    {
        hp -= atkerInfo.AtkVal;
        if(layerMask == LayerMask.GetMask("Player"))
        {
            EventCenter.Instance.Invoke<bool>("SetLevelData_setHomeState", hp <= 0);
        }
        else if(layerMask == LayerMask.GetMask("Enmy"))
        {
            EventCenter.Instance.Invoke<bool>("SetLevelData_setEnmyState", hp <= 0);
        }
    }

    private void Update()
    {
        CheckArmRoundSelf();
        RestoreArmHP();
    }

    private void CheckArmRoundSelf()
    {
        arms.Clear();

        Collider[] cols = Physics.OverlapSphere(transform.position, hpRudis, layerMask, QueryTriggerInteraction.Ignore);
        foreach (var item in cols)
        {

            if (item != selfCol)
            {
                arms.Add(item.GetComponent<ArmBase>());
            }
        }
    }

    private void RestoreArmHP()
    {
        if(arms.Count > 0)
        {
            cutTime += Time.deltaTime;
            if(cutTime >= restoreHPDeltaTime)
            {
                foreach (var arm in arms)
                {
                    arm.RestoreHP(restoreHP);
                }
                cutTime = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, hpRudis);
    }
}
