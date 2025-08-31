using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vox.Ultilities.StateMachine
{
    public abstract class BaseState<C, F> where C : IStateController<BaseState<C, F>>
    {
        public BaseState(C ctrl, F fac, ScriptableObject data, string animTrigger)
        {
            _controller = ctrl;
            _factory = fac;
            _data = data;
            _animTriggerName = animTrigger;

            //SetSuperState(this);
        }

        #region --- Methods ---

        public virtual void EnterState()
        {
            CheckConditions();

            _controller.Anim.SetTrigger(_animTriggerName);

            startTime = Time.time;
            isAnimationFinished = false;
            isExitingState = false;
        }

        protected abstract void UpdateState();

        protected abstract void CheckSwitchState();

        public virtual void ExitState()
        {
            _controller.Anim.ResetTrigger(_animTriggerName);

            isExitingState = true;
        }

        //protected virtual void InitializeSubState() { }

        protected abstract void CheckConditions();

        public virtual void PhysicsUpdate()
        {
            CheckConditions();
        }

        public void UpdateChainStates()
        {
            UpdateState();

            //if (_currentSubState != null)
            //    _currentSubState.UpdateChainStates();

            CheckSwitchState();
        }

        protected void SwitchState(BaseState<C, F> newState)
        {
            ExitState();

            //if (_isRootState)
                _controller.CurrentState = newState;
            //else if (_currentSuperState != null)
            //    _currentSuperState.SetSubState(newState);

            newState.EnterState();
        }

        //protected void SetSuperState(BaseState<C, F> newSuperState)
        //{
        //    _currentSuperState = newSuperState;
        //}

        //protected void SetSubState(BaseState<C, F> newSubState)
        //{
        //    _currentSubState = newSubState;
        //    _currentSubState.SetSuperState(this);

        //    //newSubState.EnterState();
        //}

        public virtual void AnimationTrigger() { }
        public virtual void AnimationFinishTrigger() => isAnimationFinished = true;

        #endregion

        #region --- Properties ---

        //protected bool IsRootState { set { _isRootState = value; } }
        protected C Ctrl => _controller;
        protected F Fac => _factory;
        protected ScriptableObject Data => _data;

        //protected BaseState<C, F> CurrentSubState => _currentSubState;
        //protected BaseState<C, F> CurrentSuperState => _currentSuperState;

        #endregion

        #region --- Fields ---

        //private bool _isRootState = false;

        private C _controller;
        private F _factory;
        private ScriptableObject _data;
        private string _animTriggerName;

        //private BaseState<C, F> _currentSuperState;
        //private BaseState<C, F> _currentSubState;

        protected bool isExitingState;
        protected bool isAnimationFinished;
        protected float startTime;

        #endregion
    }
}
