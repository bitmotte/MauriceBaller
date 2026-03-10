using UnityEngine;

public class CorpseLegController : MonoBehaviour
{
    public BallerLeg leg1;
    public BallerLeg leg2;
    public BallerLeg leg3;
    public BallerLeg leg4;


    void Awake()
    {
        leg1 = transform.GetChild(0).gameObject.AddComponent<BallerLeg>();
        leg2 = transform.GetChild(1).gameObject.AddComponent<BallerLeg>();
        leg3 = transform.GetChild(2).gameObject.AddComponent<BallerLeg>();
        leg4 = transform.GetChild(3).gameObject.AddComponent<BallerLeg>();
    }
}