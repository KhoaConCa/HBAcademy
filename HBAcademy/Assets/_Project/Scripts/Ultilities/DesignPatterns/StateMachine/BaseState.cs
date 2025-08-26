using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vox.Ultilities.StateMachine
{
    /// <summary>
    /// BaseState - Developed by Duong Nhat Khoa on 2025/08/26. <br/>
    /// A base class for defining states in a state machine.
    /// </summary>
    /// <typeparam name="EState"> Object Enum. </typeparam>
    public abstract class BaseState<EState> where EState : Enum
    {
        #region --- Constructors ---

        public BaseState(EState key, Animator animator)
        {
            StateKey = key;
            this.animator = animator;
        }

        #endregion

        #region --- Methods ---

        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void ExitState();
        public abstract EState GetNextState();
        public abstract void OnTriggerEnter(Collider other);
        public abstract void OnTriggerExit(Collider other);
        public abstract void OnTriggerStay(Collider other);

        #endregion

        #region --- Properties ---

        public EState StateKey { get; private set; }

        protected Animator animator;

        #endregion
    }

    /// <summary>
    /// BaseState - là một lớp trừu tượng đại diện cho một trạng thái trong hệ thống máy trạng thái (HSM - Hierarchical State Machine).
    /// </summary>
    /// <typeparam name="C"> là một kiểu Generic tượng trưng cho Controller. </typeparam>
    /// <typeparam name="F"> là một kiểu Generic tượng trưng cho Factory. </typeparam>
    public abstract class BaseState<C, F> where C : IStateController<BaseState<C, F>>
    {
        /// <summary>
        /// Định nghĩa một trạng thái cơ sở trong hệ thống máy trạng thái (HSM).
        /// </summary>
        /// <param name="ctrl"> là một biến Controller. </param>
        /// <param name="fac"> là một biến Factory. </param>
        public BaseState(C ctrl, F fac)
        {
            _controller = ctrl;
            _factory = fac;

            SetSuperState(this);
        }
        #region --- Methods ---

        /// <summary>
        /// Định nghĩa khởi tạo trạng thái con (sub-state) nếu có.
        /// </summary>
        protected virtual void InitializeSubState() { }

        /// <summary>
        /// Thực hiện các hành động khi trạng thái được kích hoạt.
        /// </summary>
        public abstract void EnterState();

        /// <summary>
        /// Thực hiện cập nhật trạng thái hiện tại.
        /// </summary>
        protected abstract void UpdateState();

        /// <summary>
        /// Thực hiện các hành động khi trạng thái kết thúc.
        /// </summary>
        public abstract void ExitState();

        /// <summary>
        /// Kiểm tra điều kiện để chuyển đổi trạng thái.
        /// </summary>
        protected abstract void CheckSwitchState();

        /// <summary>
        /// Thực hiện cập nhật và kiểm tra điều kiện trạng thái cha và các trạng thái con (sub-state) nếu có.
        /// </summary>
        public void UpdateChainStates()
        {
            UpdateState();
            if (_currentSubState != null) // Nếu có trạng thái con, gọi hàm UpdateChainStates() của trạng thái con. tạo mối quan hệ cha -> con -> con-con....
                _currentSubState.UpdateChainStates();

            CheckSwitchState();
        }

        /// <summary>
        /// Chuyển đổi sang trạng thái mới.
        /// </summary>
        /// <param name="newState"> là một trạng thái mới. </param>
        protected void SwitchState(BaseState<C, F> newState)
        {
            ExitState();

            if (_isRootState) // Nếu là trạng thái cha, cập nhật trạng thái hiện tại của controller.
                _controller.CurrentState = newState;
            else if (_currentSuperState != null) // Nếu không phải là trạng thái cha, cập nhật trạng thái con hiện tại của trạng thái cha.
                _currentSuperState.SetSubState(newState);
        }

        /// <summary>
        /// Đặt trạng thái cha (super-state) cho trạng thái hiện tại.
        /// </summary>
        /// <param name="newSuperState"> là một trạng thái cha. </param>
        protected void SetSuperState(BaseState<C, F> newSuperState)
        {
            _currentSuperState = newSuperState;
        }

        /// <summary>
        /// Đặt trạng thái con (sub-state) cho trạng thái hiện tại.
        /// </summary>
        /// <param name="newSubState"> là một trạng thái con. </param>
        protected void SetSubState(BaseState<C, F> newSubState)
        {
            _currentSubState = newSubState;
            _currentSubState.SetSuperState(this); // Đặt trạng thái cha cho trạng thái con.
        }

        #endregion

        #region --- Properties ---

        protected bool IsRootState { set { _isRootState = value; } }
        protected C Ctrl => _controller;
        protected F Fac => _factory;

        protected BaseState<C, F> CurrentSubState => _currentSubState;

        #endregion

        #region --- Fields ---

        private bool _isRootState = false;

        private C _controller;
        private F _factory;

        private BaseState<C, F> _currentSuperState;
        private BaseState<C, F> _currentSubState;

        #endregion
    }
}
