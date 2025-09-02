using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Features.Enemy;

public class Kunai : MonoBehaviour
{
    public Rigidbody2D rg;
    public GameObject hitVFX;

    void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        rg.velocity = transform.right * 20f;
        Invoke(nameof(OnDespawn), 3f);
    }

    public void OnDespawn()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyController>().TakeDamage(20f);
            Instantiate(hitVFX, transform.position, transform.rotation);
            OnDespawn();
        }
    }
}
