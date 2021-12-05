using Gamekit2D;
using System.Threading.Tasks;
using UnityEngine;


public class JerkSMB : SceneLinkedSMB<PlayerCharacter>
{
    private float _remainingTime = 0;

    public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _currentUpdate = 0;
        base.OnSLStateEnter(animator, stateInfo, layerIndex);
        m_MonoBehaviour.EnableMeleeAttack();
        m_MonoBehaviour.SetVerticalMovement(0);
        m_MonoBehaviour.meleeDamager.OnDamageableHit.AddListener(OnDamageableHit);
    }

    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnSLStatePostEnter(animator, stateInfo, layerIndex);
    }


    private int _currentUpdate = 0;
    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (m_MonoBehaviour.JerkSettings.Upgraded)
        {
            m_MonoBehaviour.TryBreakJerk();
            int directionMultiplier = m_MonoBehaviour.IsLookToRight ? 1 : -1;
            m_MonoBehaviour.SetHorizontalMovement(m_MonoBehaviour.JerkSettings.ForwardSpeed * directionMultiplier);
        }
        m_MonoBehaviour.UpdateFacing();
        m_MonoBehaviour.UpdateJump();
        m_MonoBehaviour.AirborneVerticalMovement();
        m_MonoBehaviour.CheckForGrounded();
        if (_remainingTime > 0)
            m_MonoBehaviour.SetVerticalMovement(-m_MonoBehaviour.JerkSettings.DownSpeed + m_MonoBehaviour.JerkSettings.ExtraUpForceOnHit);
        else
            m_MonoBehaviour.SetVerticalMovement(-m_MonoBehaviour.JerkSettings.DownSpeed);
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnSLStateExit(animator, stateInfo, layerIndex);
        m_MonoBehaviour.SetHorizontalMovement(0);
        m_MonoBehaviour.DisableMeleeAttack();
        animator.SetBool("Jerk", false);
        m_MonoBehaviour.meleeDamager.OnDamageableHit.RemoveListener(OnDamageableHit);
    }

    private async void OnDamageableHit(Damager damager, Damageable damagable)
    {
        _remainingTime =  m_MonoBehaviour.JerkSettings.DurationExtraUpForce;
        do
        {
            _remainingTime -= Time.deltaTime;
            await Task.Delay(1);
        }
        while (_remainingTime > 0);
    }
}

