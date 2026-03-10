using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MauriceBaller;
public class CorpseLegController : MonoBehaviour
{
    public BallerLeg[] legs;
    public LineRenderer exampleRenderer;
    public Material legMat;

    void Awake()
    {
        exampleRenderer = transform.GetComponent<LineRenderer>();

        for (int i = 0; i < 4; i++)
        {
            BallerLeg leg = transform.GetChild(i).gameObject.AddComponent<BallerLeg>();

            legMat = Addressables.LoadAssetAsync<Material>("Assets/Materials/Dev/SpiderLeg.mat").WaitForCompletion();
            leg.legRenderer.material = legMat;
            
            leg.legRenderer.widthCurve = exampleRenderer.widthCurve;
            leg.legRenderer.colorGradient = exampleRenderer.colorGradient;
            leg.legRenderer.alignment = exampleRenderer.alignment;
            leg.legRenderer.numCapVertices = exampleRenderer.numCapVertices;
            leg.legRenderer.lightProbeUsage = exampleRenderer.lightProbeUsage;
            leg.legRenderer.allowOcclusionWhenDynamic = exampleRenderer.allowOcclusionWhenDynamic;

            legs = legs.Append(leg).ToArray();
        }
    }
}