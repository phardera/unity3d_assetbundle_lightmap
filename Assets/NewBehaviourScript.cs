using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
    WWW aa = null;
	void Start () {
        
        string path = "file://" + Application.dataPath + "/StaticObj.assetbundle";
        Debug.Log("load file from :" + path);
        aa = new WWW(path);

        useGUILayout = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (aa !=null && aa.isDone)
        {
            //load lightmap
            Debug.Log("load lightmap...");
            List<LightmapData> arrld = new List<LightmapData>();
            LightmapData ld = new LightmapData();
            ld.lightmapFar = aa.assetBundle.Load("LightmapFar-0", typeof(Texture2D)) as Texture2D;
            ld.lightmapNear = aa.assetBundle.Load("LightmapNear-0", typeof(Texture2D)) as Texture2D;
            arrld.Add(ld);

            LightmapSettings.lightmapsMode = LightmapsMode.Dual;
            LightmapSettings.lightmaps = arrld.ToArray();

            //load model
            Debug.Log("load model...");
            GameObject go = GameObject.Instantiate(aa.assetBundle.Load("StaticObj", typeof(GameObject))) as GameObject;
            aa = null;
        }
	}
}
