/// <summary>
/// buffer工厂
/// </summary>
public class BufferFactory : Singleton<BufferFactory>, IFactory<BufferBase,E_Command>
{
    public BufferBase GetItem(E_Command command)
    {
        BufferBase buffer = null;
        switch (command)
        {
            case E_Command.rush:
                buffer = new AtkBuffer();
                break;
            case E_Command.back:
                buffer = new BackBuffer();
                break;
            case E_Command.check:
                buffer = new CheckBuffer();
                break;
            case E_Command.yuhui:
                buffer = new YuHuiBuffer();
                break;
            case E_Command.defence:
                buffer = new DefenceBuffer();
                break;
        }
        return buffer;
    }

    public K GetItem<K>(E_Command command) where K : BufferBase
    {
        return GetItem(command) as K;
    }
}