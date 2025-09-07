using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginPanel : PanelBase
{
    public Button start;
    
    private void Start()
    {
        start.onClick.AddListener(StartGame);
    }
    
    void StartGame()
    {
        this.HideMe(() => 
        {
            SceneManager.LoadScene("Game");
        });
    }
}
