using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    InputManager inputManager;
    AnimationController animationController;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = this.GetComponent<InputManager>();
        animationController = GameObject.FindGameObjectWithTag("AnimationController").GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputManager.isTouchPress == true)
        {
            animationController.PlayerRunAnimation();
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(inputManager._Target.x * 200, 0f, inputManager._Target.y * 200), 0.01f * Time.deltaTime);
            this.transform.rotation = Quaternion.LookRotation(Vector3.Lerp(this.transform.position, new Vector3(inputManager._Target.x * 200, 0f, inputManager._Target.y * 200), 400 * Time.deltaTime));
        }
        else
        {
            animationController.PlayerIdleAnimation();
        }
    }
}
