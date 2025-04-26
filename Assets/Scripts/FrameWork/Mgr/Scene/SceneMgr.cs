using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneMgr : Singleton<SceneMgr>
{
    private SceneMgr() { }

    public void ChangeSceneSync(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeSceneAsync(string sceneName,UnityAction action)
    {
        MonoMgr.Instance.StartCoroutine(AsyncLoad(sceneName,action));
    }

    private IEnumerator AsyncLoad(string sceneName,UnityAction action)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
        action();
    }
}
