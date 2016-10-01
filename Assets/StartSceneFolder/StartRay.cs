using UnityEngine;
using System.Collections;

public class StartRay : MonoBehaviour
{

    public int selectFlag = 0;
    public string select;
    Vector3 screenMove;

    // Use this for initialization
    void Start()
    {
        //객체를 복제합니다.
        select = "Yet";
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    void onGUI()
    {
        if(selectFlag ==1)
        {
        GUI.Label(new Rect(10,10,30,10),select);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //버튼을 눌러서 레이가 중앙에만 작동하게 하면되는거다.

        if (Input.anyKeyDown)//어떤 버튼이든 눌려서 들어온다면.
        {
            Screen screen = new Screen();

            float sWidth = Screen.width;
            float sHeight = Screen.height;
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(sWidth / 2, sHeight / 2));

            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 50f, Color.red, 5f);


            if (Physics.Raycast(ray, out hit))
            { //몹맞추면 제거
                if (hit.transform.gameObject.tag == "one")
                {
                    selectFlag = 1;
                    select = "GameScene"; 
                    Application.LoadLevel("GameScene");
                }
                if (hit.transform.gameObject.tag == "two")
                {
                    selectFlag = 1;
                    select = "EndingScene"; 
                    Application.LoadLevel("EndingScene");
                }
                if (hit.transform.gameObject.tag == "three")
                {
                    selectFlag = 1;
                    //select = "EndingScene"; 
                    Application.Quit();
                }
				if(Input.GetKeyDown(KeyCode.Escape)){
					Application.Quit();
				}



            }

        }


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 50f, Color.red, 5f);
            Debug.Log("oneQQQQ !!!!");
            if (Physics.Raycast(ray, out hit))
            { //몹맞추면 제거
                Debug.Log(hit.transform.gameObject.tag);
                if (hit.transform.gameObject.tag == "one")
                {
                    Application.LoadLevel("GameScene");
                }
                if (hit.transform.gameObject.tag == "two")
                {
                    Application.LoadLevel("EndingScene");
                }
                if (hit.transform.gameObject.tag == "three")
                {
                    
					Application.Quit();

                }

				if(Input.GetKeyDown(KeyCode.Escape)){
					Application.Quit();
				}
            }
        }

    }

}
