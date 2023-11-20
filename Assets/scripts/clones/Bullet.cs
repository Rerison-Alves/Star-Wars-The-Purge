using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile" || collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
            return;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth.health > 0)
                playerHealth.Damage(damage);
        }
        Destroy(gameObject);
    }
}
