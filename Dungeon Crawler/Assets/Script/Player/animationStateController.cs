using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isAttackingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isAttackingHash = Animator.StringToHash("isAttacking");
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isrunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        _ = animator.GetBool(isAttackingHash);
        bool forwardPressed = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool AttackPressed = Input.GetKey(KeyCode.Mouse0);
        
        // if player presses w key
        if (!isWalking && forwardPressed)
        {
            // then set the isWalking boolean to be true
            animator.SetBool(isWalkingHash, true);
        }

        // if player is not pressing w key animator will stop moving
        if (isWalking && !forwardPressed)
        {
            //set iswalking boolean to be false
            animator.SetBool(isWalkingHash, false);
        }
           // if player is walking and presses left shift
        if (!isrunning && (forwardPressed && runPressed))
        {
            // then set the isRunning boolean to be true
            animator.SetBool(isRunningHash, true);
        }

        //if player stops running or stops walking
        if(isrunning && (!forwardPressed || !runPressed))
        {
            //then set the isRunning boolean to be false
            animator.SetBool(isRunningHash, false);
        }

        if (AttackPressed)
        {
            animator.SetBool(isAttackingHash, true);
        }

        if (!AttackPressed)
        {
            animator.SetBool(isAttackingHash, false);
        }
       
    }
}
