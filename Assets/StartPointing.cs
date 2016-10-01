using UnityEngine;
using System.Collections;

public class Startpointing : MonoBehaviour {
	//public Touch touch=Input.GetTouch;
	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) 
		{
			Input.mousePosition.Set (Input.gyro.rotationRate.x,Input.gyro.rotationRate.y,0);
			
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Debug.DrawRay(ray.origin, ray.direction * 50f, Color.red, 5f);
			
			if (Physics.Raycast(ray, out hit)) { //몹맞추면 제거
				Destroy (hit.transform.gameObject);
			}
		}


	}


}
