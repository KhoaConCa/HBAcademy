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

        public BaseState(EState key)
        {
            StateKey = key;
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

        #endregion
    }
}
