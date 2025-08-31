using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vox.Ultilities.StateMachine
{
    public interface IStateController<TState>
    {
        public TState CurrentState { get; set; }
        public Animator Anim { get; }
    }
}
