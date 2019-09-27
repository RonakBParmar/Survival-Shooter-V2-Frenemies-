
using UnityEngine;
using System.Collections;
using UnityEditor;

public static class TagLayerExport
{

    [MenuItem("Assets/Export tags and layers")]
    public static void ExportPackage()
    {
        string[] projectContent = new string[] { "Assets/Tycoon Terrain", "ProjectSettings/TagManager.asset" };
        AssetDatabase.ExportPackage(projectContent, "TagLayer.unitypackage", ExportPackageOptions.Interactive | ExportPackageOptions.Recurse | ExportPackageOptions.IncludeDependencies);
        Debug.Log("Project Tags & Layers Exported to TagLayer.unitypackage");

        /*
                string[] projectContent = AssetDatabase.GetAllAssetPaths();

                AssetDatabase.ExportPackage(projectContent, "UltimateTemplate.unitypackage", ExportPackageOptions.Recurse | ExportPackageOptions.IncludeLibraryAssets);
                Debug.Log("Project Exported");
          */
    }

}