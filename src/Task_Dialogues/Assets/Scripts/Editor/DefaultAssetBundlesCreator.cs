using UnityEditor;

namespace Other.Editor
{
    /// <summary>
    /// Класс для создания AssetBundles
    /// </summary>
    public class DefaultAssetBundlesCreator
    {
        [MenuItem("Assets/Build AssetBundles")]
        static void BuildAllAssetBundles()
        {
            BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneOSXUniversal);
        }
    }
}