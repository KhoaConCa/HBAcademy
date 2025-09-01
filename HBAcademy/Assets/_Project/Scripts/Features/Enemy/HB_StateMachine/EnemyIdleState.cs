using UnityEngine;
using Vox.Ultilities.StateMachine.HB;

namespace Vox.Features.Enemy
{
    /// <summary>
    /// EnemyIdleState - Represents the idle state of an enemy.<br/>
    /// Developer: Duong Nhat Khoa - created on: 01/09/2025.
    /// </summary>
    public class EnemyIdleState : IEnemyState
    {
        #region --- Methods ---
        #region -- Implements --
        public void OnEnter(EnemyController enemy)
        {
            enemy.StopMove();
            _timer = 0;
            _randomTime = Random.Range(2f, 4f);
        }

        public void OnExecute(EnemyController enemy)
        {
            _timer += Time.deltaTime;

            if (_timer > _randomTime)
            {
                enemy.ChangeState(new EnemyPatrolState());
            }
        }

        public void OnExit(EnemyController enemy)
        {
            
        }
        #endregion
        #endregion

        #region --- Fields ---

        private float _timer;
        private float _randomTime;

        #endregion
    }
}