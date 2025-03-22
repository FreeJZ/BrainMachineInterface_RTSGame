/// <summary>
/// 策略接口
/// </summary>
/// <typeparam name="T">处理对象的类型</typeparam>
public interface IStrategy<Tbuffer1,Tbuffer2, TObj> where Tbuffer1:BufferBase where Tbuffer2:BufferBase where TObj : ArmBase
{
    void Handle(Tbuffer1 buffer1,Tbuffer2 buffer2, TObj obj);
}