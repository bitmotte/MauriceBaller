using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MauriceBaller;

public static class BundleTool
{
    public static AssetBundle Load(string fileName) {
        AssetBundle bundle = AssetBundle.LoadFromMemory(EmbeddedAccess.AccessFile(fileName));
        return bundle;
    }
}