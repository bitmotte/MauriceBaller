using UnityEngine;

namespace MauriceBaller;
public static class SecretVariations
{
    public static void MakeBallWithSecretPossibility(GameObject gameObject)
    {
        int luck = Random.RandomRangeInt(1,101);
        if(luck == 1)
        {
            Simple("Assets/Baller/Variatioins/Plush/DevPlushie (bitmotte).prefab",gameObject);
            return;
        }
        GenericCorpse("Assets/Baller/Corpse/MaliciousCorpse.prefab",gameObject);
    }

    public static void GenericCorpse(string key, GameObject dead)
    {
        AssetBundle bundle = BundleTool.Load("balls.bundle");
        GameObject ball = (GameObject)bundle.LoadAsset(key);
        SetupResource.FixShader(ball);
        
        ball.AddComponent<MaliciousCorpse>();
        //MalCorpse > RotTransPortal > BodCenterRotPortal > Visual > Legs
        ball.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(9).gameObject.AddComponent<CorpseLegController>();

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
}
