using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features
{
    ///// <summary>
    ///// PlayerController - Developed by Duong Nhat Khoa on 2025/08/26. <br/>
    ///// Handles player controls and interactions.
    ///// </summary>
    //public class PlayerController : MonoBehaviour
    //{
    //    #region --- Methods ---

    //    void FixedUpdate()
    //    {
    //        _isGrounded = CheckGrounded();
            
    //        _horizontalInput = Input.GetAxisRaw("Horizontal");
    //        _verticalInput = Input.GetAxisRaw("Vertical");

    //        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
    //        {
    //            Debug.Log($"Jump + {_isGrounded}");
    //            _isJumping = true;
    //            _rgb.AddForce(_jumpForce * Vector2.up);
    //        }

    //        if (Mathf.Abs(_horizontalInput) > 0.1f)
    //        {
    //            Debug.Log($"Run + {_isGrounded}");
    //            _rgb.velocity = new Vector2(_horizontalInput * Time.fixedDeltaTime * speed, _rgb.velocity.y);

    //            transform.rotation = Quaternion.Euler(new Vector3(0, _horizontalInput > 0 ? 0 : 180, 0));
    //        }
    //        else if (_isGrounded)
    //        {
    //            Debug.Log($"Idle + {_isGrounded}");
    //            _rgb.velocity = Vector2.zero;
    //        }
    //    }

    //    private bool CheckGrounded()
    //    {
    //        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f, Color.red);
    //        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, _groundLayer);

    //        return hit.collider != null;
    //    }

    //    #endregion

    //    #region --- Fields ---

    //    [SerializeField] private Rigidbody2D _rgb;
    //    [SerializeField] private LayerMask _groundLayer;
    //    [SerializeField] private float speed;
    //    [SerializeField] private float _jumpForce;

    //    private bool _isGrounded;
    //    private bool _isJumping;
    //    private bool _isAttacking;

    //    private float _horizontalInput;
    //    private float _verticalInput;

    //    #endregion
    //}

    /// <summary>
    /// PlayerController - Controller and manage state.<br/>
    /// Developer: Dương Nhật Khoa, created on: 27/08/2025.
    /// </summary>
    public class PlayerController : MonoBehaviour, IStateController<BaseState<PlayerController, PlayerStateFactory>>
    {
        #region --- Unity Methods ---

        public void Start()
        {
            stateFactory = new PlayerStateFactory(this, playerData);

            currentState = stateFactory.GroundState();
            currentState.EnterState();
        }

        public void Update()
        {
            GetMove();
            GetJump();
            Attack();
            Throw();

            currentState?.UpdateChainStates();
        }

        public void FixedUpdate()
        {
            currentState?.PhysicsUpdate();
            //CheckGround();
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
