using UnityEngine;

namespace MauriceBaller;
public static class SecretVariations
{
    public static void MakeBallWithSecretPossibility(GameObject gameObject)
    {
        //1,101 for 1 in 100 chance
        int luck = Random.RandomRangeInt(1,101);
        if(luck == 1)
        {
            int luckVariation = Random.RandomRangeInt(1,15);
            switch (luckVariation)
            {
                default:
                    Simple("Assets/Baller/Variations/Plush/DevPlushie (bitmotte).prefab",gameObject);
                    break;
                case 2:
                    GenericCorpse("Assets/Baller/Variations/Gold/Gold.prefab",gameObject);
                    break;
                case 3:
                    CorpseNoLegs("Assets/Baller/Variations/HellEye/HellEye.prefab",gameObject);
                    break;
                case 4:
                    GenericCorpse("Assets/Baller/Variations/Loss/Loss.prefab",gameObject);
                    break;
                case 5:
                    EvilMeanGreen("Assets/Baller/Variations/EvilMeanGreen/Green.prefab",gameObject);
                    break;
                case 6:
                    GenericCorpse("Assets/Baller/Variations/Big/Big.prefab",gameObject);
                    break;
                case 7:
                    CorpseNoLegs("Assets/Baller/Variations/Virtue/Virtue.prefab",gameObject);
                    break;
                case 8:
                    GenericCorpse("Assets/Baller/Variations/Maurfire/Maurfire.prefab",gameObject);
                    break;
                case 9:
                    GenericCorpse("Assets/Baller/Variations/Looker/Looker.prefab",gameObject);
                    break;
                case 10:
                    GenericCorpse("Assets/Baller/Variations/FalseVirtue/FalseVirtue.prefab",gameObject);
                    break;
                case 11:
                    GenericCorpse("Assets/Baller/Variations/Ballrice/Ballrice.prefab",gameObject);
                    break;
                case 12:
                    CorpseNoLegs("Assets/Baller/Variations/Moai/Moai.prefab",gameObject);
                    break;
                case 13:
                    CorpseNoLegs("Assets/Baller/Variations/BallerBlockMan/BallerBlockMan.prefab",gameObject);
                    break;
            }
            return;
        }
        GenericCorpseNoJingle("Assets/Baller/Corpse/MaliciousCorpse.prefab",gameObject);
    }

    public static void GenericCorpseNoJingle(string key, GameObject dead)
    {
        AssetBundle bundle = BundleTool.Load("balls.bundle");
        GameObject ball = (GameObject)bundle.LoadAsset(key);
        SetupResource.FixShader(ball);
        
        ball.AddComponent<MaliciousCorpse>();
        //MalCorpse > RotTransPortal > BodCenterRotPortal > Visual > Legs
        ball.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject.AddComponent<CorpseLegController>();

        ball.transform.position = dead.transform.position;
        ball.transform.rotation = dead.transform.rotation;

        Object.Instantiate(ball);

        bundle.Unload(false);
    }

    public static void GenericCorpse(string key, GameObject dead)
    {
        AssetBundle bundle = BundleTool.Load("balls.bundle");
        GameObject ball = (GameObject)bundle.LoadAsset(key);
        SetupResource.FixShader(ball);
        
        MaliciousCorpse controller = ball.AddComponent<MaliciousCorpse>();
        controller.variation = true;

        //MalCorpse > RotTransPortal > BodCenterRotPortal > Visual > Legs
        ball.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject.AddComponent<CorpseLegController>();

        ball.transform.position = dead.transform.position;
        ball.transform.rotation = dead.transform.rotation;

        Object.Instantiate(ball);

        bundle.Unload(false);
    }

    public static void CorpseNoLegs(string key, GameObject dead)
    {
        AssetBundle bundle = BundleTool.Load("balls.bundle");
        GameObject ball = (GameObject)bundle.LoadAsset(key);
        SetupResource.FixShader(ball);
        
        MaliciousCorpse controller = ball.AddComponent<MaliciousCorpse>();
        controller.variation = true;

        //MalCorpse > RotTransPortal > BodCenterRotPortal > Visual > Legs
        Object.Destroy(ball.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject);

        ball.transform.position = dead.transform.position;
        ball.transform.rotation = dead.transform.rotation;

        Object.Instantiate(ball);

        bundle.Unload(false);
    }

    public static void Simple(string key, GameObject dead)
    {
        AssetBundle bundle = BundleTool.Load("balls.bundle");
        GameObject ball = (GameObject)bundle.LoadAsset(key);
        SetupResource.FixShader(ball);

        ball.transform.position = dead.transform.position;
        ball.transform.rotation = dead.transform.rotation;

        Object.Instantiate(ball);

        bundle.Unload(false);
    }

    public static void EvilMeanGreen(string key, GameObject dead)
    {
        AssetBundle bundle = BundleTool.Load("balls.bundle");
        GameObject ball = (GameObject)bundle.LoadAsset(key);
        SetupResource.FixShader(ball);
        
        MaliciousCorpse controller = ball.AddComponent<MaliciousCorpse>();
        controller.variation = true;

        EvilMeanGreen evilMeanGreen = ball.AddComponent<EvilMeanGreen>();
        evilMeanGreen.green = (GameObject)bundle.LoadAsset("Assets/Baller/Variations/EvilMeanGreen/GreenFlash.prefab");

        //MalCorpse > RotTransPortal > BodCenterRotPortal > Visual > Legs
        ball.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject.AddComponent<CorpseLegController>();

        ball.transform.position = dead.transform.position;
        ball.transform.rotation = dead.transform.rotation;

        Object.Instantiate(ball);

        bundle.Unload(false);
    }
}
