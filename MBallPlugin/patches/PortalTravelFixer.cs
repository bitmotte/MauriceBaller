using ULTRAKILL.Portal;
using UnityEngine;

namespace MauriceBaller;
public class PortalTravelFixer : MonoBehaviour 
{
    void Start()
    {
        gameObject.GetComponent<SimplePortalTraveler>().SetType(PortalTravellerType.OTHER);
    }
}