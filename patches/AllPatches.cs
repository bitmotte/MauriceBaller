using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace MauriceBaller;

[HarmonyPatch(typeof(SpiderBody), "Die")]
public class MauriceDeathPatch : MonoBehaviour
{
    static void Postfix(SpiderBody __instance)
    {
        if(__instance.transform.parent.parent.name.Contains("Disgrace")) {return;}
        
        Rigidbody rb = __instance.GetComponentInChildren<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        rb.isKinematic = false;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.mass = AccessibleConfigs.MauriceMass;

        PhysicMaterial mat = __instance.GetComponentInChildren<SphereCollider>().material;
        mat.dynamicFriction = AccessibleConfigs.MauriceFriction;
        mat.staticFriction = AccessibleConfigs.MauriceFriction;
        mat.bounciness = AccessibleConfigs.MauriceBounciness;

        __instance.gameObject.AddComponent<BallerInfo>();
        __instance.transform.localRotation = Quaternion.Euler(15,0,0);

        __instance.transform.parent.parent = SceneUtility.mauricePool;
    }
}

[HarmonyPatch(typeof(SpiderBody), "OnCollisionEnter")]
public class MauriceRubblePatch : MonoBehaviour
{
    static bool Prefix(SpiderBody __instance, Collision other)
    {
        Traverse instanceFields = Traverse.Create(__instance);
        bool falling = (bool)instanceFields.Field("falling").GetValue();
        
        if(!falling)
        {
            return false;
        }
        if (other.gameObject.CompareTag("Floor")) {return false;}
        if (other.gameObject.CompareTag("Untagged")) {return false;}
        __instance.gameObject.GetComponent<BallerInfo>().hitGround = true;
        return false;
    }
}

[HarmonyPatch(typeof(SpiderBody), "FallKillEnemy")]
public class MauriceFriendlyFirePatch : MonoBehaviour
{
    static bool Prefix(SpiderBody __instance)
    {
        BallerInfo hit = __instance.gameObject.GetComponent<BallerInfo>();
        
        if(AccessibleConfigs.CanRollKill == true) {return true;}
        if(hit.hitGround == true) {return false;}
        return true;
    }
}

[HarmonyPatch(typeof(SpiderBody), "BreakCorpse")]
public class MauriceRubbleBreakPatch : MonoBehaviour
{
    static bool Prefix()
    {
        if(AccessibleConfigs.CanBreakDeadMaurice == true)
        {
            return true;
        } 
        return false;
    }
}

[HarmonyPatch(typeof(Bloodsplatter), "Awake")]
public class BloodsplatterNoDeadMauricePatch : MonoBehaviour
{
    static void Postfix(Bloodsplatter __instance)
    {
        __instance.gameObject.AddComponent<DontSplattermaurice>();
    }
}