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
    //选择框
    public RectTransform sleBox;
    public float drawBox_centerOffset = 10;
    public float raycheckRange = 1000;

    public LayerMask checkLayerMask;
    //开始拖拽的鼠标位置
    private Vector2 pressPos;
    //当前鼠标的位置
    private Vector2 curPos;

    private bool IsDrag;

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
        IsDrag = true;
        pressPos = eventData.pressPosition;
        sleBox.gameObject.SetActive(true);

        for (int i = 0; i < armList.Count; i++)
        {
            armList[i].IsSelected = false;
            armList[i].SelectHighLight(false);
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
        IsDrag = false;
        sleBox.gameObject.SetActive(false);
    }

    //更新框选框
    private void UpdateSleBox(PointerEventData eventData)
    {
        curPos = eventData.position;

        Vector2 localCurPos,localPressPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, curPos, eventData.pressEventCamera, out localCurPos);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, pressPos,eventData.pressEventCamera, out localPressPos);
        
        float diagonal = Vector2.Distance(localCurPos, localPressPos);
        float angle = Vector2.Angle(localCurPos - localPressPos, Vector2.right);
        if (angle > 90) angle = 180 - angle;
        float xLen = diagonal * Mathf.Cos(angle * Mathf.Deg2Rad);
        float yLen = diagonal * Mathf.Sin(angle * Mathf.Deg2Rad);

        Vector2 center = new Vector2((localCurPos.x + localPressPos.x) / 2, (localCurPos.y + localPressPos.y) / 2);
        Vector2 size = new Vector2(xLen, yLen);

        sleBox.anchoredPosition = center;
        sleBox.sizeDelta = size;
    }
    //更新框选的对象
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
                selectable.SelectHighLight(true);
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

        Vector2 bp = Camera.main.WorldToScreenPoint(obj.BottomPoint);
        Vector2 lp = Camera.main.WorldToScreenPoint(obj.LeftPoint);
        Vector2 rp = Camera.main.WorldToScreenPoint (obj.RightPoint);
        Vector2 tp = Camera.main.WorldToScreenPoint(obj.TopPoint);
        
        return box.Contains(bp,true) && box.Contains(lp, true) && box.Contains(rp, true) && box.Contains(tp,true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //右键点击确定选择的内容
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            SelectionObjMgr.Instance.AddSelectionObjsRange(armList);
            for(int i = 0;i<armList.Count;i++)
            {
                armList[i].SelectHighLight(false);
            }
            //切换到选择命令面板
            UIMgr.Instance.ShowPanel<SetCommandPanel>();
        }
        //左键点击单选一个对象
        else if (!IsDrag && eventData.button == PointerEventData.InputButton.Left)
        {
            Ray ray = Camera.main.ScreenPointToRay(eventData.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, raycheckRange, checkLayerMask, QueryTriggerInteraction.Ignore))
            {
                ArmBase armBase = hit.collider.GetComponent<ArmBase>();
                if (armBase != null && !armBase.IsSelected)
                {
                    armBase.IsSelected = true;
                    armList.Add(armBase);
                    armBase.SelectHighLight(true);
                }
            }
            else//左键点击空白处
            {
                for (int i = 0; i < armList.Count; i++)
                {
                    armList[i].IsSelected = false;
                    armList[i].SelectHighLight(false);
                }
                armList.Clear();
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
