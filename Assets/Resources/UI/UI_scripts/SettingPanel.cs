using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingPanel : PanelBase
{
    public Button apply;
    public Button back;
    public Button reset;

    public Slider musicVolume;
    public Slider soundVolume;
    public Toggle fullscreen;

    private void Start()
    {
                apply.onClick.AddListener(Apply);
                back.onClick.AddListener(Back);
                reset.onClick.AddListener(ResetSetting);
                fullscreen.onValueChanged.AddListener(Fullscreen);
                musicVolume.onValueChanged.AddListener(MusicVolume);
                soundVolume.onValueChanged.AddListener(SoundVolume);

    }

    private void Apply()
    {
        this.HideMe();
    }

    private void Back()
    {
       this.HideMe();
    }
    private void ResetSetting()
    {
      
    }

    private void Fullscreen(bool isOn)
    {
       
    }

    private void MusicVolume(float value)
    {
       
    }

    private void SoundVolume(float value)
    {
       
    }

}
