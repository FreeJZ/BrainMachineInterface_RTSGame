using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelPanel : PanelBase
{
    public List<Button> levelButtons;
    
    public Button btnPass; // 通关按钮

    private int unlockedLevel = 0; // 已解锁的最大关卡索引
    private const string UnlockedLevelKey = "UnlockedLevel";

    protected void Awake()
    {
        PlayerPrefs.SetInt(UnlockedLevelKey, 0);// HACK: 初始化已解锁关卡为0，实际使用时应移除此行
        // 读取已解锁的最大关卡索引
        unlockedLevel = PlayerPrefs.GetInt(UnlockedLevelKey, 0);
    }

    protected void AddButtonListeners()
    {

        btnPass.onClick.AddListener(() =>
        {
            // REVIEW:模拟通关逻辑
            int currentLevel = unlockedLevel; // 假设当前关卡就是已解锁的最大关卡
            UnlockNextLevel(currentLevel);
        });
    }
    
    protected void Start()
    {
       
        AddButtonListeners();

        // 刷新关卡按钮状态
        RefreshLevelButtons();
    }

    protected override void Update()
    {
        
    }

    private void RefreshLevelButtons()
    {
        for (int i = 0; i < levelButtons.Count; i++)
        {
            bool isUnlocked = i <= unlockedLevel;
            levelButtons[i].interactable = isUnlocked;
            var colors = levelButtons[i].colors;
            colors.normalColor = isUnlocked ? Color.white : Color.gray;
            levelButtons[i].colors = colors;
        }
    }

    // 通关后调用此方法解锁下一关
    public void UnlockNextLevel(int currentLevel)
    {
        if (currentLevel >= unlockedLevel && currentLevel < levelButtons.Count - 1)
        {
            unlockedLevel = currentLevel + 1;
            PlayerPrefs.SetInt(UnlockedLevelKey, unlockedLevel);
            PlayerPrefs.Save();//HACK:临时的保存数据的方法
            RefreshLevelButtons();
        }
    }
}
