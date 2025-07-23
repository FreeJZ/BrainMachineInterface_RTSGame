using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginPanel : PanelBase
{
    public Button start;
    public Button load;
    public Button setting;
    public Button exit;
    private void Start()
    {
        start.onClick.AddListener(StartGame);
        load.onClick.AddListener(LoadGame);
        setting.onClick.AddListener(Setting);
        exit.onClick.AddListener(ExitGame);
    }
    
    void StartGame()
    {
        this.HideMe(() => 
        {
            SceneManager.LoadScene("Game");
        });
    }
    void LoadGame()
    { 
        UIMgr.Instance.ShowPanel<LoadPanel>();
       
    }
    void Setting()
    {
       UIMgr.Instance.ShowPanel<SettingPanel>();
      
    }
    void ExitGame()
    {
        Application.Quit();
    }
}
