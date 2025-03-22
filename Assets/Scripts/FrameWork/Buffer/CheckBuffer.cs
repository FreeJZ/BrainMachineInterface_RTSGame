/// <summary>
/// 侦查指令的Buffer
/// </summary>
public class CheckBuffer : BufferBase
{
    protected override void InitData()
    {
        atkValGain = 0.2f;
        moveSpeedGain = 2;
    }
}