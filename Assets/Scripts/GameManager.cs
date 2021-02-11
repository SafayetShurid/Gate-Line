using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] patterns;

    public float timeToWait;
    public Transform spawnPoint;
    public Transform initialSpawnPoint;
    private float _timeToWait;
    public int score = 0;

    private float liniarDrag = 4.0f;

    public static GameManager instance;

    public Sprite[] bucketSprites;
    public SpriteRenderer spriteRenderer;
   

    void Start()
    {
        instance = this;
           _timeToWait = timeToWait;
        Instantiate(patterns[Random.Range(0, 20)], initialSpawnPoint.position, Quaternion.identity);
        Instantiate(patterns[Random.Range(0, 20)], spawnPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timeToWait -= Time.deltaTime;
        if(timeToWait<0)
        {
           GameObject go = Instantiate(patterns[Random.Range(0, patterns.Length)],spawnPoint.position,Quaternion.identity);
            int len = go.transform.childCount;

            for(int i =0; i<len;i++)
            {
                go.transform.GetChild(i).GetComponent<Rigidbody2D>().drag =liniarDrag;
            }

            liniarDrag -= 0.1f;
            liniarDrag = Mathf.Clamp(liniarDrag, 1, 4);
            timeToWait = _timeToWait;
            timeToWait -= 0.1f;
            timeToWait = Mathf.Clamp(timeToWait, 4, 5);


        }


        if(score>150)
        {
            spriteRenderer.sprite = bucketSprites[1];
        }

        if (score > 50)
        {
            spriteRenderer.sprite = bucketSprites[0];
        }

    }

  
}
