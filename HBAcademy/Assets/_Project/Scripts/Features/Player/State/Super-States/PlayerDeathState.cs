using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Features.Player;
using Vox.Features.Player.Data;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SuperState
{
    /// <summary>
    /// PlayerDeathState - Super-state.<br/>
    /// Developer: Duong Nhat Khoa - created on: 01/09/2025.
    /// </summary>
    public class PlayerDeathState : BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerDeathState(PlayerController ctrl, PlayerStateFactory fac, PlayerData data, string animTrigger) 
            : base(ctrl, fac, data, animTrigger) { }

        protected override void CheckConditions()
        {

        }

        protected override void CheckSwitchState()
        {

        }

        protected override void UpdateState()
        {
            
        }
    }
}