using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParry : MonoBehaviour
{
    public int damage = 1;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            CloneHealth cloneHealth = collision.gameObject.GetComponent<CloneHealth>();
            cloneHealth.Damage(damage);
        }
        Destroy(gameObject);
    }
}
