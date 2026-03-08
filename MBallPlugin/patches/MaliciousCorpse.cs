using UnityEngine;
using UnityEngine.Events;

namespace MauriceBaller;
public class MaliciousCorpse : EnemyScript 
{
    public int test = 0;
    public EnemyIdentifier eid;

    public void Awake()
    {
        eid = GetComponent<EnemyIdentifier>();
        UnityEvent deathEvent = new();
        deathEvent.AddListener(Break);

        eid.onDeath = deathEvent;
    }

    public override void OnDamage(ref DamageData data)
    {
        if(eid.health <= 0)
        {
            Break();
        }
    }

    public void Break()
    {
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