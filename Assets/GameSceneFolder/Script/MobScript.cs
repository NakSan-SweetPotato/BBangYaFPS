using UnityEngine;
using System.Collections;

public class MobScript: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(0, 0, -0.05f);
	}
	void OnTriggerEnter(Collider coll){ //몹이 사용자 공격시 제거&HP감.
		if (coll.transform.tag == "WayPoint2") {

			//Destroy (this.gameObject );
			
            if(Camera.main.GetComponent <HealthScript>().CurrentHealth-5 > 0 )
            {
               Camera.main.GetComponent <HealthScript>().CurrentHealth-=20;
            }
            else//카메라가 가지고 있는 에너지를 가진 건데 이런 식으로 접근 가능?.
            {//게임 종료하고 씬 전환 해줘야한다.
				Application.LoadLevel("EndingScene");
            }
		}
	}


}
