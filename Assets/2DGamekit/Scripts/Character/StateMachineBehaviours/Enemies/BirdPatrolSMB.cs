using UnityEngine;


namespace Gamekit2D
{
    public class BirdPatrolSMB : SceneLinkedSMB<EnemyBehaviour>
    {
        private float _startXPosition;
        private float _currentDirection;

        public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnSLStateEnter(animator, stateInfo, layerIndex);
            if (m_MonoBehaviour.IsLookToRight)
                _startXPosition = m_MonoBehaviour.transform.position.x;
            else
                _startXPosition = m_MonoBehaviour.transform.position.x - m_MonoBehaviour.PatrolDistance;
            _currentDirection = m_MonoBehaviour.IsLookToRight ? 1 : -1;
        }

        public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (TryChangeDirection())
            {
                m_MonoBehaviour.SetHorizontalSpeed(m_MonoBehaviour.speed * -1);
                m_MonoBehaviour.UpdateFacing();
            }
            else
            {
                m_MonoBehaviour.SetHorizontalSpeed(m_MonoBehaviour.speed * 1);
            }
        }

        private bool TryChangeDirection()
        {
            if (_currentDirection > 0)
            {
                float targetPosition = _startXPosition + _currentDirection * m_MonoBehaviour.PatrolDistance;
                if (targetPosition < m_MonoBehaviour.transform.position.x)
                {
                    _currentDirection = -1;
                    return true;
                }
            }
            else if (m_MonoBehaviour.transform.position.x < _startXPosition)
            {
                _currentDirection = 1;
                return true;
            }
            
            return false;
        }
    }
}