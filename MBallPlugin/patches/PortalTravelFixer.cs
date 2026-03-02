using ULTRAKILL.Portal;
using UnityEngine;

namespace MauriceBaller;
class PortalTravelFixer : MonoBehaviour 
{
    void Start()
    {
        gameObject.GetComponentInChildren<SimplePortalTraveler>().SetType(PortalTravellerType.OTHER);
    }
}