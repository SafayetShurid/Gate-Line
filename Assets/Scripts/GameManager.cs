using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public Text highScoreText;

    public bool gameOver;

    public AudioSource scoreUpSound;
    public AudioSource backgroundSound;
    public AudioSource gameOverSound;

    void Start()
    {
        gameOver = false;
        instance = this;
        _timeToWait = timeToWait;
        Instantiate(patterns[Random.Range(0, 20)], initialSpawnPoint.position, Quaternion.identity);
        Instantiate(patterns[Random.Range(0, 20)], spawnPoint.position, Quaternion.identity);

        if(PlayerPrefs.GetInt("Sound",1)==0)
        {
            scoreUpSound.mute = true;
            backgroundSound.mute = true;
            gameOverSound.mute = true;
        }
        else
        {
            scoreUpSound.mute = false;
            backgroundSound.mute = false;
            gameOverSound.mute = false;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = score.ToString();
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
            _timeToWait -= 0.05f;
            timeToWait = _timeToWait;
            //timeToWait -= 0.05f;
            timeToWait = Mathf.Clamp(timeToWait, 2, 4.6f);


        }


       

        if (score > 50)
        {
            spriteRenderer.sprite = bucketSprites[0];
            if (score > 150)
            {
                spriteRenderer.sprite = bucketSprites[1];
            }
        }
    }


    public void GameOver()
    {
        gameOverSound.Play();
        gameOver = true;
        StartCoroutine(LoadGameOverScene());
    }

    public void ScoreUp()
    {
        scoreUpSound.Play();
        score += 1;
    }

    IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(0.5f);
        PlayerPrefs.SetInt("LastScore", score);
        if(score> PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", score);
        }
        SceneManager.LoadScene(2);

    }


  
}
