using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPea : StateMachineBehaviour
{
    [SerializeField] 
    private GameObject projectile;
    
    private bool delayStarted = false;
    private readonly float DELAY = 0.85f;
    private float delayTimer = 0;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        delayTimer = 0;
        delayStarted = true;
    }

    
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (delayStarted)
        {
            // Start the delay timer
            delayTimer += Time.deltaTime;

            if (delayTimer >= DELAY)
            {
                Vector3 vector = animator.gameObject.transform.position;
                vector.x += 0.4f;
                vector.y += 0.45f;
                projectile.transform.position = vector;
                Object.Instantiate(projectile);
                delayStarted = false;
                delayTimer = 0;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
