using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    InputManager inputManager;
    AnimationController animationController;


    private float movementSpeed;
    public bool isPlayerIdle;
    public bool isPlayerRun;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 0.02f;
        inputManager = this.GetComponent<InputManager>();
        animationController = GameObject.FindGameObjectWithTag("AnimationController").GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputManager.isTouchPress == true)
        {
            isPlayerIdle = false;
            isPlayerRun = true;
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(inputManager._Target.x * 200, 0f, inputManager._Target.y * 200), movementSpeed * Time.deltaTime);
            this.transform.rotation = Quaternion.LookRotation(Vector3.Lerp(this.transform.position, new Vector3(inputManager._Target.x * 200, 0f, inputManager._Target.y * 200), 150 * Time.deltaTime));
        }
        else
        {
            isPlayerIdle = true;
            isPlayerRun = false;
        }
    }
}
