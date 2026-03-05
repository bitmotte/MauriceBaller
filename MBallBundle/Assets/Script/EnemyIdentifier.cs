using System;
using System.Collections.Generic;
using Sandbox;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(-500)]
public class EnemyIdentifier : MonoBehaviour
{
    public EnemyClass enemyClass;
    public EnemyType enemyType;
    public bool spawnIn;
    public GameObject spawnEffect;
    public float health;
    public string[] weaknesses;
    public float[] weaknessMultipliers;
    public float totalDamageTakenMultiplier = 1f;
    public GameObject weakPoint;
    public Transform overrideCenter;
    public bool stationary;
    public bool dead;
    public bool ignoredByEnemies;
    public bool useBrakes;
    public bool bigEnemy;
    public bool unbounceable;
    public bool poise;
    public bool immuneToFriendlyFire;
    public bool flying;
    public bool dontCountAsKills;
    public bool dontUnlockBestiary;
    public bool specialOob;
    public GameObject[] activateOnDeath;
    public UnityEvent onDeath;
    public UltrakillEvent onEnable;
    public int difficultyOverride = -1;
    public List<Flammable> burners;
    public bool overrideFlamableSize;
    public Vector3 flamableSize = Vector3.zero;
    [Header("Modifiers")]
    public bool hookIgnore;
    public bool sandified;
    public bool blessed;
    public bool puppet;
    public bool mirrorOnly;
    public float radianceTier = 1f;
    public bool healthBuff;
    public float healthBuffModifier = 1.5f;
    public bool speedBuff;
    public float speedBuffModifier = 1.5f;
    public bool damageBuff;
    public float damageBuffModifier = 1.5f;
    [Space(10f)]
    public List<Renderer> buffUnaffectedRenderers = new List<Renderer>();
    [SerializeField]
    private string overrideFullName;
    [Header("Relationships")]
    public bool ignorePlayer;
    public bool attackEnemies;
    public EnemyTarget target;
    public bool prioritizePlayerOverFallback = true;
    public bool prioritizeEnemiesUnlessAttacked;
    public Transform fallbackTarget;
}
