using System;
using UnityEngine;
using Vox.Features.Player.Data;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.Player
{
    /// <summary>
    /// PlayerController - Controller and manage state.<br/>
    /// Developer: Dương Nhật Khoa - created on: 27/08/2025.
    /// </summary>
    public class PlayerController : MonoBehaviour, IStateController<BaseState<PlayerController, PlayerStateFactory>>
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

        public void OnInit()
        {
            isDead = false;

            transform.position = _savePoint;

            stateFactory = new PlayerStateFactory(this, playerData);

            currentState = stateFactory.IdleState();
            currentState.EnterState();
        }

        public void AnimationTrigger() => currentState.AnimationTrigger();

        public void AnimationFinishTrigger() => currentState.AnimationFinishTrigger();

        public void SavePoint()
        {
            _savePoint = transform.position;
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
