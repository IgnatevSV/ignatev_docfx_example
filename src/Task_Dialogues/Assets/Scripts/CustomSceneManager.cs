using UnityEngine;
using UnityEngine.SceneManagement;

namespace Other
{
    /// <summary>
    /// Класс для управления сценами.
    /// </summary>
    public class CustomSceneManager : MonoBehaviour
    {
        const string BASE_SCENE = "BaseScene";
        const string CUSTOM_DIALOGUE_EXAMPLE_SCENE = "CustomDialogueExampleScene";
        const string ASSET_BUNDLES_EXAMPLE_SCENE = "AssetBundlesExampleScene";

        public void LoadBaseScene()
        {
            SceneManager.LoadScene(BASE_SCENE);
        }

        public void LoadCustomDialogueExampleScene()
        {
            SceneManager.LoadScene(CUSTOM_DIALOGUE_EXAMPLE_SCENE);
        }

        public void LoadAssetBundlesExampleScene()
        {
            SceneManager.LoadScene(ASSET_BUNDLES_EXAMPLE_SCENE);
        }

        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}