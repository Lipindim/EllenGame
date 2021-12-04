using Gamekit2D;
using UnityEngine;

public class JerkSMB : SceneLinkedSMB<PlayerCharacter>
{
    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.UpdateFacing();
        m_MonoBehaviour.UpdateJump();
        m_MonoBehaviour.AirborneVerticalMovement();
        m_MonoBehaviour.CheckForGrounded();
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnSLStateExit(animator, stateInfo, layerIndex);
        m_MonoBehaviour.SetHorizontalMovement(0);
    }
}

