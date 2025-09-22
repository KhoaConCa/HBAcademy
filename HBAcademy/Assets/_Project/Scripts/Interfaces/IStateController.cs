using UnityEngine;

namespace Vox.Ultilities.StateMachine
{
    /// <summary>
    /// IStateController - Interface for state controllers.<br/>
    /// Developer: Duong Nhat Khoa - created on: 31/08/2025.
    /// </summary>
    /// <typeparam name="TState"> BaseState. </typeparam>
    public interface IStateController<TState>
    {
        public TState CurrentState { get; set; }
        public Animator Anim { get; }
    }
}
