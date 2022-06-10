using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private Animator _playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerRunAnimation()
    {
        _playerAnimator.SetBool("isPlayerRun", true);
        _playerAnimator.SetBool("isPlayerIdle", false);
    }
    public void PlayerIdleAnimation()
    {
        _playerAnimator.SetBool("isPlayerRun", false);
        _playerAnimator.SetBool("isPlayerIdle", true);
    }


}
