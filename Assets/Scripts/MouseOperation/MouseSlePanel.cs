using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 鼠标操作面板
/// 选择兵种
/// </summary>
public class MouseSlePanel : PanelBase,IBeginDragHandler,IEndDragHandler,IDragHandler,IPointerClickHandler
{
    //public RectTransform point1;
    //public RectTransform point2;
    //public RectTransform point3;
    //public RectTransform point4;

    //public Material material;

    //选择框
    public RectTransform sleBox;
    public float drawBox_centerOffset = 10;
    public float raycheckRange = 1000;

    public LayerMask checkLayerMask;
    //开始拖拽的鼠标位置
    private Vector2 pressPos;
    //当前鼠标的位置
    private Vector2 curPos;

    //临时存储
    private List<ArmBase> armList;

    protected override void Awake()
    {
        base.Awake();
        sleBox.gameObject.SetActive(false);
        armList = new List<ArmBase>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        pressPos = eventData.pressPosition;
        sleBox.gameObject.SetActive(true);

        for (int i = 0; i < armList.Count; i++)
        {
            armList[i].IsSelected = false;
            armList[i].SelectHighLight(Color.white);
        }
        armList.Clear();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //更新框选框
        UpdateSleBox(eventData);
        //更新框选对象的存储
        UpdateSelObjs();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        sleBox.gameObject.SetActive(false);
    }

    //更新框选框
    private void UpdateSleBox(PointerEventData eventData)
    {
        curPos = eventData.position;

        float diagonal = Vector2.Distance(curPos, pressPos);
        float angle = Vector2.Angle(curPos - pressPos, Vector2.right);
        if (angle > 90) angle = 180 - angle;
        float xLen = diagonal * Mathf.Cos(angle * Mathf.Deg2Rad);
        float yLen = diagonal * Mathf.Sin(angle * Mathf.Deg2Rad);

        Vector2 center = new Vector2((curPos.x + pressPos.x) / 2, (curPos.y + pressPos.y) / 2);

        sleBox.anchoredPosition = center;
        sleBox.sizeDelta = new Vector2(xLen, yLen);
    }
    private void UpdateSelObjs()
    {
       
        RaycastHit[] hits = Physics.BoxCastAll(GetBoxRayCentr(),GetBoxRayHalfSize(), GetBoxRayDir(),GetBoxLookRotation(),raycheckRange,checkLayerMask);

        for (int i = 0; i < hits.Length;i++)
        {
            ArmBase armbase = hits[i].collider.GetComponent<ArmBase>();
            ISelectable selectable = hits[i].collider.GetComponent<ISelectable>();
            if(selectable != null && IsInScreenSelectedBox(selectable) && !selectable.IsSelected)
            {
                selectable.IsSelected = true;
                selectable.SelectHighLight(Color.red);
                armList.Add(armbase);
            }

        }
        
    }
    private Quaternion GetBoxLookRotation()
    {
        return Quaternion.LookRotation(Camera.main.transform.forward);
    }

    private Vector3 GetBoxRayDir()
    {
        return Camera.main.transform.forward;
    }

    private Vector3 GetBoxRayCentr()
    {
        return Camera.main.transform.position;
    }

    private Vector3 GetBoxRayHalfSize()
    {
        Vector3 woldCurPos = curPos;
        woldCurPos.z = Camera.main.farClipPlane;
        woldCurPos = Camera.main.ScreenToWorldPoint(woldCurPos);

        Vector3 woldPressPos = pressPos;
        woldPressPos.z = Camera.main.farClipPlane;
        woldPressPos = Camera.main.ScreenToWorldPoint(woldPressPos);

        Vector3 halfSize = new Vector3
            (
            Mathf.Abs(woldCurPos.x - woldPressPos.x)/2,
            Mathf.Abs(woldCurPos.y - woldPressPos.y)/2,
            2.5f
            );
        return halfSize;
    }

    private bool IsInScreenSelectedBox(ISelectable obj)
    {
        Rect box = Rect.MinMaxRect(Mathf.Min(curPos.x, pressPos.x), Mathf.Min(curPos.y, pressPos.y), Mathf.Max(curPos.x, pressPos.x), Mathf.Max(curPos.y, pressPos.y));

        //point1.anchoredPosition = box.min;
        //point2.anchoredPosition = box.max;

        Vector2 bp = Camera.main.WorldToScreenPoint(obj.BottomPoint);
        Vector2 lp = Camera.main.WorldToScreenPoint(obj.LeftPoint);
        Vector2 rp = Camera.main.WorldToScreenPoint (obj.RightPoint);
        Vector2 tp = Camera.main.WorldToScreenPoint(obj.TopPoint);
        
        //point1.anchoredPosition = bp;
        //point2.anchoredPosition = lp;
        //point3.anchoredPosition = rp;
        //point4.anchoredPosition = tp;

        return box.Contains(bp,true) && box.Contains(lp, true) && box.Contains(rp, true) && box.Contains(tp,true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            SelectionObjMgr.Instance.AddSelectionObjsRange(armList);
            for (int i = 0; i < armList.Count; i++)
            {
                Debug.Log(armList[i].name);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.matrix = Matrix4x4.TRS(Camera.main.transform.position, Camera.main.transform.rotation, Camera.main.transform.localScale);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Camera.main.transform.TransformPoint(GetBoxRayCentr()),GetBoxRayHalfSize()*2);
    }

   
}
