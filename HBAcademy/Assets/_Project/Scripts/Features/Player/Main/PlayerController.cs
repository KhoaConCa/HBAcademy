using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features
{
    /// <summary>
    /// PlayerController - Controller and manage state.<br/>
    /// Developer: Dương Nhật Khoa, created on: 27/08/2025.
    /// </summary>
    public class PlayerController : MonoBehaviour, IStateController<BaseState<PlayerController, PlayerStateFactory>>
    {
        #region --- Unity Methods ---

        void Awake()
        {
            contactFilter2D.useLayerMask = true;
            contactFilter2D.layerMask = LayerMask.GetMask("Ground");
        }
        public void Start()
        {
            stateFactory = new PlayerStateFactory(this, playerData);

            currentState = stateFactory.IdleState();
            currentState.EnterState();
        }

        public void Update()
        {
            GetMove();
            GetJump();
            Attack();
            Throw();

            //Debug.Log(currentState);
            currentState?.UpdateChainStates();
        }

        public void FixedUpdate()
        {
            currentState?.PhysicsUpdate();
            //CheckGround();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Coin")
            {
                Debug.Log("Coin collected!");
            }
        }

        #endregion

        #region --- Methods ---

        private void CheckGround()
        {
            IsGrounded = col2D.Cast(Vector2.down, contactFilter2D, new RaycastHit2D[5], 0.05f) > 0;
        }

        private void GetMove()
        {
            //float horizontalInput = Input.GetAxisRaw("Horizontal");
            //XInput = Mathf.Abs(horizontalInput) > 0.1f;

            //if (XInput)
            //    MoveDirection = Mathf.Sign(horizontalInput) > 0 ? 1 : -1;
        }

        private void GetJump()
        {
            //IsJump = Input.GetKey(KeyCode.Space);
            //JumpTriggered = Input.GetKeyDown(KeyCode.Space);
        }

        private void Attack()
        {
            //if (Input.GetKeyDown(KeyCode.C))
            //{
            //    IsAttack = true;
            //    Debug.Log($"Attack: {IsAttack}");
            //}
        }

        private void Throw()
        {
            //if (Input.GetKeyDown(KeyCode.V))
            //{
            //    IsThrow = true;
            //    Debug.Log($"Throw: {IsThrow}");
            //}
        }

        #endregion

        #region --- Properties ---

        public BaseState<PlayerController, PlayerStateFactory> CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        public Animator Anim => anim;

        public float MoveDirection { get; private set; }
        public bool IsMove { get; private set; }
        public bool JumpTriggered { get; private set; } = false;
        public bool IsJump { get; private set; }
        public bool IsGrounded { get; private set; }
        public bool IsAttack { get; set; }
        public bool IsThrow { get; set; }
        public bool AttackTriggered { get; private set; } = false;
        public bool ThrowTriggered { get; private set; } = false;

        public bool Grounded { get; set; } = true;
        public bool IsAbilityDone { get; set; }
        public bool XInput { get; set; }
        public bool YInput { get; set; }
        public bool JumpInput { get; set; }
        public void AnimationTrigger() => currentState.AnimationTrigger();
        public void AnimationFinishTrigger() => currentState.AnimationFinishTrigger();

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

        #endregion
    }
}
