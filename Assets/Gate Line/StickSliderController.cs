using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSliderController : MonoBehaviour
{
    

    [SerializeField]
    float eulerAngX;
    [SerializeField]
    float eulerAngY;
    [SerializeField]
    float eulerAngZ;

    public float _speed;
    Vector3 touchedPos;

    public handleType type;

    public enum handleType { first,second}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        eulerAngX = transform.localEulerAngles.x;
        eulerAngY = transform.localEulerAngles.y;
        eulerAngZ = transform.localEulerAngles.z;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);         

            if (touch.phase == TouchPhase.Moved)
            {
                touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                

                if (transform.localEulerAngles.z < 230f)
                {
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 230f);
                }

                if (transform.localEulerAngles.z > 315f)
                {
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 315f);
                }               
            
            }

        }

    }

    private void LateUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                if (transform.localEulerAngles.z >= 230f && transform.localEulerAngles.z <= 315f)
                {
                    if(type==handleType.first)
                    {
                        transform.Rotate(0, 0, -touchedPos.y * _speed);
                    }
                    else
                    {
                        transform.Rotate(0, 0, touchedPos.y * _speed);
                    }
                 
                }

            }

        }
    }



}
