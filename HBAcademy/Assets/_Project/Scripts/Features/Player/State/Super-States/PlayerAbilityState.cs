using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SuperState
{
    public class PlayerAbilityState : BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerAbilityState(PlayerController ctrl, PlayerStateFactory stateFac, PlayerData data, string animTrigger) 
            : base(ctrl, stateFac, data, animTrigger) { }

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Ability");

            CheckConditions();
            Ctrl.anim.SetBool("isGrounded", _isGrounded);

            _isAbilityDone = false;
        }

        public override void ExitState()
        {
            base.ExitState();

            //if (CurrentSubState != null)
            //    CurrentSubState.ExitState();
            Ctrl.anim.SetBool("isGrounded", _isGrounded);
        }

        protected override void CheckSwitchState()
        {
            Debug.Log("Check Switch Ability");
            if (_isAbilityDone)
            {
                if (_isGrounded && Ctrl.rg2D.velocity.y < 0.01f)
                    SwitchState(Fac.IdleState());
                else
                {
                    SwitchState(Fac.AirState());
                }
            }

        }

        protected override void UpdateState()
        {
            Debug.Log("Update Ability");
            //if (_isAbilityDone)
            //{
            //    if (_isGrounded && Ctrl.rg2D.velocity.y < 0.01f)
            //        SwitchState(Fac.IdleState());
            //    else
            //        SwitchState(Fac.AirState());
            //}
        }

        protected override void CheckConditions()
        {
            _isGrounded = Ctrl.col2D.Cast(Vector2.down, Ctrl.contactFilter2D, new RaycastHit2D[5], 0.05f) > 0;
            //Debug.Log("IsGrounded: " + _isGrounded);
            Ctrl.anim.SetBool("isGrounded", _isGrounded);
        }

        protected bool _isAbilityDone;

        protected bool _isGrounded;
    }
}
