using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vox.Ultilities.StateMachine
{
    /// <summary>
    /// StateController - Developed by Duong Nhat Khoa on 2025/08/26. <br/>
    /// Base class for a state controller that manages different states of object.
    /// </summary>
    /// <typeparam name="EState"> Object Enum. </typeparam>
    public abstract class StateController<EState> : MonoBehaviour where EState : Enum
    {
        #region --- Methods ---

        void Start()
        {
            _currentState.EnterState();
        }

        void Update()
        {
            EState nextStateKey = _currentState.GetNextState();

            if (!_isTransistioning && !nextStateKey.Equals(_currentState.StateKey))
            {
                _currentState.UpdateState();
            } 
            else if (!_isTransistioning)
            {
                TransitionToNewState(nextStateKey);
            }
        }

        public void TransitionToNewState(EState stateKey)
        {
            _isTransistioning = true;
            _currentState.ExitState();
            _currentState = _states[stateKey];
            _currentState.EnterState();
            _isTransistioning = false;
        }

        void OnTriggerEnter(Collider other)
        {
            _currentState.OnTriggerEnter(other);
        }

        void OnTriggerExit(Collider other)
        {
            _currentState.OnTriggerExit(other);
        }

        void OnTriggerStay(Collider other)
        {
            _currentState.OnTriggerStay(other);
        }

        #endregion

        #region --- Fields ---

        protected Dictionary<EState, BaseState<EState>> _states = new();
        protected BaseState<EState> _currentState;

        protected bool _isTransistioning = false;

        #endregion
    }
}
