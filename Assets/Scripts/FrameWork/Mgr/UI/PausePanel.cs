using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : PanelBase
{
    public Button resume;
    public Button exit;
    public void Start()
    {
        resume.onClick.AddListener(ResumeGame);
        exit.onClick.AddListener(ExitGame);
    }

    public void ResumeGame()
    {
        
    }
    public void ExitGame()
    {
        
    }
}
