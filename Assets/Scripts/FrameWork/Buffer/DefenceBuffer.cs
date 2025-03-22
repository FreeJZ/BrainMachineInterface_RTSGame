/// <summary>
/// 防御指令的Buffer
/// </summary>
public class DefenceBuffer : BufferBase
{
    protected override void InitData()
    {
        atkDisGain = 1.5f;
        hpGian = 2.5f;
        moveSpeedGain = 0.5f;
    }
}