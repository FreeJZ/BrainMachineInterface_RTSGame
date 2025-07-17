using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SummaryPanel : PanelBase
{
    public GameObject gameInfo;
    public Image icon;

    
    private Text _gameInfotext;
    private Text _icontext;
    private void Start()
    {
        Init();
        //判断胜利失败
         if (true) //条件
         {
             _icontext.text = "模拟演算成功";
         }
         else
         {
             _icontext.text = "模拟演算失败";
         }
        
        //得到游戏信息
        float gameTime = 1f;
        string gameMap = "城市";
        string gameMode = "防守";
        StringBuilder sb = new StringBuilder();
        sb.Append("时长:");
        sb.Append(gameTime);
        sb.Append("分钟");
        sb.Append(" | 地图:");
        sb.Append(gameMap);
        sb.Append(" | 模式:");
        sb.Append(gameMode);
        
        _gameInfotext.text = sb.ToString();

    }

    private void Init()
    {
        _gameInfotext = gameInfo.GetComponentInChildren<Text>();
        _icontext = icon.gameObject.GetComponentInChildren<Text>();
    }
    
}
