using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InputManager : MonoBehaviour
{
    private Vector2 _touchStartPos;
    private Vector2 _touchEndPos;
    public Vector2 _Target;
    private Touch _Touch;
    private bool canMove;
    public bool isTouchPress;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            _Touch = Input.GetTouch(0);
            _touchEndPos = _Touch.position;

            if (_Touch.phase == TouchPhase.Began)
            {
                isTouchPress = true;
                _touchStartPos = _Touch.position;
            }

            if (_Touch.phase == TouchPhase.Ended)
            {
                isTouchPress = false;

            }

            if (isTouchPress == true)
            {
                _Target = (_Touch.position - _touchStartPos).normalized;
                //this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(_Target.x * 200, 0f, _Target.y * 200), 0.01f * Time.deltaTime);
                //this.transform.rotation = Quaternion.LookRotation(Vector3.Lerp(this.transform.position, new Vector3(_Target.x * 200, 0f, _Target.y * 200), 400 * Time.deltaTime));
            }
        }
    }

    public Vector2 Target()
    {
        return _Target;
    }


}
