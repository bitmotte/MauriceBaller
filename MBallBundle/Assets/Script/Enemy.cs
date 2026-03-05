using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Type")]
    public bool isZombie;

    public bool isStatue;

    public bool isMachine;

    public bool isSpider;

    public bool isDrone;

    [Header("Combat")]
    public float health;

    public bool noFallDamage;

    public bool dontDie;

    public bool specialDeath;

    public bool simpleDeath;

    public bool dismemberment;

    [HideInInspector]
    public float originalHealth;

    public bool limp;

    public bool grounded;

    public bool knockedBack;

    public bool falling;

    public float fallTime;

    public float brakes = 1f;

    public float juggleWeight;

    public int parryFramesLeft;

    public bool parryable;

    public bool partiallyParryable;

    [HideInInspector]
    public List<Transform> parryables = new List<Transform>();

    protected bool parryFramesOnPartial;

    public bool isMassDeath;

    public bool isMassDieing;

    [Header("Audio")]
    public AudioClip hurtSound;

    public AudioClip[] hurtSounds;

    public float hurtSoundVol;

    public AudioClip deathSound;

    public float deathSoundVol;

    public AudioClip scream;

    protected AudioSource aud;

    [Header("References")]
    public GameObject chest;

    public Transform bodyCenter;

    public Transform rotationTransform;

    public SkinnedMeshRenderer smr;

    public GoreZone gz;

    public Transform hitJiggleRoot;

    public Enemy symbiote;

    public BloodsplatterManager bsm;

    [Header("Materials")]
    public Material deadMaterial;

    public Material woundedMaterial;

    public Material woundedEnrageMaterial;

    protected Material originalMaterial;

    [Header("Effects")]
    public GameObject woundedParticle;

    public GameObject woundedModel;

    public GameObject enrageEffect;

    public GameObject[] destroyOnDeath = new GameObject[0];

    [Header("Enemy Settings")]
    public bool bigKill;

    public bool thickLimbs;

    public bool overrideFalling;

    protected bool symbiotic;

    protected bool healing;

    protected Vector3 jiggleRootPosition;

    public List<GameObject> extraDamageZones = new List<GameObject>();

    public float extraDamageMultiplier;

    public bool bigBlood;

    public readonly List<Transform> transforms = new List<Transform>();

    protected bool affectedByGravity = true;

    public bool variableSpeed;

    public bool stopped;

    public bool isOnOffNavmeshLink;

    public bool chestExploding;

    protected bool chestExploded;

    protected bool attacking;

    protected float defaultSpeed;

    protected float speedMultiplier = 1f;

    private float maxFallSpeed = -500f;

    private float terminalVelocityTimer;

    public LayerMask lmask;

    public LayerMask lmaskEnv;

    public LayerMask lmaskWater;

    [Header("Events")]
    public UnityEvent onDeath;

    public TimeSince lastTargetTick;

    public Quaternion postPortalOffsetRot;
}
