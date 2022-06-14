using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private GameObject _Player;

    CollectedObjManager collectedObjManager;
    PlayerMovementController playerMovementController;

    [SerializeField] Animator _playerAnimator;

    public void SetPlayerAnimation()
    {
        if(playerMovementController.isPlayerIdle == true && collectedObjManager.getCollectedObjectsCount() == 0)
        {
            PlayerIdleAnimation();
        }
        else if(playerMovementController.isPlayerIdle == true && collectedObjManager.getCollectedObjectsCount() != 0)
        {
            PlayerCarryIdleAnimation();
        }
        if(playerMovementController.isPlayerRun == true && collectedObjManager.getCollectedObjectsCount() == 0)
        {
            PlayerWalkAnimation();
        }
        else if(playerMovementController.isPlayerRun == true && collectedObjManager.getCollectedObjectsCount() != 0)
        {
            PlayerCarryRunAnimation();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");

        playerMovementController = _Player.GetComponent<PlayerMovementController>();
        collectedObjManager = _Player.GetComponent<CollectedObjManager>();
        //InvokeRepeating("SetPlayerAnimation", 0.01f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerAnimation();
        //PlayerCarryIdleAnimation();
    }

    public void PlayerIdleAnimation()
    {
        _playerAnimator.SetBool("isPlayerRun", false);
        _playerAnimator.SetBool("isPlayerIdle", true);
        _playerAnimator.SetBool("isPlayerCarry", false);
    }

    public void PlayerWalkAnimation()
    {
        _playerAnimator.SetBool("isPlayerRun", true);
        _playerAnimator.SetBool("isPlayerCarry", false);
    }
    public void PlayerCarryIdleAnimation()
    {
        _playerAnimator.SetBool("isPlayerIdle", true);
        _playerAnimator.SetBool("isPlayerCarry", true);
        _playerAnimator.SetBool("isPlayerRun", false);
    }
    public void PlayerCarryRunAnimation()
    {
        _playerAnimator.SetBool("isPlayerRun", true);
        _playerAnimator.SetBool("isPlayerCarry", true);
    }




}
