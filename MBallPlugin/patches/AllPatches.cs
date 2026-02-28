//using ;
using HarmonyLib;
using UnityEngine;

namespace MauriceBaller;

[HarmonyPatch(typeof(MaliciousFace), "HandleCollision")]
public class BallPatch : MonoBehaviour
{
    static bool Prefix(MaliciousFace __instance, Collision other)
    {
        


        return false;
    }
}