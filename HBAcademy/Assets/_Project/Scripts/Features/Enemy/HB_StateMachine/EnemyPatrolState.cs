using UnityEngine;
using Vox.Ultilities.StateMachine.HB;

namespace Vox.Features.Enemy
{
    /// <summary>
    /// EnemyPatrolState - Represents the patrol state of an enemy.<br/>
    /// Developer: Duong Nhat Khoa - created on: 01/09/2025.
    /// </summary>
    public class EnemyPatrolState : IEnemyState
    {
        #region --- Methods ---
        #region -- Implements --
        public void OnEnter(EnemyController enemy)
        {
            _timer = 0;
            _randomTime = Random.Range(3f, 6f);
        }

        public void OnExecute(EnemyController enemy)
        {
            _timer += Time.deltaTime;

            if (enemy.Target != null)
            {
                enemy.ChangeDiraction(enemy.Target.transform.position.x > enemy.transform.position.x);

                if (enemy.IsTargetInRange())
                {
                    enemy.ChangeState(new EnemyAttackState());
                }
                else
                {
                    enemy.Move();
                }
            }
            else
            {
                if (_timer < _randomTime)
                {
                    enemy.Move();
                }
                else
                {
                    enemy.ChangeState(new EnemyIdleState());
                }
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
