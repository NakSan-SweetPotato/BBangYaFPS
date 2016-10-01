using UnityEngine;
using System.Collections;

public class StartUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		//public string stringToEdit = "";
		//stringToEdit = GUI.TextField(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 4, Screen.width / 2, Screen.height / 10), stringToEdit, 25);
		if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 4 + Screen.height / 10, Screen.width / 2, Screen.height / 10), "시작"))
		{
			Application .LoadLevel ("GameScene");
		}
		if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 4 + Screen.height / 10*2, Screen.width / 2, Screen.height / 10), "랭킹"))
		{
            PlayerPrefs.DeleteAll();
            Application .LoadLevel ("EndingScene");
		}
		
		if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 4 + Screen.height / 10*3, Screen.width / 2, Screen.height / 10), "끝내기"))
		{
			Application.Quit ();
		}
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
