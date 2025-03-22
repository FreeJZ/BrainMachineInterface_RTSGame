/// <summary>
/// Buffer处理类
/// </summary>
public static class BufferHandle
{
    public static void Handle(E_Command fristCmd,E_Command secondCmd, ArmBase arm)
    {
        IStrategy<BufferBase, BufferBase, ArmBase> strategy = new CalcBufferMethod();
        if(fristCmd == secondCmd)
        {
            BufferBase buffer1 = BufferFactory.Instance.GetItem(fristCmd);
            strategy.Handle(buffer1, buffer1, arm);
        }
        else
        {
            BufferBase buffer1 = BufferFactory.Instance.GetItem(fristCmd);
            BufferBase buffer2 = BufferFactory.Instance.GetItem(secondCmd);
            strategy.Handle(buffer1, buffer2, arm);
        }
       
    }
}