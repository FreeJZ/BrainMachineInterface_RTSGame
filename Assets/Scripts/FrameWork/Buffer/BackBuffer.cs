/// <summary>
/// 撤退指令的Buffer
/// </summary>
public class BackBuffer : BufferBase
{
    protected override void InitData()
    {
        atkValGain = 0.6f;
        atkSpeedGain = 0.6f;
        moveSpeedGain = 1.5f;
    }
}