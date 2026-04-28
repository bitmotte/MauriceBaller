using PluginConfig.API;
using PluginConfig.API.Decorators;
using PluginConfig.API.Fields;

namespace MauriceBaller;

public static class MauriceConfigurator
{
    public static PluginConfigurator CreateConfigurator()
    {
        PluginConfigurator config = PluginConfigurator.Create("Maurice Baller", MyPluginInfo.PLUGIN_GUID);

        PluginConfig.API.Functionals.ButtonField cleanMaurices = new(config.rootPanel, "Clean up", "clean_maurice");
        ConfigSpace space1 = new(config.rootPanel, 15f);

        ConfigPanel breakers = new(config.rootPanel,"Breakers","breakers_panel");
        PluginConfig.API.Functionals.ButtonField enableAllBreakers = new(config.rootPanel, "Enable All", "breakers_all");
        PluginConfig.API.Functionals.ButtonField disableAllBreakers = new(config.rootPanel, "Disable All", "breakers_none");
        ConfigSpace space2 = new(config.rootPanel, 15f);

        BoolField gravity = new(config.rootPanel, "Gravity", "gravity", true);
        FloatSliderField mass = new(config.rootPanel, "Mass", "maurice_mass", new(0f,100f),5f);
        FloatSliderField bounciness = new(config.rootPanel, "Bounciness", "maurice_bounciness", new(0f,100f),0f);

        ConfigHeader cheats = new(config.rootPanel, "Cheats (Disable when playing campaign)");
        
        return config;
    }
}