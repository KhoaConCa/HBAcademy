using UnityEngine;
using Vox.Ultilities.StateMachine.HB;

namespace Vox.Features.Enemy
{
    /// <summary>
    /// EnemyAttackState - Represents the attack state of an enemy.<br/>
    /// Developer: Duong Nhat Khoa - created on: 01/09/2025.
    /// </summary>
    public class EnemyAttackState : IEnemyState
    {
        #region --- Methods ---
        #region -- Implements --
        public void OnEnter(EnemyController enemy)
        {
            if (enemy.Target != null)
            {
                enemy.ChangeDiraction(enemy.Target.transform.position.x > enemy.transform.position.x);

                enemy.StopMove();
                enemy.Attack();
            }

            _timer = 0;
        }

        public void OnExecute(EnemyController enemy)
        {
            _timer += Time.deltaTime;

            if (_timer >= 1.5f)
            {
                enemy.ChangeState(new EnemyPatrolState());
            }
        }

        public void OnExit(EnemyController enemy)
        {
            enemy.DeactiveAttack();
        }
        #endregion
        #endregion

        #region --- Properties ---



        #endregion

        #region --- Fields ---

        private float _timer;

        #endregion
    }
}