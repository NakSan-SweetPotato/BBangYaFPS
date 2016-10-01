using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	public int CurrentScore=0;
	public Rect ScorePosition;
	GUIStyle guiStyle = new GUIStyle();
	// Use this for initialization
	void Start () {
		ScorePosition = new Rect (Screen.width /10*8,Screen.height/10*9-10, 100, 30);
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetInt ("Score", CurrentScore);
	}
	
	void OnGUI(){
		GUI.Label (ScorePosition,"<color=red><size=35>"+ CurrentScore.ToString()+"</size></color>",guiStyle);
	}
}
