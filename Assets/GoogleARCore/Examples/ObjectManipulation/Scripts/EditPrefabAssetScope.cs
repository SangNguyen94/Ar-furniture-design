// namespace GoogleARCore.Examples.ObjectManipulation
// {
//     using System.Collections;
//     using System.Collections.Generic;
//     using UnityEngine;
//     using GoogleARCore;
// public class EditPrefabAssetScope : IDisposable {
 
//     public readonly string assetPath;
//     public readonly GameObject prefabRoot;
 
//     public EditPrefabAssetScope(string assetPath) {
//         this.assetPath = assetPath;
//         prefabRoot = PrefabUtility.LoadPrefabContents(assetPath);
//     }
 
//     public void Dispose() {
//         PrefabUtility.SaveAsPrefabAsset(prefabRoot, assetPath);
//         PrefabUtility.UnloadPrefabContents(prefabRoot);
//     }
// }
// }