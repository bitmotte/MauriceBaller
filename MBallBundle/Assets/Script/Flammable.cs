using UnityEngine;
using UnityEngine.Events;

public class Flammable : MonoBehaviour
{
    public float heat;

    public float fuel;

    public bool burning;

    public bool secondary;

    public bool fuelOnly;

    public bool wet;

    public Vector3 overrideSize = Vector3.zero;

    public bool useOverrideSize;

    public bool playerOnly;

    public bool enemyOnly;

    public bool specialFlammable;

    public UnityEvent onSpecialActivate;
}
