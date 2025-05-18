using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TslBtnInfo : MonoBehaviour
{
    public Text tip;
    [SerializeField] private string content;
    [SerializeField] private int mapFlag;

    public int MapFlag => mapFlag;
    private void Awake()
    {
        tip = GetComponentInChildren<Text>();
    }
    public void Init(string content, int mapFlag)
    {
        this.content = content;
        this.mapFlag = mapFlag;
        tip.text = content;
    }

}
