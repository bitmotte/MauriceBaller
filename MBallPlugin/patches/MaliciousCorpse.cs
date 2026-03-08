using UnityEngine;
using UnityEngine.Events;

namespace MauriceBaller;
public class MaliciousCorpse : EnemyScript 
{
    public int test = 0;
    public EnemyIdentifier eid;
    public Enemy en;
    public Machine mach;

    public void Awake()
    {
        eid = GetComponent<EnemyIdentifier>();
        en = GetComponent<Enemy>();
        mach = GetComponent<Machine>();
        UnityEvent deathEvent = new();
        deathEvent.AddListener(Break);

        eid.onDeath = deathEvent;
    }

    public override void OnDamage(ref DamageData data)
    {
        if(eid.health <= 0 || data.hitter == "ground slam")
        {
            Break();
        }
    }

    public void Break()
    {
        eid.health = 0;
        en.health = 0;
        mach.health = 0;
        eid.ForceGetHealth();

        gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        foreach (Collider collider in GetComponentsInChildren<Collider>())
        {
            collider.enabled = false;
        }

        Invoke("Destroy",3f);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}