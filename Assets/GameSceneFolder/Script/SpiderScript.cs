using UnityEngine;
using System.Collections;

public class SpiderScript : MonoBehaviour {


   
    public float _TimerForLevel = 0.0f;
    public float _TimerForLevelLim = 10.0f;

    // Use this for initialization


    public SpiderScript()
    {
        _TimerForLevel = 0.0f;
        _TimerForLevelLim = 10.0f;
    }

    public enum z_State
    {
        attack,
        move,
        attack_left,
        attack_right,
        death,
        idle,
        run,
        walk
    }

    public z_State PlayerState;

    //public GameObject WayPoint1;
    public GameObject WayPoint2;

    public Animation animation;

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("attack !!");
        if (col.tag == "WayPoint2")
        {

            animation.Play("Attack");
            PlayerState = z_State.attack;
            Debug.Log("attack : " + z_State.attack);

            if (Camera.main.GetComponent<HealthScript>().CurrentHealth - 5 > 0)
            {
                Camera.main.GetComponent<HealthScript>().CurrentHealth -= 20;
            }
            else//카메라가 가지고 있는 에너지를 가진 건데 이런 식으로 접근 가능?.
            {//게임 종료하고 씬 전환 해줘야한다.
                Application.LoadLevel("EndingScene");
                Time.timeScale = 1;
            }
        }
    }

    void Start()
    {
        animation.Play("Run");
        PlayerState = z_State.move;
        Debug.Log("Spider run : " + z_State.move);

        //WayPoint1= GameObject.FindWithTag ("WayPoint1");
        //WayPoint2= GameObject.FindWithTag ("WayPoint2");

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        WayPoint2 = GameObject.FindWithTag("WayPoint2");
    }

    // Update is called once per frame
    void Update()
    {
        _TimerForLevel += Time.deltaTime;
        if (_TimerForLevel > _TimerForLevelLim)
        {
            if (Time.timeScale < 2.0f)//
            {
                Time.timeScale *= 1.01f;//게임 진행자체를빨리하는거다....
                _TimerForLevelLim *= 1.01f;
                _TimerForLevel = 0;
            }

        }


        var Speed = 400.0f * Time.deltaTime;
        switch (PlayerState)
        {
            case z_State.walk:
                break;
            case z_State.move:
                //if (Vector3.Distance (ArrivePoint, gameObject.transform.position) < 2.0f)
                //ArriveIdx = (ArriveIdx + 1) % 3;
                Vector3 front = gameObject.transform.position - WayPoint2.transform.position;
                //front = front.normalized;
                gameObject.transform.forward = new Vector3(front.x,
                                                           gameObject.GetComponent<Rigidbody>().velocity.y,
                                                           front.z);
                front = front.normalized;
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Speed * front.x * -(Time.timeScale), 0, Speed * front.z * -(Time.timeScale));
                break;
            case z_State.attack:

                break;

        }

    }

}
