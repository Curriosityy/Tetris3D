using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlStateBehaviour : StateMachineBehaviour
{
    float i = 0;
    float speed = 1;
    PawnControler pc;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pc = FindObjectOfType<PawnControler>();
        i = 0;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        i += Time.deltaTime;
        if (i >= speed)
        {
            pc.Pawn.GetComponent<TetrisMover>().Fall();
            i = 0;
        }

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pc.Pawn = null;
    }
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
