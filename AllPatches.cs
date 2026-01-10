using HarmonyLib;
using UnityEngine;

namespace MauriceBaller;

[HarmonyPatch(typeof(SpiderBody), "Die")]
public class MauriceDeathPatch : MonoBehaviour
{
    static void Postfix(SpiderBody __instance)
    {
        Rigidbody rb = __instance.GetComponentInChildren<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        rb.mass = AccessibleConfigs.MauriceMass;

        __instance.gameObject.AddComponent<BallerGroundHit>();

        MauriceConfigurator.allMauricePhysics.Add(rb);
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
        if (other.gameObject.CompareTag("Floor"))
        {
            __instance.gameObject.GetComponent<BallerGroundHit>().hitGround = true;
        }
        return false;
    }
}

[HarmonyPatch(typeof(SpiderBody), "FallKillEnemy")]
public class MauriceFriendlyFirePatch : MonoBehaviour
{
    static bool Prefix(SpiderBody __instance)
    {
        BallerGroundHit hit = __instance.gameObject.GetComponent<BallerGroundHit>();
        
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

[HarmonyPatch(typeof(SpiderBody), "Die")]
public class CGCleanerDisablePatch : MonoBehaviour
{
    static void Postfix(SpiderBody __instance)
    {
        if(AccessibleConfigs.CleanMauriceBodiesInCybergrind == true) {return;}
        if(Plugin.sceneName != "9240e656c89994d44b21940f65ab57da") {return;}

        __instance.transform.parent = null;
        MauriceConfigurator.cgMaurices.Add(__instance.transform);       
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