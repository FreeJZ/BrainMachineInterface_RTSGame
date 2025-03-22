using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// ������
/// �������̳и���,ע�⣺����gameObject.name == �Զ��������
/// </summary>
public class PanelBase : MonoBehaviour
{
    [SerializeField]
    [Tooltip("���뵭���ٶ�")]
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
    /// �����Լ�
    /// </summary>
    /// <param name="action">��ȫ���غ���¼�</param>
    public void HideMe(UnityAction action = null)
    {
        toHide = true;
        this.action = action;
        canvasGroup.alpha = 1;
    }
    /// <summary>
    /// ��ʾ�Լ�
    /// </summary>
    public void ShowMe()
    {
        toShow = true;
        canvasGroup.alpha = 0;
    }
}
