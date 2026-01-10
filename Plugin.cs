using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using PluginConfig.API;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MauriceBaller;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency("com.eternalUnion.pluginConfigurator")]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
    public static PluginConfigurator config;
    public static string sceneName;
        
    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        harmony.PatchAll();

        //configurator
        config = MauriceConfigurator.CreateConfigurator();

        //stop cg cleaner
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        sceneName = scene.name;
        MauriceConfigurator.cgMaurices = [];
        MauriceConfigurator.allMauricePhysics = [];
    }
}
