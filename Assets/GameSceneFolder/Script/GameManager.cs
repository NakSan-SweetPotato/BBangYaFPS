using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public GameObject[] mobs;
    public GameObject[] zombies;
    public GameObject[] spiders;
    public float delay = 2f;

    int stage = 2;


    IEnumerator Start()
    {
        StartCoroutine(Upgrade());
        StartCoroutine(StageUp());
        StartCoroutine(MakeSpider());
        
        while (Application.isPlaying)
        {
            int pointPos = Random.Range(-300, 400);
            transform.position = new Vector3(pointPos / 10, 3.8f, transform.position.z);

            //	Debug.Log("mobs.Length"+mobs.Length );
            GameObject e = mobs[Random.Range(0, mobs.Length)];
            Instantiate(e, transform.position, e.transform.rotation);
            //Debug.Log("zombies.Length"+zombies.Length );

            //GameObject eo=zombies[Random.Range (0, zombies.Length)];
            //Instantiate(eo,transform.position,eo.transform.rotation);
            
            yield return new WaitForSeconds(delay);
        }


    }

    float zombieEmegeTime = 5f;//좀비가 나오는 시점  .
    float spiderEmegerTime = 1f;//거미가 나오는시점

    IEnumerator Upgrade()
    {
        Debug.Log("업그레이드");
        yield return new WaitForSeconds(zombieEmegeTime);
        delay -= 0.01f; // 딜레이가 점점 짧아지면서 빨리나오는거지.
        StartCoroutine(Upgrade());
    }

    IEnumerator StageUp()
    {
        yield return new WaitForSeconds(zombieEmegeTime);
        stage++;

        StartCoroutine(MakeZombie());
        
    }

    IEnumerator MakeZombie()
    {
        if (stage > 1)
        {
            yield return new WaitForSeconds(zombieEmegeTime);

            //GetComponent<ZombieMove>().z=true;

            while (Application.isPlaying)
            {
                //Zombie
                int pointPos = Random.Range(-300, 400);
                transform.position = new Vector3(pointPos / 10, 3.8f, transform.position.z);
                GameObject p = zombies[Random.Range(0, zombies.Length)];
                Instantiate(p, transform.position, p.transform.rotation);
                yield return new WaitForSeconds(delay);
            }

            

        }
    }

    IEnumerator MakeSpider()
    {
        if (stage > 1)
        {
            yield return new WaitForSeconds(spiderEmegerTime);

            while (Application.isPlaying)
            {
                //spider
                int pointPos2 = Random.Range(-300, 400);
                transform.position = new Vector3(pointPos2 / 10, 0, transform.position.z);
                GameObject p2 = spiders[Random.Range(0, spiders.Length)];
                Instantiate(p2, transform.position, p2.transform.rotation);

                yield return new WaitForSeconds(delay);
            }
        }
    }

}