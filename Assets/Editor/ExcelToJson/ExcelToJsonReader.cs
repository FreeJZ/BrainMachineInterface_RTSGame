using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ExcelToJsonReader : ExcelFormatReaderBase
{
    public override void Read(DataTable table, string storeaPath)
    {
        if(!Directory.Exists(storeaPath))
        {
            Directory.CreateDirectory(storeaPath);
        }    

        string fileName = table.TableName;

        DataRowCollection rows = table.Rows;
        object[] varName = rows[0].ItemArray;
        object[] varType = rows[1].ItemArray;
        
        using(StreamWriter sw = File.CreateText(storeaPath + "/" + fileName + ".json"))
        {
            sw.WriteLine("[");
            for(int i = 2;i<rows.Count;i++)
            {
                object[] data = rows[i].ItemArray;
                sw.Write("{");
                for(int j = 0;j<data.Length;j++)
                {
                    if ((string)varType[j] == "string")
                    {
                        sw.Write($"\"{varName[j]}\":\"{data[j]}\"");
                    }
                    else
                    {
                        sw.Write($"\"{varName[j]}\":{data[j]}");
                    }
                    if(j != data.Length-1)sw.Write(",");
                }
                sw.Write("}");
                if (i != rows.Count - 1) sw.WriteLine(",");
                else sw.WriteLine();
            }
            sw.WriteLine("]");
        }

        AssetDatabase.Refresh();
    }
}
