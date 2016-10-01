using UnityEngine;
using System.Collections;

public class MyRay : MonoBehaviour
{
    //public Touch touch=Input.GetTouch;

    public GameObject Mob;

    //원본 파티클 객체
    public GameObject OriginSpark;

    //복제될 파티클 객체
    private GameObject CloneSpark;
    //파티클을 제어하기 위한 Emitter 객체
    private ParticleEmitter Emitter;

    float rotX = 0;
    float rotY = 0;
    float rotZ = 0;

    float initX, initY, initZ;

    Vector3 screenMove;
    float TurnSpeed;

    public int skeletonScore = 2000;
    public int zombieScore = 5000;
    public int spiderScore = 1000;
    public AudioClip shot;
    // Use this for initialization
    void Start()
    {
        //객체를 복제합니다.
        CloneSpark = (GameObject)Instantiate(OriginSpark, OriginSpark.transform.position, OriginSpark.transform.rotation);
        //파티클을 방출하지 않게 만듭니다.
        Emitter = CloneSpark.GetComponent<ParticleEmitter>();
        Emitter.emit = false;
        Input.gyro.enabled = true;
        initX = (Input.gyro.rotationRate.x);
        initY = (Input.gyro.rotationRate.y);

        TurnSpeed = 4f;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        //버튼을 눌러서 레이가 중앙에만 작동하게 하면되는거다.
        double initTime = Time.time;
        if (Input.anyKeyDown)//어떤 버튼이든 눌려서 들어온다면.
        {

            GetComponent<AudioSource>().Play();

            Screen screen = new Screen();

            float sWidth = Screen.width;
            float sHeight = Screen.height;
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(sWidth / 2, sHeight / 2));

            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 50f, Color.red, 5f);


            if (Physics.Raycast(ray, out hit))
            { //몹맞추면 제거

                if (hit.transform.gameObject.tag == "mob")
                {
                    //파티클 생성
                    CloneSpark.transform.position = hit.transform.position;
                    Emitter.Emit();

                    if (hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth - 51 > 0)
                    {
                        Debug.Log("hp = " + hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth);
                        hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth -= 50;
                    }
                    else
                    {//게임 종료하고 씬 전환 해줘야한다.
                        Destroy(hit.transform.gameObject);
                        Camera.main.GetComponent<ScoreScript>().CurrentScore += skeletonScore;
                    }

                    //Destroy(hit.transform.gameObject);//바로 디스트로이드 하는게 아니라 체력을 이용하자
                    //Camera.main.GetComponent<ScoreScript>().CurrentScore += skeletonScore;

                }
                else if (hit.transform.gameObject.tag == "mob2")
                {
                    //파티클 생성
                    CloneSpark.transform.position = hit.transform.position;
                    Emitter.Emit();

                    if (hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth - 51 > 0)
                    {
                        Debug.Log("hp = " + hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth);
                        hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth -= 50;
                    }
                    else
                    {//게임 종료하고 씬 전환 해줘야한다.
                        Destroy(hit.transform.gameObject);
                        Camera.main.GetComponent<ScoreScript>().CurrentScore += zombieScore;
                    }


                }

                else if (hit.transform.gameObject.tag == "mob3")
                {
                    //파티클 생성
                    CloneSpark.transform.position = hit.transform.position;
                    Emitter.Emit();

                    //if (hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth - 31 > 0)
                    //{
                    //    Debug.Log("hp = " + hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth);
                    //    hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth -= 30;
                    //}
                    //else
                    //{//게임 종료하고 씬 전환 해줘야한다.
                    Destroy(hit.transform.gameObject);
                    Camera.main.GetComponent<ScoreScript>().CurrentScore += spiderScore;
                    //}



                }

            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.LoadLevel("StartScene");
            }

        }

        //------------------------------------마우스로

        if (Input.GetMouseButtonDown(0))
        {
        
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 50f, Color.red, 5f);

            GetComponent<AudioSource>().Play();

            if (Physics.Raycast(ray, out hit))
            { //몹맞추면 제거

                if (hit.transform.gameObject.tag == "mob")
                {
                    //파티클 생성
                    CloneSpark.transform.position = hit.transform.position;
                    Emitter.Emit();

                    if (hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth - 51 > 0)
                    {
                        Debug.Log("hp = " + hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth);
                        hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth -= 50;
                    }
                    else
                    {//게임 종료하고 씬 전환 해줘야한다.
                        Destroy(hit.transform.gameObject);
                        Camera.main.GetComponent<ScoreScript>().CurrentScore += skeletonScore;
                    }

                    //Destroy(hit.transform.gameObject);//바로 디스트로이드 하는게 아니라 체력을 이용하자
                    //Camera.main.GetComponent<ScoreScript>().CurrentScore += skeletonScore;

                }
                else if (hit.transform.gameObject.tag == "mob2")
                {
                    //파티클 생성
                    CloneSpark.transform.position = hit.transform.position;
                    Emitter.Emit();

                    if (hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth - 51 > 0)
                    {
                        Debug.Log("hp = " + hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth);
                        hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth -= 50;
                    }
                    else
                    {//게임 종료하고 씬 전환 해줘야한다.
                        Destroy(hit.transform.gameObject);
                        Camera.main.GetComponent<ScoreScript>().CurrentScore += zombieScore;
                    }


                }

                else if (hit.transform.gameObject.tag == "mob3")
                {
                    //파티클 생성
                    CloneSpark.transform.position = hit.transform.position;
                    Emitter.Emit();

                    //if (hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth - 31 > 0)
                    //{
                    //    Debug.Log("hp = " + hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth);
                    //    hit.transform.gameObject.GetComponent<MobHeath>().CurrentHealth -= 30;
                    //}
                    //else
                    //{//게임 종료하고 씬 전환 해줘야한다.
                        Destroy(hit.transform.gameObject);
                        Camera.main.GetComponent<ScoreScript>().CurrentScore += spiderScore;
                    //}

                    

                }

            }


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.LoadLevel("StartScene");
            }
        }

        float xAxis = (Input.gyro.rotationRate.x);
        float yAxis = (Input.gyro.rotationRate.y);
        float zAxis = (Input.gyro.rotationRate.z);
        float flx = (float)xAxis - (float)initX;
        float fly = (float)yAxis - (float)initY;
        float flz = (float)zAxis - (float)initZ;

        double dt = Time.time;
        dt -= initTime;

        rotX = (float)(0.98 * (rotX + flx) + 0.02 * Input.acceleration.x);
        rotY = (float)(rotY + fly);
        rotZ = 0;

        //카메라 각도 조절 >> 자이로좌표받아서 이동하는 걸로!

        float qx, qy, qz;
        qx = rotX;
        qy = rotY;
        qz = 0;

        qx *= (float)1.0;
        qy *= (float)2.0;
        qz *= (float)1.0;

        Quaternion target = Quaternion.Euler(-qx, -qy, -qz);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * TurnSpeed);

    }

}
