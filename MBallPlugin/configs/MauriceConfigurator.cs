using PluginConfig.API;
using PluginConfig.API.Decorators;
using PluginConfig.API.Fields;

namespace MauriceBaller;

public static class MauriceConfigurator
{
    public static PluginConfig.API.Functionals.ButtonField clean;

    //hitters
    public static PluginConfig.API.Functionals.ButtonField resetBreakers;
    public static PluginConfig.API.Functionals.ButtonField enableAllBreakers;
    public static PluginConfig.API.Functionals.ButtonField disableAllBreakers;

    public static BoolField groundslamBreaker;
    public static BoolField heavypunchBreaker;
    public static BoolField punchBreaker;
    public static BoolField explosionBreaker;
    public static BoolField zapBreaker;
    public static BoolField projectileBreaker;
    public static BoolField environmentBreaker;
    public static BoolField acidBreaker;
    public static BoolField fireBreaker;
    public static BoolField revolverBreaker;
    public static BoolField shotgunBreaker;
    public static BoolField shotgunzoneBreaker;
    public static BoolField chainsawzoneBreaker;
    public static BoolField chainsawBreaker;
    public static BoolField chainsawprojectileBreaker;
    public static BoolField hammerBreaker;
    public static BoolField nailBreaker;
    public static BoolField harpoonBreaker;
    public static BoolField zapperBreaker;
    public static BoolField aftershockBreaker;
    public static BoolField sawbladeBreaker;
    public static BoolField railcannonBreaker;
    public static BoolField drillBreaker;
    public static BoolField drillpunchBreaker;
    public static BoolField cannonballBreaker;
    public static BoolField shotgun0Breaker;
    public static BoolField rocket0Breaker;
    public static BoolField enemyBreaker;

    //ball settings
    public static BoolField gravity;
    public static FloatSliderField mass;
    public static FloatSliderField massVariance;
    public static FloatSliderField bounciness;
    public static FloatSliderField bouncinessVariance;

    //variations
    public static BoolField variantJingle;
    public static FloatSliderField variantChance;

    public static PluginConfig.API.Functionals.ButtonField resetVariants;
    public static PluginConfig.API.Functionals.ButtonField disableAllVariants;

    public static FloatSliderField plushieChance;
    public static FloatSliderField goldChance;
    public static FloatSliderField eyeChance;
    public static FloatSliderField lossChance;
    public static FloatSliderField evilMeanGreenChance;
    public static FloatSliderField bigChance;
    public static FloatSliderField virtueChance;
    public static FloatSliderField maurfireChance;
    public static FloatSliderField lookerChance;
    public static FloatSliderField falseVirtueChance;
    public static FloatSliderField ballriceChance;
    public static FloatSliderField moaiChance;
    public static FloatSliderField ballerBlockManChance;


