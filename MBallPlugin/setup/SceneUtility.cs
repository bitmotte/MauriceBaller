using UnityEngine.SceneManagement;
using UnityEngine;

namespace MauriceBaller;

public static class SceneUtility
{
    public static string sceneName;
    
    public static Transform mauricePool = new GameObject("tmp").transform;
    //public static Transform cgArena;

    public static void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        sceneName = scene.name;

        mauricePool = new GameObject("MauricePool").transform;
        mauricePool.parent = null;

        //if(sceneName != "9240e656c89994d44b21940f65ab57da") {return;}
        //cgArena = GameObject.Find("Everything").transform.GetChild(2);
    }
}