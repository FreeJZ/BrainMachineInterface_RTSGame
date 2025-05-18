using UnityEngine;

public class LevelData
{
	public string id;
	public float homePosX;
	public float homePosY;
	public float homePosZ;
	public float enmyPosX;
	public float enmyPosY;
	public float enmyPosZ;
	public int arm_BBCnt;
	public int arm_PBCnt;
	public int arm_WRJCnt;
	public int arm_ZDJCnt;
	public int arm_ZJBCnt;
	public int arm_ToTalCnt;

	public Vector3 HomePoint=>new Vector3(homePosX,homePosY,homePosZ);
	public Vector3 EnemyPoint=>new Vector3(enmyPosX,enmyPosY,enmyPosZ);
}
