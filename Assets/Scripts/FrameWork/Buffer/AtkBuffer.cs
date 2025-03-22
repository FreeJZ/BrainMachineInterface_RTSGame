/// <summary>
/// 攻击指令的Buffer
/// </summary>
public class AtkBuffer : BufferBase
{
    protected override void InitData()
    {
        atkValGain = 1.2f;
        moveSpeedGain = 1.2f;
        atkDisGain = 0.5f;
    }
}