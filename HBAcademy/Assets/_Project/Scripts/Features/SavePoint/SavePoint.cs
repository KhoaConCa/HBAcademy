using UnityEngine;
using Vox.Features.Player;

namespace Vox.Features.SavePoint
{
    /// <summary>
    /// SavePoint - Save point in the game.<br/>
    /// Developer: Duong Nhat Khoa - created on: 01/09/2025.
    /// </summary>
    public class SavePoint : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<PlayerController>().SavePoint();
            }
        }
    }
}
