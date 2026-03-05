using UnityEngine;

public class EnemyTarget
{
    public bool isPlayer;

    public Transform targetTransform;

    public EnemyIdentifier enemyIdentifier;

    public Rigidbody rigidbody;

    public bool isEnemy;

    public Vector3 position;

    public Vector3 headPosition => headTransform.position;

    public Transform headTransform;

    public Transform trackedTransform;

    public Vector3 forward => targetTransform.forward;

    public Vector3 right => targetTransform.right;

    public bool isOnGround;

    public bool isValid;
}
