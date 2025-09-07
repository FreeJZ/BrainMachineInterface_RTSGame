using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using ExcelDataReader;
using System.Data;

public class ExcelToolEditorWindow : EditorWindow
{
    private enum E_HanldeType
    {
        ToJson,
        ToDataClass
    }



    private ExcelToolData data;
    private bool isCustom;
    private void OnEnable()
    {
        data = EditorGUIUtility.Load("ExcelToolData.asset") as ExcelToolData;
        isCustom = data.isCustom;
    }

    private void OnGUI()
    {
        if (data == null) return;

        EditorGUILayout.HelpBox("Excel后缀：xlsx\nExcel配置规则：\n第一行：变量名\n第二行：变量类型\n第三行及以后：具体数据", MessageType.Info);
        //默认路劲
        EditorGUILayout.LabelField("默认Excel存放路径：", data.defaultExcelStorePath);
        EditorGUILayout.LabelField("默认DataClass存放路径：", data.defaultdataClassStorePath);
        EditorGUILayout.LabelField("默认JsonFile存放路径：", data.defaultjsonFileStorePath);
        
        //自定义路径
        isCustom = EditorGUILayout.Toggle("自定义存放路径", isCustom);
        data.isCustom = isCustom;
        if(isCustom)
        {
            data.customExcelStorePath = EditorGUILayout.TextField("Excel存放路径：", data.customExcelStorePath);
            data.customdataClassStorePath = EditorGUILayout.TextField("DataClass存放路径：", data.customdataClassStorePath);
            data.customjsonFileStorePath = EditorGUILayout.TextField("JsonFile存放路径：", data.customjsonFileStorePath);
        }

        if (GUILayout.Button("保存自定义修改"))
        {
            EditorUtility.SetDirty(data);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        if (GUILayout.Button("生成所选DataClass"))
        {
            Handle(E_HanldeType.ToDataClass);
        }
        if (GUILayout.Button("生成所选JsonFile"))
        {
            Handle(E_HanldeType.ToJson);
        }

        if (GUILayout.Button("生成所有DataClass"))
        {
            HandleAll(E_HanldeType.ToDataClass);
        }
        if(GUILayout.Button("生成所有JsonFile"))
        {
            HandleAll(E_HanldeType.ToJson);
        }
    }
    private void Handle(E_HanldeType type)
    {
        Object[] objs = Selection.objects;

        if (objs.Length == 0)
        {
            Debug.Log("未选择Excel文件");
            return;
        }

        string[] filePaths = new string[objs.Length];
        for(int i = 0;i<objs.Length;i++)
        {
            filePaths[i] = AssetDatabase.GetAssetPath(objs[i]);
        }

        for(int i = 0;i< filePaths.Length;i++)
        {
            FileInfo fileInfo = new FileInfo(filePaths[i]);
            if(fileInfo.Extension == ".xlsx")
            {
                using(FileStream fs = File.Open(fileInfo.FullName,FileMode.Open,FileAccess.Read))
                {
                    using(IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                    {
                        DataSet dataSet = reader.AsDataSet();
                        DataTableCollection tables = dataSet.Tables;

                        for (int j = 0; j < tables.Count; j++)
                        {
                            DataTable t = tables[j];
                            ExcelFormatReaderBase formatRead = null;
                            string storePath = Application.dataPath + "/";
                            if (type == E_HanldeType.ToDataClass)
                            {
                                storePath += isCustom == true ? data.customdataClassStorePath : data.defaultdataClassStorePath;
                                formatRead = new ExcelToDataClassReader();
                            }
                            else
                            {
                                storePath += isCustom == true ? data.customjsonFileStorePath : data.defaultjsonFileStorePath;
                                formatRead = new ExcelToJsonReader();
                            }
                            formatRead.Read(t, storePath);
                        }
                    }
                }
            }
        }
    }
    private void HandleAll(E_HanldeType type)
    {
        string path;
        path = Application.dataPath + "/" + (isCustom == true ? data.customExcelStorePath : data.defaultExcelStorePath);

        //获取文件的目录信息
        DirectoryInfo dInfo = null;
        if (!Directory.Exists(path))
        {
            dInfo = Directory.CreateDirectory(path);
        }
        else
        {
            dInfo = new DirectoryInfo(path);
        }
        //获取文件的信息
        FileInfo[] fInfos = dInfo.GetFiles();

        for (int i = 0; i < fInfos.Length; i++)
        {
            //处理Excel文件
            if (fInfos[i].Extension == ".xlsx")
            {
                using (FileStream fs = File.Open(fInfos[i].FullName, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                    {
                        DataSet dataSet = reader.AsDataSet();
                        DataTableCollection tables = dataSet.Tables;

                        for (int j = 0; j < tables.Count; j++)
                        {
                            DataTable t = tables[j];
                            ExcelFormatReaderBase formatRead = null;
                            string storePath = Application.dataPath + "/";
                            if (type == E_HanldeType.ToDataClass)
                            {
                                storePath += isCustom == true ? data.customdataClassStorePath : data.defaultdataClassStorePath;
                                formatRead = new ExcelToDataClassReader();
                            }
                            else
                            {
                                storePath += isCustom == true ? data.customjsonFileStorePath : data.defaultjsonFileStorePath;
                                formatRead = new ExcelToJsonReader();
                            }
                            formatRead.Read(t, storePath);
                        }
                    }
                }

            }
        }
    }

    private void OnDestroy()
    {
        if(data != null)
        {
            EditorUtility.SetDirty(data);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
