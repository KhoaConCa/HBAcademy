using UnityEngine;

namespace Vox.Features.Character
{
    /// <summary>
    /// ICharacter - Interface for character entities.<br/>
    /// Developer: Duong Nhat Khoa - created on: 01/09/2025.
    /// </summary>
    public interface ICharacter
    {
        void OnInit();
        void OnDespawn();
    }
}