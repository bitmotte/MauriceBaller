using UnityEngine;
using UnityEngine.Events;

namespace MauriceBaller;
public class MaliciousCorpse : EnemyScript 
{
    public EnemyIdentifier eid;
    public Enemy en;
    public Machine mach;
    public Rigidbody rb;

    public Animator controller;

    //settings
    public bool variation = false;

    public float mass;
    public float bounciness;

    public void Awake()
    {
        eid = GetComponent<EnemyIdentifier>();
        en = GetComponent<Enemy>();
        mach = GetComponent<Machine>();
        rb = GetComponent<Rigidbody>();

        controller = GetComponent<Animator>();

        UnityEvent deathEvent = new();
        deathEvent.AddListener(Break);

        eid.onDeath = deathEvent;

        if(variation)
        {
            controller.SetBoolString("Variation",true);
        }
    }

    public override void OnDamage(ref DamageData data)
    {
        if(eid.health <= 0 || data.hitter == "ground slam")
        {
            Break();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        controller.SetTriggerString("Hit");
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