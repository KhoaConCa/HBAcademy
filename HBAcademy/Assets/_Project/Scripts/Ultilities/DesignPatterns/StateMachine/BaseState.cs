using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vox.Ultilities.StateMachine
{
    public abstract class BaseState<C, F> where C : IStateController<BaseState<C, F>>
    {
        public BaseState(C ctrl, F fac, ScriptableObject data)
        {
            _controller = ctrl;
            _factory = fac;
            _data = data;

            SetSuperState(this);
        }

        #region --- Methods ---

        protected virtual void InitializeSubState() { }

        public virtual void PhysicsUpdate()
        {
            CheckConditions();
        }

        protected virtual void CheckConditions() { }

        public abstract void EnterState();

        protected abstract void UpdateState();

        public abstract void ExitState();

        protected abstract void CheckSwitchState();

        public void UpdateChainStates()
        {
            UpdateState();

            if (_currentSubState != null)
                _currentSubState.UpdateChainStates();

            CheckSwitchState();
        }

        protected void SwitchState(BaseState<C, F> newState)
        {
            ExitState();

            if (_isRootState)
                _controller.CurrentState = newState;
            else if (_currentSuperState != null)
                _currentSuperState.SetSubState(newState);
        }

        protected void SetSuperState(BaseState<C, F> newSuperState)
        {
            _currentSuperState = newSuperState;
        }

        protected void SetSubState(BaseState<C, F> newSubState)
        {
            _currentSubState = newSubState;
            _currentSubState.SetSuperState(this);
        }

        #endregion

        #region --- Properties ---

        protected bool IsRootState { set { _isRootState = value; } }
        protected C Ctrl => _controller;
        protected F Fac => _factory;
        protected ScriptableObject Data => _data;

        protected BaseState<C, F> CurrentSubState => _currentSubState;

        #endregion

        #region --- Fields ---

        private bool _isRootState = false;

        private C _controller;
        private F _factory;
        private ScriptableObject _data;

        private BaseState<C, F> _currentSuperState;
        private BaseState<C, F> _currentSubState;

        #endregion
    }
}