    public static PluginConfigurator CreateConfigurator()
    {
        PluginConfigurator config = PluginConfigurator.Create("Maurice Baller", MyPluginInfo.PLUGIN_GUID);

        ConfigSpace gap1 = new(config.rootPanel,15f);
        clean = new(config.rootPanel,"Clean up","clean");
        ConfigSpace gap2 = new(config.rootPanel,15f);



        //breakers
        ConfigPanel breakers = new(config.rootPanel,"Breakers","breakers");

        ConfigSpace gapB1 = new(breakers,15f);
        resetBreakers = new(breakers,"Reset","reset_breakers");
        enableAllBreakers = new(breakers,"Enable All","enable_all_breakers");
        disableAllBreakers = new(breakers,"Disable All","disable_all_breakers");
        ConfigSpace gapB2 = new(breakers,15f);

        groundslamBreaker = new(breakers,"Ground Slam","groundslam",true);
        heavypunchBreaker = new(breakers,"Knuckleblaster","heavypunch",false);
        punchBreaker = new(breakers,"Feedbacker","punch",false);
        ConfigSpace gapB3 = new(breakers,15f);

        explosionBreaker = new(breakers,"Explosion","explosion",false);
        zapBreaker = new(breakers,"Zap by conduction spread","zap",true);
        projectileBreaker = new(breakers,"Miscellaneous projectiles","projectile",false);
        environmentBreaker = new(breakers,"Environment","environment",true);
        acidBreaker = new(breakers,"Acid","acid",true);
        fireBreaker = new(breakers,"Fire","fire",false);
        ConfigSpace gapB4 = new(breakers,15f);

        revolverBreaker = new(breakers,"Revolver beam","revolver",false);
        ConfigSpace gapB5 = new(breakers,15f);
        
        shotgunBreaker = new(breakers,"Shotgun pellet","shotgun",false);
        shotgunzoneBreaker = new(breakers,"Close proximity shotgun blast","shotgunzone",false);
        chainsawzoneBreaker = new(breakers,"Melee chainsaw tick","chainsawzone",false);
        chainsawBreaker = new(breakers,"Detached chainsaw","chainsaw",false);
        chainsawprojectileBreaker = new(breakers,"Flying chainsaw","chainsawprojectile",false);
        hammerBreaker = new(breakers,"Impact hammer hit","hammer",false);
        ConfigSpace gapB6 = new(breakers,15f);

        nailBreaker = new(breakers,"Nail","nail",false);
        harpoonBreaker = new(breakers,"Magnet","harpoon",false);
        zapperBreaker = new(breakers,"Conduction cable finished","zapper",false);
        aftershockBreaker = new(breakers,"Zapped by self conduction","aftershock",false);
        sawbladeBreaker = new(breakers,"Sawblade","sawblade",true);
        ConfigSpace gapB7 = new(breakers,15f);

        railcannonBreaker = new(breakers,"Railcannon Beam","railcannon",false);
        drillBreaker = new(breakers,"Screwdriver tick","drill",false);
        drillpunchBreaker = new(breakers,"Screwdriver punch ( Corkscrew Blow )","drillpunch",true);
        ConfigSpace gapB8 = new(breakers,15f);

        cannonballBreaker = new(breakers,"Cannonball","cannonball",false);
        ConfigSpace gapB9 = new(breakers,15f);

        shotgun0Breaker = new(breakers,"Shotgun core hitscan","shotgun0",false);
        rocket0Breaker = new(breakers,"Rocket hitscan","rocket0",false);
        ConfigSpace gapB10 = new(breakers,15f);



        ConfigHeader enemyBreakerNotice = new(breakers,"Notice : Initial shockwave counts as enemy . . . It will instantly break .",13,TMPro.TextAlignmentOptions.Left);
        enemyBreaker = new(breakers,"Enemy","enemy",false);



        ConfigSpace gap3 = new(config.rootPanel,15f);

        ConfigHeader ballHeader = new(config.rootPanel,"Ball",24,TMPro.TextAlignmentOptions.Left);

        gravity = new(config.rootPanel,"Gravity","gravity",true);
        ConfigSpace gap4 = new(config.rootPanel,7f);
        
        mass = new(config.rootPanel,"Mass","mass",new(0,100),5);
        massVariance = new(config.rootPanel,"Variance","mass_variance",new(0,100),3);
        ConfigSpace gap5 = new(config.rootPanel,7f);
        
        bounciness = new(config.rootPanel,"Bounciness","bounciness",new(0,1),0.5f);
        bouncinessVariance = new(config.rootPanel,"Variance","bounciness_variance",new(0,1),0);
        ConfigSpace gap6 = new(config.rootPanel,15f);

        ConfigHeader variantHeader = new(config.rootPanel,"Secret Variations",24,TMPro.TextAlignmentOptions.Left);
        ConfigHeader variantCount = new(config.rootPanel,"! There are 14 variations .",14,TMPro.TextAlignmentOptions.Left);

        variantJingle = new(config.rootPanel,"Jingle","variant_jingle",true);
        variantChance = new(config.rootPanel,"Chance ( % )","variant_chance",new(0,100),1);
        
        ConfigPanel variants = new(config.rootPanel,"Individual Likelihood","variant_likelihood");

        ConfigSpace gapC1 = new(variants,15f);
        disableAllVariants = new(variants,"Disable All","disable_all_variant");
        resetVariants = new(variants,"Reset","reset_variants");
        ConfigSpace gapC2 = new(variants,15f);

        plushieChance = new(variants,"Plushie","plushie",new(0,5),1);
        ConfigHeader variantCredit1 = new(variants,"Credit to Bitmotte ( mod developer ) for the idea",14,TMPro.TextAlignmentOptions.Left);
        goldChance = new(variants,"Gold","gold",new(0,5),1);
        ConfigHeader variantCredit2 = new(variants,"Credit to @TProfilePicture on YouTube for the idea",14,TMPro.TextAlignmentOptions.Left);
        eyeChance = new(variants,"Eye","eye",new(0,5),1);
        ConfigHeader variantCredit3 = new(variants,"Credit to u/iamayoutuberiswear on Reddit for the idea",14,TMPro.TextAlignmentOptions.Left);
        lossChance = new(variants,"Loss","loss",new(0,5),1);
        ConfigHeader variantCredit4 = new(variants,"Credit to u/Fit-Recognition-7016 on Reddit for the idea",14,TMPro.TextAlignmentOptions.Left);
        evilMeanGreenChance = new(variants,"Evil Mean Green","evil_mean_green",new(0,5),1);
        ConfigHeader variantCredit5 = new(variants,"Credit to u/finding_my_father on Reddit for the idea",14,TMPro.TextAlignmentOptions.Left);
        bigChance = new(variants,"Massive Sky Faller","big",new(0,5),1);
        ConfigHeader variantCredit6 = new(variants,"Credit to u/Longjumping_Age8031 on Reddit for the idea",14,TMPro.TextAlignmentOptions.Left);
        virtueChance = new(variants,"Virtue Orb","virtue",new(0,5),1);
        ConfigHeader variantCredit7 = new(variants,"Credit to u/Malicious_Maurice on Reddit for the idea",14,TMPro.TextAlignmentOptions.Left);
        maurfireChance = new(variants,"Maurfire","maurfire",new(0,5),1);
        ConfigHeader variantCredit8 = new(variants,"Credit to u/SingerNo5708 on Reddit for the idea",14,TMPro.TextAlignmentOptions.Left);
        lookerChance = new(variants,"Looker","looker",new(0,5),1);
        ConfigHeader variantCredit9 = new(variants,"Credit to u/C_Franssens on Reddit for the idea",14,TMPro.TextAlignmentOptions.Left);
        falseVirtueChance = new(variants,"False Virtue","false_virtue",new(0,5),1);
        ConfigHeader variantCredit10 = new(variants,"Credit to u/NoProgress7287 on Reddit for the idea",14,TMPro.TextAlignmentOptions.Left);
        ballriceChance = new(variants,"Ballrice","ballrice",new(0,5),1);
        ConfigHeader variantCredit11 = new(variants,"Credit to u/FUR_Varsik14_52 on Reddit for the idea",14,TMPro.TextAlignmentOptions.Left);
        moaiChance = new(variants,"Moai","moai",new(0,5),1);
        ConfigHeader variantCredit12 = new(variants,"Credit to u/DontKnowLunar on Reddit for the idea",14,TMPro.TextAlignmentOptions.Left);
        ballerBlockManChance = new(variants,"Baller","baller_block_man",new(0,5),1);
        ConfigHeader variantCredit13 = new(variants,"Credit to u/Traditional_Boot9840 on Reddit for the idea",14,TMPro.TextAlignmentOptions.Left);

        ConfigSpace gap7 = new(config.rootPanel,15f);

        ConfigHeader cheatsNotice = new(config.rootPanel,"Notice : Cheats can be found in the cheats menu .",20,TMPro.TextAlignmentOptions.Left);
        ConfigSpace gap8 = new(config.rootPanel,15f);

        return config;
    }
}