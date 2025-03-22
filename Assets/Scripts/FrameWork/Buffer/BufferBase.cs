public abstract class BufferBase
{
    /// <summary>
    /// 血量增益
    /// </summary>
    public float hpGian = 1;
    /// <summary>
    /// 攻击力增益
    /// </summary>
    public float atkValGain = 1;
    /// <summary>
    /// 攻击速度增益
    /// </summary>
    public float atkSpeedGain = 1;
    /// <summary>
    /// 攻击距离增益
    /// </summary>
    public float atkDisGain = 1;
    /// <summary>
    /// 移动速度增益
    /// </summary>
    public float moveSpeedGain = 1;

    protected BufferBase()
    {
        InitData();
    }

    /// <summary>
    /// 初始化增益数据
    /// </summary>
    protected abstract void InitData();
}