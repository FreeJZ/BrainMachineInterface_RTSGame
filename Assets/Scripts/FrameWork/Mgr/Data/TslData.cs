using System.Collections.Generic;

/// <summary>
/// 转换条件数据
/// </summary>
public class TslData
{
    public List<Pair> pairsList;
}

public enum E_CmdType
{
    fristCmd = 1,
    SecondCmd
}

public class Pair
{
    public E_CmdType cmdType;
    public int flag;
    public string tip;
}