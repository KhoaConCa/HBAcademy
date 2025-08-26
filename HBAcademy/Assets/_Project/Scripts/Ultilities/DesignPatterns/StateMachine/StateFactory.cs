using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using Vox.Features;
using Vox.Features.State;

namespace Vox.Ultilities.StateMachine
{
    /// <summary>
    /// Khởi tạo StateFactory với PlayerController.
    /// </summary>
    /// <param name="ctrl"> là một biến Controller. </param>
    public class StateFactory
    {
        /// <summary>
        /// Khởi tạo StateFactory với PlayerController.
        /// </summary>
        /// <param name="ctrl"> là một biến Controller. </param>
        public StateFactory(PlayerController ctrl)
        {
            _controller = ctrl;
        }

        #region --- Methods ---

        public BaseState<PlayerController, StateFactory> GroundSuperState() => new GroundSuperState(_controller, this);
        public BaseState<PlayerController, StateFactory> AirSuperState() => new AirSuperState(_controller, this);
        public BaseState<PlayerController, StateFactory> IdleSubState() => new IdleSubState(_controller, this);
        public BaseState<PlayerController, StateFactory> RunSubState() => new RunSubState(_controller, this);
        public BaseState<PlayerController, StateFactory> JumpSuperState() => new JumpSuperState(_controller, this);
        public BaseState<PlayerController, StateFactory> FallSubState() => new FallSubState(_controller, this);

        #endregion

        #region --- Fields ---

        private PlayerController _controller;

        #endregion

    }
}
