using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 面板基类
/// 所有面板继承该类,注意：面板的gameObject.name == 自定义的类名
/// </summary>
public class PanelBase : MonoBehaviour
{
    [SerializeField]
    [Tooltip("淡入淡出速度")]
    private float fadeSpeed;
    private bool toShow;
    private bool toHide;

    private CanvasGroup canvasGroup;
    private UnityAction action;
    protected virtual void Awake()
    {
        if(!TryGetComponent<CanvasGroup>(out canvasGroup))
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    protected virtual void Update()
    {
        if(toShow)
        {
            canvasGroup.alpha += Time.unscaledDeltaTime * fadeSpeed;
            if(canvasGroup.alpha >=1 ) toShow = false;
        }

        if(toHide)       
        {
            canvasGroup.alpha -= Time.unscaledDeltaTime * fadeSpeed;
            if (canvasGroup.alpha <= 0)
            {
                toHide = false;
                action?.Invoke();
            }
        }
    }

    /// <summary>
    /// 隐藏自己
    /// </summary>
    /// <param name="action">完全隐藏后的事件</param>
    public void HideMe(UnityAction action = null)
    {
        toHide = true;
        this.action = action;
        canvasGroup.alpha = 1;
    }
    /// <summary>
    /// 显示自己
    /// </summary>
    public void ShowMe()
    {
        toShow = true;
        canvasGroup.alpha = 0;
    }
}
