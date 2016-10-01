using UnityEngine;
using System.Collections;

public class test : MonoBehaviour{
    public GameObject t;
    public GUIText tt;
	public void onClick()
    {
        
        print("!!" + t.GetComponent<TextAsset>().text);
    }
}
