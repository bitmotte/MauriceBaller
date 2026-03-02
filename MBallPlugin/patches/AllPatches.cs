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

        ball.transform.position = __instance.transform.position;
        ball.transform.rotation = __instance.transform.rotation;

        //SetupResource.SetupGameObject(ball,true,true);

        Instantiate(ball);
        bundle.Unload(false);

        __instance.BreakCorpse();

        return false;
    }
}