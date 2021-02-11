using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOVerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Circle>().type == Circle.CircleType.Green)
        {
            GameManager.instance.GameOver();
            Debug.Log("Game Over");
        }
        if (collision.gameObject.GetComponent<Circle>().type == Circle.CircleType.Orange)
        {
            GameManager.instance.ScoreUp();
        }

        Destroy(collision.gameObject);
    }
}
