using UnityEngine;

public interface ISelectable
{
    Vector3 BottomPoint { get; }
    Vector3 TopPoint { get; }
    Vector3 RightPoint { get; }
    Vector3 LeftPoint { get; }
    bool IsSelected { get; set; }

    void SelectHighLight(bool isShow);
}