using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEditor;
using UnityEditor.Compilation;

public class ExcelToDataClassReader : ExcelFormatReaderBase
{
    public override void Read(DataTable table,string storePath)
    {
        if(!Directory.Exists(storePath))
        {
            Directory.CreateDirectory(storePath);
        }
        
        string className = table.TableName + "Data";
        
        DataRowCollection rows = table.Rows;
        object[] varName = rows[0].ItemArray;
        object[] varType = rows[1].ItemArray;
        using(StreamWriter sw = File.CreateText(storePath + "/" + className + ".cs"))
        {
            sw.WriteLine("public class " + className);
            sw.WriteLine("{");
            for(int i = 0;i<varName.Length;i++)
            {
                sw.WriteLine("\tpublic " + varType[i] + " " + varName[i] + ";");
            }
            sw.WriteLine("}");
        }

        AssetDatabase.Refresh();
    }
}
