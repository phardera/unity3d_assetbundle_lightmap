#pragma strict

@MenuItem ("Assets/Build AssetBundle From Selection - Track dependencies")
static function ExportBundle(){

        var str : String = EditorUtility.SaveFilePanel("Save Bundle...", Application.dataPath, Selection.activeObject.name, "assetbundle");
        if (str.Length != 0){
             BuildPipeline.BuildAssetBundle(
             	Selection.activeObject, 
             	Selection.objects, 
             	str, 
             	BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets);
        }
}