using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
public class JsonMgr : Singleton<JsonMgr>
{
    private JsonMgr() { }

    public void Save<T>(string fileName,T data) where T : class
    {
        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        string jsonStr = JsonMapper.ToJson(data);
        File.WriteAllText(path, jsonStr);
    }

    public T Load<T>(string fileName) where T : class
    {
        string path = Application.streamingAssetsPath + "/" + fileName + ".Json";
        
        T data = default(T);
        
        if(!File.Exists(path))
        {
            path = Application.persistentDataPath + "/" + fileName + ".Json";
        }

        if(!File.Exists(path))
        {
            Debug.Log(fileName + "文件不存在");
            return data;
        }

        string jsonStr = File.ReadAllText(path);

        data = JsonMapper.ToObject<T>(jsonStr);

        return data;
    }
}
