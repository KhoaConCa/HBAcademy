using UnityEngine;

namespace Vox.Features.Player
{
    /// <summary>
    /// PlayerAnimationEvent - Handle animation events for the player.<br/>
    /// Developer: Duong Nhat Khoa - created on: 31/08/2025.
    /// </summary>
    public class PlayerAnimationEvent : MonoBehaviour
    {
        #region --- Methods ---

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

        #endregion

        #region --- Fields ---

        [SerializeField] private PlayerController _playerController;

        #endregion
    }
}
