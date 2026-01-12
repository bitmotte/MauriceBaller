using System;
using System.IO;
using System.Reflection;
using PluginConfig.API;
using PluginConfig.API.Decorators;
using PluginConfig.API.Fields;
using UnityEngine;

namespace MauriceBaller;

public static class MauriceConfigurator
{
    public static PluginConfigurator CreateConfigurator()
    {
        PluginConfigurator config = PluginConfigurator.Create("Maurice Baller", MyPluginInfo.PLUGIN_GUID);
        Texture2D tex = LoadPNG($"{GetPluginPath()}/icon.png");
        Sprite icon = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        config.image = icon;

        ConfigSpace space1 = new(config.rootPanel, 15f);
        PluginConfig.API.Functionals.ButtonField cleanMauricesButton = new(config.rootPanel, "Clean up Maurice corpses", "clean_maurice");
        ConfigSpace space2 = new(config.rootPanel, 15f);
        BoolField breakField = new(config.rootPanel, "Maurices can be broken", "can_break_dead_maurice", true);
        FloatField massField = new(config.rootPanel, "Maurice Mass", "maurice_mass", 5f);
        FloatField bounceField = new(config.rootPanel, "Maurice Bounciness", "maurice_bounciness", 0f);

        ConfigHeader cheatsPanel = new(config.rootPanel, "Cheats (Disable when playing campaign)");
        BoolField mauriceRollKill = new(config.rootPanel, "Enemies can be MAURICED by rolling", "can_roll_kill", false);

        cleanMauricesButton.onClick += CleanDeadMaurices;
        breakField.postValueChangeEvent += ChangeAccessibleConfigBreakable;
        massField.postValueChangeEvent += ChangeAccessibleConfigMass;
        bounceField.postValueChangeEvent += ChangeAccessibleConfigBounciness;
        mauriceRollKill.postValueChangeEvent += ChangeAccessibleConfigRollKill;

        breakField.TriggerPostValueChangeEvent();
        massField.TriggerPostValueChangeEvent();
        mauriceRollKill.TriggerPostValueChangeEvent();
        
        return config;
    }

    private static void ChangeAccessibleConfigBreakable(bool value)
    {
        AccessibleConfigs.CanBreakDeadMaurice = value;
    }

    private static void ChangeAccessibleConfigMass(float value)
    {
        AccessibleConfigs.MauriceMass = value;
        for (int i = 0; i < SceneUtility.mauricePool.childCount; i++)
        {
            Rigidbody rb = SceneUtility.mauricePool.GetChild(i).GetChild(0).gameObject.GetComponent<Rigidbody>();
            rb.mass = AccessibleConfigs.MauriceMass;
        }
    }

    private static void ChangeAccessibleConfigBounciness(float value)
    {
        AccessibleConfigs.MauriceBounciness = value;
        for (int i = 0; i < SceneUtility.mauricePool.childCount; i++)
        {
            PhysicMaterial mat = SceneUtility.mauricePool.GetChild(i).GetChild(0).gameObject.GetComponent<SphereCollider>().material;
            mat.bounciness = AccessibleConfigs.MauriceBounciness;
        }
    }

    private static void ChangeAccessibleConfigRollKill(bool value)
    {
        AccessibleConfigs.CanRollKill = value;
    }

    private static void CleanDeadMaurices()
    {
        for (int i = 0; i < SceneUtility.mauricePool.childCount; i++)
        {
            GameObject.Destroy(SceneUtility.mauricePool.GetChild(i).gameObject);
        }
    }

    public static Texture2D LoadPNG(string filePath) {
	    Texture2D tex = null;
	    byte[] fileData;

	    if (File.Exists(filePath)) 	{
	    	fileData = File.ReadAllBytes(filePath);
	    	tex = new Texture2D(2, 2);
	    	tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
	    }
	    return tex;
    }

    public static string GetPluginPath()
    {
        string codeBase = Assembly.GetExecutingAssembly().CodeBase;
        UriBuilder uri = new UriBuilder(codeBase);
        string path = Uri.UnescapeDataString(uri.Path);
        return Path.GetDirectoryName(path);
    }
}