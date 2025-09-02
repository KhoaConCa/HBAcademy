using System;
using Unity.VisualScripting;
using UnityEngine;
using Vox.Features.Character;
using Vox.Features.Player;
using Vox.Ultilities.StateMachine.HB;

namespace Vox.Features.Enemy
{
    /// <summary>
    /// EnemyController - Controller and manage state.<br/>
    /// Developer: Duong Nhat Khoa - created on: 01/09/2025.
    /// </summary>
    public class EnemyController : MonoBehaviour, ICharacter, IMovement, IAttackable, IDamageable
    {
        #region --- Unity Methods ---

        private void Start()
        {
            OnInit();
        }

        void Update()
        {
            if (_currentState != null && !IsDead)
            {
                _currentState.OnExecute(this);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "EnemyWall")
                ChangeDiraction(!_isRight);
        }

        #endregion

        #region --- Methods ---

        #region -- ICharacter --
        public void OnInit()
        {
            _health = 100;
            healthBar.OnInit(100, transform);

            DeactiveAttack();

            ChangeState(new EnemyIdleState());
        }

        public void OnDespawn()
        {
            Destroy(healthBar);
            Destroy(gameObject);
        }
        #endregion

        #region -- IMovement --
        public void Move()
        {
            ChangeAnimation("Run");
            _rg2D.velocity = transform.right * _moveSpeed;
        }
        #endregion

        #region -- IAttackable --
        public void Attack()
        {
            ActiveAttack();
            ChangeAnimation("Attack");
        }
        #endregion

        public void ChangeState(IEnemyState newState)
        {
            if (_currentState != null)
            {
                _currentState.OnExit(this);
            }

            _currentState = newState;

            if (_currentState != null)
            {
                _currentState.OnEnter(this);
            }
        }

        public void StopMove()
        {
            ChangeAnimation("Idle");
            _rg2D.velocity = Vector2.zero;
        }

        public bool IsTargetInRange()
        {
            if (_target != null && Vector2.Distance(_target.transform.position, transform.position) <= _attackRange)
            {
                return true;
            }
            else
                return false;
        }

        private void ChangeAnimation(string newAnimation)
        {
            if (_currentAnimation != newAnimation)
            {
                _animator.ResetTrigger(newAnimation);
                _currentAnimation = newAnimation;
                _animator.SetTrigger(newAnimation);
            }
        }

        public void ChangeDiraction(bool isRight)
        {
            this._isRight = isRight;

            transform.rotation = isRight ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.up * 180);
        }

        internal void SetTarget(PlayerController getComponent)
        {
            this._target = getComponent;

            if (IsTargetInRange())
            {
                ChangeState(new EnemyAttackState());
            }
            else if (Target != null)
            {
                ChangeState(new EnemyPatrolState());
            }
            else
                ChangeState(new EnemyIdleState());
        }

        public void TakeDamage(float damage)
        {
            if (!IsDead)
            {
                _health -= damage;

                if (IsDead)
                {
                    _health = 0;
                    Die();
                }

                healthBar.SetNewHP(_health);
                Instantiate(attackText, transform.position + Vector3.up, Quaternion.identity).OnInit(damage);
            }
        }

        public void Die()
        {
            ChangeState(null);
            ChangeAnimation("Die");
            Invoke(nameof(OnDespawn), 1f);
        }

        public void ActiveAttack()
        {
            attackArea.SetActive(true);
        }

        public void DeactiveAttack()
        {
            attackArea.SetActive(false);
        }

        #endregion

        #region --- Properties ---

        public PlayerController Target => _target;

        #endregion

        #region --- Fields ---

        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _attackRange;
        [SerializeField] private Rigidbody2D _rg2D;
        [SerializeField] private Animator _animator;
        [SerializeField] public GameObject attackArea;
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private CombatText attackText;

        private IEnemyState _currentState;
        private PlayerController _target;
        private string _currentAnimation;
        private float _health;
        private bool _isRight = true;
        
        public bool IsDead => _health <= 0;

        #endregion
    }
}