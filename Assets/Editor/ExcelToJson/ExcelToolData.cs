
using UnityEngine;

[CreateAssetMenu(menuName ="SO/ExcelToolDataSO")]
public class ExcelToolData : ScriptableObject
{
    public string defaultExcelStorePath;
    public string defaultdataClassStorePath;
    public string defaultjsonFileStorePath;

    public bool isCustom;
    
    public string customExcelStorePath;
    public string customdataClassStorePath;
    public string customjsonFileStorePath;
}
