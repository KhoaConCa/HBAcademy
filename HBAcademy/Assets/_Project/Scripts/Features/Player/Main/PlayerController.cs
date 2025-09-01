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
            OnInit();
        }

        public void Update()
        {
            currentState?.UpdateChainStates();
        }

        public void FixedUpdate()
        {
            currentState?.PhysicsUpdate();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Coin")
            {
                Destroy(collision.gameObject);
                _coin++;
            }
            
            if (collision.tag == "DeathZone")
            {
                isDead = true;

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

            IsDead = false;

            transform.position = _savePoint;

            stateFactory = new PlayerStateFactory(this, playerData);

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
                    Die();
                }
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

        #endregion

        #region --- Properties ---

        public BaseState<PlayerController, PlayerStateFactory> CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        public Animator Anim => anim;

        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }

        #endregion

        #region --- Fields ---

        [SerializeField] public Kunai kunaiPrefab;
        [SerializeField] public Transform throwPoint;
        [SerializeField] public GameObject attackArea;

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
