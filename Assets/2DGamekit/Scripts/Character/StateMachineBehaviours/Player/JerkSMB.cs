using Gamekit2D;
using UnityEngine;

public class JerkSMB : SceneLinkedSMB<PlayerCharacter>
{
    public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnSLStateEnter(animator, stateInfo, layerIndex);
        m_MonoBehaviour.EnableMeleeAttack();
        m_MonoBehaviour.SetVerticalMovement(0);
    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.UpdateFacing();
        m_MonoBehaviour.UpdateJump();
        m_MonoBehaviour.AirborneVerticalMovement();
        m_MonoBehaviour.CheckForGrounded();
        m_MonoBehaviour.IncrementVerticalMovement(m_MonoBehaviour.JerkSettings.UpForce);
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnSLStateExit(animator, stateInfo, layerIndex);
        m_MonoBehaviour.SetHorizontalMovement(0);
        m_MonoBehaviour.DisableMeleeAttack();
        animator.SetBool("Jerk", false);
    }
}

