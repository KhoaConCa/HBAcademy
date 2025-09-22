using System;
using UnityEngine;
using Vox.Features.Character;
using Vox.Features.Player.Data;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.Player
{
    /// <summary>
    /// PlayerController - Controller and manage state.<br/>
    /// Developer: Dương Nhật Khoa - created on: 27/08/2025.
    /// </summary>
    public class PlayerController : MonoBehaviour, IStateController<BaseState<PlayerController, PlayerStateFactory>>,
        ICharacter, IDamageable
    {
        #region --- Unity Methods ---

        void Awake()
        {
            contactFilter2D.useLayerMask = true;
            contactFilter2D.layerMask = LayerMask.GetMask("Ground");

            SavePoint();
        }

        public void Start()
        {
            _coin = PlayerPrefs.GetInt("coin", 0);
            OnInit();
        }

        public void Update()
        {
            currentState?.UpdateChainStates();
        }

        public void FixedUpdate()
        {
            if (IsDead) return;
            currentState?.PhysicsUpdate();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Coin")
            {
                Destroy(collision.gameObject);
                _coin++;
                PlayerPrefs.SetInt("coin", _coin);
                UIManager.Instance.SetCoin(_coin);
            }
            
            if (collision.tag == "DeathZone")
            {
                playerData.maxHealth = 0;
                Invoke(nameof(OnInit), 1f);
            }
        }

        #endregion

        #region --- Methods ---

        #region -- ICharacter --
        public void OnInit()
        {
            DeactiveAttack();

            playerData.maxHealth = 100;
            healthBar.OnInit(100, transform);

            isDead = false;

            transform.position = _savePoint;

            stateFactory = new PlayerStateFactory(this, playerData);
            UIManager.Instance.SetCoin(_coin);

            currentState = stateFactory.IdleState();
            currentState.EnterState();
        }

        public void OnDespawn()
        {
            OnInit();
        }
        #endregion

        #region -- IDamageable --
        public void TakeDamage(float damage)
        {
            if (!isDead)
            {
                playerData.maxHealth -= damage;

                if (playerData.maxHealth <= 0)
                    isDead = true;

                if (isDead)
                {
                    playerData.maxHealth = 0;
                    Die();
                }

                healthBar.SetNewHP(playerData.maxHealth);
                Instantiate(conbatTextPrefab, transform.position + Vector3.up, Quaternion.identity).OnInit(damage);
            }
        }

        public void Die()
        {
            Invoke(nameof(OnDespawn), 1f);
        }
        #endregion

        public void AnimationTrigger() => currentState.AnimationTrigger();

        public void AnimationFinishTrigger() => currentState.AnimationFinishTrigger();

        public void SavePoint()
        {
            _savePoint = transform.position;
        }

        public void ActiveAttack()
        {
            attackArea.SetActive(true);
        }

        public void DeactiveAttack()
        {
            attackArea.SetActive(false);
        }

        public void SetMove(int xInput)
        {
            if (xInput == 1)
            {
                inputHandler.NormalizedInputX = 1;
                CurrentState = stateFactory.RunState();
                CurrentState.EnterState();
            }
            else if (xInput == -1)
            {
                inputHandler.NormalizedInputX = -1;
                CurrentState = stateFactory.RunState();
                CurrentState.EnterState();
            }
            else if (xInput == 0)
            {
                inputHandler.NormalizedInputX = 0;
                CurrentState = stateFactory.IdleState();
                CurrentState.EnterState();
            }
        }

        public void Attack()
        {
            CurrentState = stateFactory.AttackState();
            CurrentState.EnterState();
        }

        public void Jump()
        {
            CurrentState = stateFactory.JumpState();
            CurrentState.EnterState();
        }

        public void Throw()
        {
            CurrentState = stateFactory.ThrowState();
            CurrentState.EnterState();
        }

        #endregion

        #region --- Properties ---

        public BaseState<PlayerController, PlayerStateFactory> CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        public Animator Anim => anim;

        public bool IsDead => playerData.maxHealth <= 0;

        #endregion

        #region --- Fields ---

        [SerializeField] public Kunai kunaiPrefab;
        [SerializeField] public Transform throwPoint;
        [SerializeField] public GameObject attackArea;
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private CombatText conbatTextPrefab;

        public Rigidbody2D rg2D;
        public Collider2D col2D;
        public Animator anim;
        public ContactFilter2D contactFilter2D;

        public PlayerStateFactory stateFactory;
        public BaseState<PlayerController, PlayerStateFactory> currentState;
        public PlayerData playerData;
        public PlayerInputHandler inputHandler;

        private int _coin = 0;
        private Vector3 _savePoint;

        public bool isDead = false;

        #endregion
    }
}
