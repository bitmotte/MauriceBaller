using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ULTRAKILL.Portal
{
    public class SimplePortalTraveler : MonoBehaviour
    {
        [Header("Transforms")]
        public bool transformPosition = true;

        public bool transformRotation = true;

        public bool transformVelocity = true;

        [Header("Extras")]
        public bool clearTrail = true;

        public PortalTravellerType travellerType;

        public int id => GetInstanceID();

        public int? targetId { get; set; }

        public Vector3 travellerPosition;

        public Vector3 travellerVelocity;
    }
}
