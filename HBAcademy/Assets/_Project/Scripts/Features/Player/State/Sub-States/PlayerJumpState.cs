using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SubState
{
    public class PlayerJumpState : BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerJumpState(PlayerController ctrl, PlayerStateFactory fac, ScriptableObject data) : base(ctrl, fac, data) { }

        public override void EnterState()
        {
            Debug.Log("Jump");
            base.EnterState();

            Ctrl.inputHandler.UseJumpInput();
            Ctrl.anim.SetTrigger("Jump");
            Ctrl.rg2D.velocity = new Vector2(Ctrl.rg2D.velocity.x, Ctrl.playerData.jumpForce);
        }

        public override void ExitState()
        {
            base.ExitState();

            //throw new System.NotImplementedException();
        }

        protected override void CheckSwitchState()
        {
            //throw new System.NotImplementedException();
        }

        protected override void UpdateState()
        {
            if (Ctrl.rg2D.velocity.y < 0)
            {
                Ctrl.anim.SetFloat("velY", Ctrl.rg2D.velocity.y);
                SwitchState(Fac.FallState());
            }

            if (Ctrl.inputHandler.NormalizedInputX != 0)
                SwitchState(Fac.RunState());
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}