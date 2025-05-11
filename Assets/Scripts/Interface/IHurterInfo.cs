public interface IHurterInfo
{
    /// <summary>
    /// 最大攻击数量
    /// </summary>
    int MaxAtkCnt { get; }
    /// <summary>
    /// 当前攻击数量
    /// </summary>
    int CurAtkCnt { get; set; }
}