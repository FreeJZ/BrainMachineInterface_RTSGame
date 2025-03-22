/// <summary>
/// 工厂接口
/// </summary>
/// <typeparam name="T">生产产品的类型</typeparam>
/// <typeparam name="Flag">产品的标签类型</typeparam>
public interface IFactory<T, Flag> where T : class
{
    /// <summary>
    /// 获取物品
    /// </summary>
    /// <returns>返回物品</returns>
    T GetItem(Flag flag);

    K GetItem<K>(Flag flag) where K : T;
}
