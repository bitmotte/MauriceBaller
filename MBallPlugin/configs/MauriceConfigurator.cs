using PluginConfig.API;
using PluginConfig.API.Decorators;
using PluginConfig.API.Fields;

namespace MauriceBaller;

public static class MauriceConfigurator
{
    public static PluginConfigurator CreateConfigurator()
    {
        PluginConfigurator config = PluginConfigurator.Create("Maurice Baller", MyPluginInfo.PLUGIN_GUID);

        ConfigSpace space1 = new(config.rootPanel, 15f);
        PluginConfig.API.Functionals.ButtonField cleanMauricesButton = new(config.rootPanel, "Clean up Maurice corpses", "clean_maurice");
        ConfigSpace space2 = new(config.rootPanel, 15f);
        BoolField breakField = new(config.rootPanel, "Maurices can be broken", "can_break_dead_maurice", true);
        FloatField massField = new(config.rootPanel, "Maurice Mass", "maurice_mass", 5f);
        FloatField bounceField = new(config.rootPanel, "Maurice Bounciness", "maurice_bounciness", 0f);

        ConfigHeader cheatsPanel = new(config.rootPanel, "Cheats (Disable when playing campaign)");
        BoolField mauriceRollKill = new(config.rootPanel, "Enemies can be MAURICED by rolling", "can_roll_kill", false);
        
        return config;
    }
}