using HarmonyLib;
using UnityEngine;

namespace MauriceBaller;

[HarmonyPatch(typeof(MaliciousFace), "HandleCollision")]
public class BallPatch : MonoBehaviour
{
    static bool Prefix(MaliciousFace __instance, Collision other)
    {
        Breakable breakable;
        if (other.gameObject.TryGetComponent(out breakable) && !breakable.playerOnly && !breakable.specialCaseOnly)
        {
            breakable.Break();
            return false;
        }
        
        //base maurice functions
        if (!LayerMaskDefaults.IsMatchingLayer(other.gameObject.layer, LMD.Environment))
        {
            return false;
        }
        if (other.gameObject.CompareTag("Floor"))
        {
            Instantiate(__instance.impactParticle, __instance.transform.position, __instance.transform.rotation);
            __instance.spriteRot.eulerAngles = new Vector3(other.contacts[0].normal.x + 90f, other.contacts[0].normal.y, other.contacts[0].normal.z);
            __instance.spritePos = new Vector3(other.contacts[0].point.x, other.contacts[0].point.y + 0.1f, other.contacts[0].point.z);
            Instantiate(__instance.shockwave.ToAsset(), __instance.spritePos, Quaternion.identity);

            MonoSingleton<CameraController>.Instance.CameraShake(2f);
        }

        //ballify
        AssetBundle bundle = BundleTool.Load("balls.bundle");
        GameObject ball = (GameObject)bundle.LoadAsset("Assets/MauriceBall.prefab");
        
        //ball.AddComponent<PortalTravelFixer>();
        MaliciousCorpse enemyBehaviour = ball.AddComponent<MaliciousCorpse>();
        enemyBehaviour.health = 50;

        ball.transform.position = __instance.transform.position;
        ball.transform.rotation = __instance.transform.rotation;

        //SetupResource.SetupGameObject(ball,true,true);

        Instantiate(ball);

        bundle.Unload(false);

        __instance.BreakCorpse();

        return false;
    }
}

[HarmonyPatch(typeof(EnemyIdentifier), "DeliverDamage")]
public class CustomCorpseEnemyDamageCheck : MonoBehaviour
{
    static bool Prefix(EnemyIdentifier __instance, GameObject target, Vector3 force, Vector3 hitPoint, float multiplier, bool tryForExplode, float critMultiplier = 0f, GameObject sourceWeapon = null, bool ignoreTotalDamageTakenMultiplier = false, bool fromExplosion = false)
    {   
        if(__instance.enemyClass == EnemyClass.Other && __instance.enemyType == EnemyType.MaliciousFace)
        {
            MaliciousCorpse corpse = __instance.GetComponentInChildren<MaliciousCorpse>();
            corpse.GetHurt(target,force,multiplier,critMultiplier,fromExplosion:fromExplosion);
            __instance.health = corpse.health;
            return false;
        }
        return true;
    }
}

[HarmonyPatch(typeof(EnemyIdentifier), "ForceGetHealth")]
public class CustomCorpseEnemyHealthEnabler : MonoBehaviour
{
    static bool Prefix(EnemyIdentifier __instance)
    {   
        if(__instance.enemyClass == EnemyClass.Other && __instance.enemyType == EnemyType.MaliciousFace)
        {
            MaliciousCorpse corpse = __instance.GetComponentInChildren<MaliciousCorpse>();
            __instance.health = corpse.health;
            return false;
        }
        return true;
    }
}