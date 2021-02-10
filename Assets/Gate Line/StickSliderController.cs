using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSliderController : MonoBehaviour
{
    public Transform[] _stick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Touch _touch = new Touch();
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                _stick[0].Rotate(0,0,-touchedPos.y);
                _stick[1].Rotate(0, 0, touchedPos.y);
                // _playerObject.transform.position = Vector3.Lerp(_playerObject.transform.position, Vector2.left * -touchedPos.x, _playerMovementSpeed * Time.deltaTime);
                // Vector2 _rangePos = _playerObject.transform.position;
                // _rangePos.x = Mathf.Clamp(_rangePos.x, _left_right_distance.x, _left_right_distance.y);
                // _playerObject.transform.position = _rangePos;
                // _slider.value = touchedPos.x;
            }

            else
            {
               // _slider.gameObject.SetActive(false);
            }
        }

    }
}
