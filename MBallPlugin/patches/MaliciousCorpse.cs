using ULTRAKILL.Cheats;
using ULTRAKILL.Portal;
using UnityEngine;

namespace MauriceBaller;
public class MaliciousCorpse : Enemy
{
    public override void GetHurt(GameObject target, Vector3 force, float multiplier, float critMultiplier, Vector3 hurtPos = default(Vector3), GameObject sourceWeapon = null, bool fromExplosion = false)
    {
        health -= 1;
        Plugin.Logger.LogInfo(eid.hitter);
        //if (isMassDieing)
        //{
        //    return;
        //}
        //if (IsZombie() && !gc.onGround && eid.hitter != "fire")
        //{
        //    multiplier *= 1.5f;
        //}
        //DamageData data = new DamageData
        //{
        //    hitTarget = target,
        //    hitter = eid.hitter,
        //    damage = multiplier,
        //    sourceWeapon = sourceWeapon,
        //    force = force,
        //    fromExplosion = fromExplosion
        //};
        //string hitLimb = "";
        //bool killed = false;
        //bool flag = false;
        //float healthBeforeDamage = health;
        //bool extraDamageZone = false;
        //if (IsMachine())
        //{
        //    HandleMachineSpecialCases(target, force, fromExplosion, ref data);
        //}
        //if (!limp && force != Vector3.zero && (script == null || script.ShouldKnockback(ref data)))
        //{
        //    bool flag2 = eid.hitter == "heavypunch" || (eid.hitter == "cannonball" && (!gc || !gc.onGround));
        //    eid.useBrakes = !flag2;
        //}
        //if ((bool)script)
        //{
        //    script.OnDamage(ref data);
        //}
        //if (!data.cancel)
        //{
        //    HandleParrying(ref data);
        //}
        //target = data.hitTarget;
        //eid.hitter = data.hitter;
        //multiplier = data.damage;
        //sourceWeapon = data.sourceWeapon;
        //force = data.force;
        //if (!data.cancel)
        //{
        //    float limbMultiplier = CalculateLimbMultiplier(target);
        //    float num = CalculateDamage(multiplier, limbMultiplier, critMultiplier, target, ref extraDamageZone);
        //    if (IsZombie() && chestExploding && !limp && (bool)eid)
        //    {
        //        ChestExplodeEnd();
        //    }
        //    if ((bool)sisy && !limp && eid.hitter == "fire" && health > 0f && health - num < 0.01f && !eid.isGasolined)
        //    {
        //        num = health - 0.01f;
        //    }
        //    if (!eid.blessed && !InvincibleEnemies.Enabled)
        //    {
        //        health -= num;
        //    }
        //    GameObject gameObject = null;
        //    gameObject = HandleBloodSelection(target, num, fromExplosion, extraDamageZone);
        //    if (!limp)
        //    {
        //        flag = true;
        //        hitLimb = DetermineLimbType(target);
        //    }
        //    if (health <= 0f)
        //    {
        //        HandleDeath(target, force, fromExplosion, num);
        //    }
        //    ProcessBloodEffects(gameObject, target, hurtPos);
        //    if (limp)
        //    {
        //        PortalUtils.AddForcePortalAware(target, force * (IsZombie() ? 10f : 1f), ForceMode.Force, searchParent: true);
        //    }
        //    if (IsStatue() && mass != null)
        //    {
        //        HandleMassSpear(target, num, fromExplosion);
        //    }
        //    PlayHurtSound();
        //    if (IsStatue())
        //    {
        //        ApplyWoundedEffect(healthBeforeDamage);
        //    }
        //    if (num == 0f || eid.puppet)
        //    {
        //        flag = false;
        //    }
        //    if (flag && eid.hitter != "enemy")
        //    {
        //        SendStyleInformation(hitLimb, killed, sourceWeapon);
        //    }
        //}
    }
}
