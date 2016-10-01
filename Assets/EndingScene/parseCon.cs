using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;
using System.Threading.Tasks;

public class parseCon : MonoBehaviour
{

    List<ParseObject> members;
    public List<GUIContent> items;

    public Vector2 scrollVector;

    public List<User> users;

    public bool flag = false;
    public string stringToEdit = "";
    public int insertFlag = 0 ;
    public int insertFlagSelect = 0;

    public static bool checkFirst = true;

    void bubleSort()
    {
        for (int k = 0; k < users.Count - 1; k++)
        {
            for (int i = 0; i < users.Count - 1 - k; i++)
            {
                if (users[i].score < users[i + 1].score)
                {
                    User temp = users[i];
                    users[i] = users[i + 1];
                    users[i + 1] = temp;
                }

            }
        }
    }

    void OnGUI()
    {
        print("flag : " + flag);
          if (flag == false) return;
        
        GUILayout.BeginArea(new Rect(Screen.width- Screen.width/3-10, 0 , Screen.width / 3, Screen.height));

        GUILayout.BeginVertical(GUI.skin.box);
        scrollVector = GUILayout.BeginScrollView(scrollVector);
        float Height = 0;
        bubleSort();
		GUIStyle guiStyle = new GUIStyle();
		guiStyle.fontSize = 40;
        for (int i = 0; i < users.Count; i++)
        {
            // if (items[i] != null) // 이걸 추가
			GUI.color=Color.red;
			GUI.Label(new Rect(0, Height, Screen.width / 2, 20),"<color=red><size=35>"+(i+1)+"위 "+ users[i].name + " , " + users[i].score+"점</size></color>",guiStyle);
            Height += Screen.height / 10;
            /*
                if (GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition))
                {
                    Debug.Log(items[i].text);
                }
            */
        }
        GUILayout.EndScrollView();
        GUILayout.EndVertical();
        GUILayout.EndArea();
        print("gui done "+flag);
        //public string stringToEdit = "";

        //stringToEdit = GUI.TextField(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 4, Screen.width / 2, Screen.height / 10), stringToEdit, 25);
        //if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 4 + Screen.height / 10, Screen.width / 2, Screen.height / 10), "입력"))


		stringToEdit = GUI.TextField(new Rect(Screen.width / 6-10, Screen.height / 2 - Screen.height / 4, Screen.width / 2, Screen.height / 10), stringToEdit, 25);
        if (GUI.Button(new Rect(Screen.width /6 -10, Screen.height / 2 - Screen.height / 4 + Screen.height / 10, Screen.width / 2, Screen.height / 10), "입력"))
        {

			int myScore = PlayerPrefs.GetInt("Score");
			parseInsert(stringToEdit, myScore);//여기에다가 스코어를 넣어주면된다.
            PlayerPrefs.DeleteAll();
        }
    }


    // Use this for initialization
    void Start()
    {
        checkFirst = true;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        insertFlag = 0;
        items = new List<GUIContent>();
        //for (int i = 0; i < 10; i++)
        //{
        //    GUIContent content = new GUIContent();
        //    content.text = "이성하 " + i;
        //    items.Add(content);
        //}

        users = new List<User>();
        members = new List<ParseObject>();
        parseSelect2();
    }

    // Update is called once per frame
    void Update()
    {
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

                if (hit.transform.gameObject.tag == "BtnRanking")
                {
                    int myScore = PlayerPrefs.GetInt("Score");
                    parseInsert(stringToEdit, myScore);//여기에다가 스코어를 넣어주면된다.
                }

            }
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				Application.LoadLevel("StartScene");
			}

        }





        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 50f, Color.red, 5f);
            if (Physics.Raycast(ray, out hit))
            { //몹맞추면 제거
                if (hit.transform.gameObject.tag == "BtnRanking")
                {
                    int myScore = PlayerPrefs.GetInt("Score");
                    parseInsert(stringToEdit, myScore);//여기에다가 스코어를 넣어주면된다.
                    PlayerPrefs.DeleteAll();
                }
               
            }
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				Application.LoadLevel("StartScene");
			}
        }
    }

    void parseInsert(string name, int score)
    {
        if (checkFirst)
        {
            if (score > 0)
            {
                flag = false;

                Debug.Log("parse gogogo");
                ParseObject gameScore = new ParseObject("GameScore");

                gameScore["score"] = score;
                gameScore["playerName"] = name;

                Task saveTask = gameScore.SaveAsync();

                parseSelect2();
                checkFirst = false;
            }


        }
    }



    void parseSelect()
    {
        ParseQuery<ParseObject> query = ParseObject.GetQuery("GameScore").Limit(10).OrderByDescending("createdAt");

        query.GetAsync("4Sm3zdZ8aH").ContinueWith(t =>
        {
            ParseObject gameScore = t.Result;
            string playerName = gameScore.Get<string>("playerName");
            Debug.Log("select");
            Debug.Log(playerName);
        });
    }

    void parseSelect2()
    {
        users = new List<User>();
        ParseQuery<ParseObject> query = ParseObject.GetQuery("GameScore").WhereExists("playerName");
        //items = new List<GUIContent>();

        query.FindAsync().ContinueWith(t =>
        {

            Debug.Log("members");

            foreach (ParseObject member in t.Result)
            {
                string playerName = member.Get<string>("playerName");
                int score = member.Get<int>("score");
                User user = new User();
                user.score = score;
                user.name = playerName;
                users.Add(user);
            }
        });
        if (insertFlag==1)
        {
            insertFlagSelect = 1;
            insertFlag = 0;
        }
        print("done");//분명히 얘는 한번만 호출되는데 저게...
        flag = true;
    }

    public class User
    {
        public int score;
        public string name;
    }


}
