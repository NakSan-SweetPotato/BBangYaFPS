using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	
	public int MaxHealth=100;
	public int CurrentHealth=100;
	public float HealthBarLength;
	
	// Use this for initialization
	void Start () {
		//HP바의 길이를 구한다.
		HealthBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI(){
		//HP최소치와 최대치 설정
		if (CurrentHealth < 0) {
			CurrentHealth = 0;
		} else if (MaxHealth < CurrentHealth) {
			CurrentHealth =MaxHealth ;
		}


        //GUI.Label (ScorePosition,"<color=red><size=35>"+ CurrentScore.ToString()+"</size></color>",guiStyle);
        GUI.Box(new Rect(Screen.width / 12, Screen.height / 10 * 9, CurrentHealth * 3, 40), "<color=red><size=24>" + CurrentHealth + "/" + MaxHealth + "</size></color>");



        //GUI.Box (new Rect (Screen.width/12,Screen.height/10*9 , CurrentHealth*3, 40)," ");
    }


}
