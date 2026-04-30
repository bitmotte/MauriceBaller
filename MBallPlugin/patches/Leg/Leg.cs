using UnityEngine;

public class BallerLeg : MonoBehaviour
{
    private bool goodToGo = false;

    public Transform joint1;
    public Transform joint2;
    public Transform joint3;
    public LineRenderer legRenderer;

    private void Awake()
    {
        joint1 = transform.GetChild(0);
        joint2 = transform.GetChild(1);
        joint3 = transform.GetChild(2);

        transform.GetChild(3).gameObject.TryGetComponent(out legRenderer);
        if(legRenderer == null)
        {
            legRenderer = transform.GetChild(3).gameObject.AddComponent<LineRenderer>();   
        }
        legRenderer.positionCount = 3;

        goodToGo = true;
    }

    private void Update()
    {
        if(!goodToGo) {return;}

        legRenderer.SetPositions([joint1.position,joint2.position,joint3.position]);
    }
}