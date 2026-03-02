using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MauriceBaller;

public static class SetupResource
{
    public static GameObject SetupGameObject(GameObject gameObject, bool vertexLighting, bool enemy)
    {
        // Load material with "ULTRAKILL/Master" shader . . . and grab its shader
        Shader Master = Addressables.LoadAssetAsync<Material>("Assets/Materials/Environment/Metal/Pattern 1/Metal Pattern 1 8.mat").WaitForCompletion().shader;
        
        foreach (MeshRenderer still in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            foreach (Material mat in still.materials)
            {
                mat.shader = Master;
                
                List<string> keywords = [.. mat.shaderKeywords];
                keywords.Add("ENEMY");
                keywords.Add("PORTAL_CLIP_PLANE");
                keywords.Add("VERTEX_LIGHTING");
                keywords.Add("_FOG_ON");
                keywords.Add("_GLITCHMODE_NONE");
                keywords.Add("_RAINCEILINGTOGGLE_ON");
                keywords.Add("_USEALBEDOASEMISIVE_ON");
                keywords.Add("_VERTEXCOLORS_ON");
                keywords.Add("_VERTEXLIGHTING_ON");
                keywords.Add("_ZWRITE_ON");
                mat.shaderKeywords = [.. keywords];
            }
        }

        return gameObject;
    }
}