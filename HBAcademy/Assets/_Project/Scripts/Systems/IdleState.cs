using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Ultilities.StateMachine;

public class IdleState : BaseState<PlayerController.PlayerState>
{
    public IdleState(PlayerController.PlayerState key) : base(key) { }

    public override void EnterState()
    {
        Debug.Log("Enter Idle State");
    }

    public override void UpdateState()
    {
        // Idle logic
    }

    public override void ExitState()
    {
        Debug.Log("Exit Idle State");
    }

    public override PlayerController.PlayerState GetNextState()
    {
        // Ví dụ: nếu bấm phím mũi tên thì sang Walk
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            return PlayerController.PlayerState.Walk;

        return StateKey; // Giữ nguyên Idle
    }

    public override void OnTriggerEnter(Collider other) { }
    public override void OnTriggerExit(Collider other) { }
    public override void OnTriggerStay(Collider other) { }
}

