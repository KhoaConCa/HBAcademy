using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Features.Enemy;
using Vox.Features.Player;

public class AttackArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyController>().TakeDamage(20f);
        }
        else if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().TakeDamage(20f);
        }
    }
}
