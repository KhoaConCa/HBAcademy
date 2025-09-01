using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Features.Character;
using Vox.Features.Player;


namespace Vox.Features.Enemy
{
    public class EnemySight : MonoBehaviour
    {
        #region --- Unity Methods ---

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                PlayerController character = collision.GetComponent<PlayerController>();
                if (character != null)
                {
                    enemy.SetTarget(character);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
                enemy.SetTarget(null);
        }

        #endregion

        #region --- Methods ---
        #region -- Implements --

        #endregion

        #region -- Overrides --

        #endregion
        #endregion

        #region --- Properties ---



        #endregion

        #region --- Fields ---

        public EnemyController enemy;

        #endregion
    }
}