//using ;
using HarmonyLib;
using UnityEngine;

namespace MauriceBaller;

[HarmonyPatch(typeof(MaliciousFace), "HandleCollision")]
public class BallPatch : MonoBehaviour
{
    static bool Prefix(MaliciousFace __instance, Collision other)
    {
        AssetBundle bundle = BundleTool.Load("balls.bundle");
        GameObject ball = (GameObject)bundle.LoadAsset("Assets/MauriceBall.prefab");
        SetupResource.SetupGameObject(ball,true);
        
        ball.transform.position = __instance.transform.position;

        Instantiate(ball);
        bundle.Unload(false);

        __instance.BreakCorpse();

        return false;
    }
}