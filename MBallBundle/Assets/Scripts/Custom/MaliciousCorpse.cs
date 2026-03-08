using UnityEngine;
using UnityEngine.Events;

namespace MauriceBaller
{
    public class MaliciousCorpse : EnemyScript 
    {
        public int test = 0;
        public EnemyIdentifier eid;

        public void Awake()
        {
            eid = GetComponent<EnemyIdentifier>();
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
            Destroy(gameObject);
        }
    }
}