using System.Threading;
using HarmonyLib;
using ULTRAKILL.Enemy;
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
        GameObject ball = (GameObject)bundle.LoadAsset("Assets/MaliciousCorpse.prefab");
        
        ball.AddComponent<MaliciousCorpse>();

        ball.transform.position = __instance.transform.position;
        ball.transform.rotation = __instance.transform.rotation;

        Instantiate(ball);

        bundle.Unload(false);

        __instance.BreakCorpse();

        return false;
    }
}

[HarmonyPatch(typeof(TargetTracker), "RegisterTarget")]
public class DontTargetBallPatch : MonoBehaviour
{
    static bool Prefix(TargetTracker __instance, ITarget target, CancellationToken token)
    {
        if(target.EID == null) {return true;}
        if(target.EID.GetComponent<MaliciousCorpse>() != null)
        {
            return false;
        }
        return true;
    }
}