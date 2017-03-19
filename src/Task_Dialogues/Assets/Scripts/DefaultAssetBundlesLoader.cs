using System;
using UnityEngine;
using System.Collections;

namespace Other.Editor
{
    /// <summary>
    /// Класс для выгрузки ассетов из AssetBundles.
    /// </summary>
    public class DefaultAssetBundlesLoader : MonoBehaviour
    {
        [SerializeField]
        string _bundleURL;

        [SerializeField]
        string[] _assetsNames;

        [SerializeField]
        int _version;

        void Start()
        {
            for (int i = 0; i < _assetsNames.Length; i++)
            {
                StartCoroutine(DownloadAndCache(_assetsNames[i]));
            }
        }

        IEnumerator DownloadAndCache(string assetName)
        {
            while (!Caching.ready)
                yield return null;

            using (WWW www = WWW.LoadFromCacheOrDownload(_bundleURL, _version))
            {
                yield return www;
                if (www.error != null)
                    throw new Exception("WWW download had an error:" + www.error);
                AssetBundle bundle = www.assetBundle;
                if (assetName == "")
                    Instantiate(bundle.mainAsset);
                else
                    Instantiate(bundle.LoadAsset(assetName));

                bundle.Unload(false);

            }
        }
    }
}