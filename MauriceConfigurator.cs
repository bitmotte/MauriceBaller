using System.Collections.Generic;
using System.IO;
using PluginConfig.API;
using PluginConfig.API.Decorators;
using PluginConfig.API.Fields;
using UnityEngine;

namespace MauriceBaller;

public static class MauriceConfigurator
{
    public static List<Transform> cgMaurices = [];
    public static List<Rigidbody> allMauricePhysics = [];

    public static TextAsset imageAsset;

    public static PluginConfigurator CreateConfigurator()
    {
        PluginConfigurator config = PluginConfigurator.Create("Maurice Baller", MyPluginInfo.PLUGIN_GUID);
        Texture2D tex = LoadPNG(Path.Combine(BepInEx.Paths.PluginPath, "MauriceBaller/icon.png"));
        Sprite icon = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        config.image = icon;

        BoolField BreakMauriceField = new(config.rootPanel, "Dead Maurices can be broken", "can_break_dead_maurice", false);
        BoolField CleanMauriceField = new(config.rootPanel, "Clean dead Maurices per new CG wave", "clean_dead_maurice_cg", false);
        FloatField MassField = new(config.rootPanel, "Dead Maurice Mass", "maurice_mass", 5f);

        ConfigHeader cheatsPanel = new(config.rootPanel, "Cheats (Disable when playing campaign)");
        BoolField MauriceRollKill = new(config.rootPanel, "Enemies can be MAURICED by rolling", "can_roll_kill", false);

        BreakMauriceField.postValueChangeEvent += ChangeAccessibleConfigBreakable;
        CleanMauriceField.postValueChangeEvent += ChangeAccessibleConfigCleanable;
        MassField.postValueChangeEvent += ChangeAccessibleConfigMass;
        MauriceRollKill.postValueChangeEvent += ChangeAccessibleConfigRollKill;

        BreakMauriceField.TriggerPostValueChangeEvent();
        CleanMauriceField.TriggerPostValueChangeEvent();
        MassField.TriggerPostValueChangeEvent();
        MauriceRollKill.TriggerPostValueChangeEvent();
        
        return config;
    }

    private static void ChangeAccessibleConfigBreakable(bool value)
    {
        AccessibleConfigs.CanBreakDeadMaurice = value;
    }
    private static void ChangeAccessibleConfigCleanable(bool value)
    {
        AccessibleConfigs.CleanMauriceBodiesInCybergrind = value;
        if(value == false)
        {
            Plugin.Logger.LogInfo("clean up " + cgMaurices.Count + " maurices");
            foreach (Transform cgMaurice in cgMaurices)
            {
                GameObject.Destroy(cgMaurice.gameObject);
            }
            cgMaurices = [];
        }
    }
    private static void ChangeAccessibleConfigMass(float value)
    {
        AccessibleConfigs.MauriceMass = value;
        foreach (Rigidbody rb in allMauricePhysics)
        {
            rb.mass = value;
        }
    }

    private static void ChangeAccessibleConfigRollKill(bool value)
    {
        AccessibleConfigs.CanRollKill = value;
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

}