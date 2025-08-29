using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SubState
{
    public class PlayerFallState : BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerFallState(PlayerController ctrl, PlayerStateFactory fac, ScriptableObject data) : base(ctrl, fac, data)
        {
        }

        public override void EnterState()
        {
            Debug.Log("Fall");
            base.EnterState();

            Ctrl.anim.SetBool("isFall", true);
        }

        public override void ExitState()
        {
            Ctrl.anim.SetBool("isFall", false);
            Ctrl.anim.SetFloat("velY", 0);
        }

        protected override void CheckSwitchState()
        {
            if (!isExitingState)
            {
                if (Ctrl.inputHandler.NormalizedInputX != 0)
                {
                    SwitchState(Fac.RunState());
                }
                else if (Ctrl.Grounded && Ctrl.rg2D.velocity.y < 0.01f)
                {
                    SwitchState(Fac.IdleState());
                }
            }
        }

        protected override void UpdateState()
        {
            Ctrl.anim.SetFloat("velY", Ctrl.rg2D.velocity.y);
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