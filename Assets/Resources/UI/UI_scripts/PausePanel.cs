using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : PanelBase
{
    public Button resume;
    public Button settings;
    public Button exit;
    public void Start()
    {
        resume.onClick.AddListener(ResumeGame);
        settings.onClick.AddListener(OpenSettings);
        exit.onClick.AddListener(ExitGame);
    }

    public void ResumeGame()
    {
        this.HideMe();
    }
    public void OpenSettings()
    {
        UIMgr.Instance.ShowPanel<LoadPanel>();
       
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
