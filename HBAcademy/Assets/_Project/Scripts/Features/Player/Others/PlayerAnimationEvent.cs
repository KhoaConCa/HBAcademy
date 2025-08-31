using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features
{
    public class PlayerAnimationEvent : MonoBehaviour
    {
        public void AnimationTrigger()
        {
            if (_playerController != null)
                _playerController.AnimationTrigger();
        }

        public void AnimationFinishTrigger()
        {
            if (_playerController != null)
                _playerController.AnimationFinishTrigger();
        }

        [SerializeField] private PlayerController _playerController;
    }
}
