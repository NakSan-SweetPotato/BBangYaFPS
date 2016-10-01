//using UnityEngine;
//using System.Collections;

//public class MobAnimation : MonoBehaviour {
	
//	public AnimationCurve curve=new AnimationCurve(new Keyframe(0,0),new Keyframe(1,1));
//	public float curveSpeed=1;
//	public float moveSpeed =1;
	
//	public Vector3 startPos;

//	public Animation ani;
	
//	void OnTriggerEnter(Collider col) {
//		if(col.tag == "Arm") {
//			curveSpeed = 0;
//			moveSpeed = 0;
//		}
//	}
	
//	// Use this for initialization
//	void Start () {
//		startPos = transform.position;

//		ani.Play ("Walk");		
//	}
	
//	// Update is called once per frame
//	void Update () {
//		Debug.Log("curve : "+curve.Evaluate(Time.time*curveSpeed));
//		transform.position=new Vector3(startPos.x + curve.Evaluate(Time.time*curveSpeed)*10,
//		                               transform.position.y, transform.position.z);
//		transform.Translate(0,0,-moveSpeed*Time.deltaTime);
		
//	}
//}
