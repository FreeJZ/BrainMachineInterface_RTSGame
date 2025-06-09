using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelPanel : PanelBase
{
    public Button btnStart;
    public List<Button> levelButtons;
    public Button btnExit;
    private LineRenderer _line;
    
    public Button btnPass; // 通关按钮

    private int unlockedLevel = 0; // 已解锁的最大关卡索引
    private const string UnlockedLevelKey = "UnlockedLevel";

    protected void Awake()
    {
        PlayerPrefs.SetInt(UnlockedLevelKey, 0); // HACK: 初始化已解锁关卡为0，实际使用时应移除此行
        // 读取已解锁的最大关卡索引
        unlockedLevel = PlayerPrefs.GetInt(UnlockedLevelKey, 0);
    }

    protected void AddButtonListeners()
    {
        btnStart.onClick.AddListener(() =>
        {
           //TODO:开始按钮逻辑
            
        });

        btnExit.onClick.AddListener(() =>
        {
            // TODO:退出按钮逻辑
        });

        btnPass.onClick.AddListener(() =>
        {
            // 模拟通关逻辑
            int currentLevel = unlockedLevel; // 假设当前关卡就是已解锁的最大关卡
            UnlockNextLevel(currentLevel);
        });
    }
    
    protected void Start()
    {
       
        AddButtonListeners();
        
        // 初始化LineRenderer
        var lineObj = new GameObject("LevelLines");
        // 关键：不要作为Canvas子物体，直接放到场景根节点
        lineObj.transform.SetParent(null);
        _line = lineObj.AddComponent<LineRenderer>();
        
        // 设置LineRenderer属性
        _line.startWidth = 1f; // UI空间下需要更大的宽度
        _line.endWidth = 1f;
        _line.startColor = Color.yellow; // 使用黄色便于观察
        _line.endColor = Color.yellow;
        _line.material = new Material(Shader.Find("Sprites/Default"));
        _line.sortingOrder = 1;

        // 刷新关卡按钮状态
        RefreshLevelButtons();
    }

    protected override void Update()
    {
        _line.positionCount = levelButtons.Count;
        for (int i = 0; i < levelButtons.Count; i++)
        {
            RectTransform rectTransform = levelButtons[i].GetComponent<RectTransform>();
            Vector3 worldPos = rectTransform.position;
            worldPos.z = worldPos.z+0.7f;
            
            _line.SetPosition(i, worldPos);
        }
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
