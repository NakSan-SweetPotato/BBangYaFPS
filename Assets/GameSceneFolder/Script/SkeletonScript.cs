using UnityEngine;
using System.Collections;

public class SkeletonScript : MonoBehaviour {

	public enum State {
		idle,
		move,
		attack,
		die
	}

	public State PlayerState;
	
	//public GameObject WayPoint1;
	public GameObject WayPoint2;

	public Animation ani;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "WayPoint2") {
			ani.Play("Attack1h1");
			PlayerState = State.attack;

			if(Camera.main.GetComponent <HealthScript>().CurrentHealth-5 > 0 )
			{
				Camera.main.GetComponent <HealthScript>().CurrentHealth-=20;
			}
			else//카메라가 가지고 있는 에너지를 가진 건데 이런 식으로 접근 가능?.
			{//게임 종료하고 씬 전환 해줘야한다.
				Application.LoadLevel("EndingScene");
                Time.timeScale = 1;
            }
		}
	}

	//int ArriveIdx = 2;
	// Use this for initialization
	void Start () {
		ani.Play ("Walk");
		PlayerState = State.move;
		
		//WayPoint1= GameObject.FindWithTag ("WayPoint1");
		//WayPoint2= GameObject.FindWithTag ("WayPoint2");
		
		gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 0);
		WayPoint2 = GameObject.FindWithTag ("WayPoint2");
	}
	
	// Update is called once per frame
	void Update () {

        var Speed = 500.0f * Time.deltaTime;

        switch (PlayerState) {
		case State.idle:
			break;
		case State.move:
			//if (Vector3.Distance (ArrivePoint, gameObject.transform.position) < 2.0f)
			//ArriveIdx = (ArriveIdx + 1) % 3;
			Vector3 front = gameObject.transform.position - WayPoint2.transform.position;
			//front = front.normalized;
			gameObject.transform.forward = new Vector3(front.x,
			                                           gameObject.GetComponent<Rigidbody>().velocity.y,
			                                           front.z);
			front = front.normalized;
			gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (front.x * -2, 0, front.z* -2f);
			break;
		case State.attack:

			break;
		case State.die:
			break;
		}

		

		
	}
}
