using UnityEngine;

namespace Vox.Features.Player.Data
{
    /// <summary>
    /// PlayerData - ScriptableObject to store player-related data.<br/>
    /// Developer: Duong Nhat Khoa - created on: 31/08/2025.
    /// </summary>
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Vox/Data/Player Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Movement")]
        public float moveSpeed = 350f;

        [Header("Jump")]
        public float jumpForce = 8.5f;

        [Header("In Air State")]
        public float coyoteTime = 0.2f;

        [Header("Stats")]
        public float maxHealth = 100;
    }
}
