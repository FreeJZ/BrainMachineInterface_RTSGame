using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipPanel : PanelBase
{

    public Button button;
    public Text textinof;
    private void Start()
    {
        button.onClick.AddListener(() => 
        {
            UIMgr.Instance.HidePanel<TipPanel>();
        });
    }

    public void ChangeInfo(string info)
    {
        textinof.text = info;
    }
}
