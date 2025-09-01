using UnityEngine;

namespace Vox.Ultilities.StateMachine
{
    /// <summary>
    /// BaseState - Base class for all states.<br/>
    /// Developer: Duong Nhat Khoa - created on: 31/08/2025.
    /// </summary>
    /// <typeparam name="C"> Controller. </typeparam>
    /// <typeparam name="F"> State Factory. </typeparam>
    public abstract class BaseState<C, F> where C : IStateController<BaseState<C, F>>
    {
        #region --- Constructor ---

        public BaseState(C ctrl, F fac, ScriptableObject data, string animTrigger)
        {
            _controller = ctrl;
            _factory = fac;
            _data = data;
            _animTriggerName = animTrigger;
        }

        #endregion

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

        protected abstract void CheckConditions();

        public virtual void PhysicsUpdate()
        {
            CheckConditions();
        }

        public void UpdateChainStates()
        {
            UpdateState();

            CheckSwitchState();
        }

        protected void SwitchState(BaseState<C, F> newState)
        {
            ExitState();

            _controller.CurrentState = newState;

            newState.EnterState();
        }

        public virtual void AnimationTrigger() { }
        public virtual void AnimationFinishTrigger() => isAnimationFinished = true;

        #endregion

        #region --- Properties ---

        protected C Ctrl => _controller;
        protected F Fac => _factory;
        protected ScriptableObject Data => _data;

        #endregion

        #region --- Fields ---

        private C _controller;
        private F _factory;
        private ScriptableObject _data;
        private string _animTriggerName;

        protected bool isExitingState;
        protected bool isAnimationFinished;
        protected float startTime;

        #endregion
    }
}
