using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SaberCollisor : MonoBehaviour
{
    public AudioSource saberHit;
    public AudioSource saberDeflect;

    public GameObject bulletParryed;
    public float laserBulletForce = 12f;
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            CloneHealth cloneHealth = collision.GetComponent<CloneHealth>();
            cloneHealth.Damage(damage);
        }

        if (collision.gameObject.CompareTag("Reactor"))
        {
            ReactorHealth reactorHealth = collision.GetComponent<ReactorHealth>();
            reactorHealth.Damage(damage);
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            saberDeflect.Play();
            Transform point = collision.transform;
            Destroy(collision.gameObject);
            point.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
            GameObject laserBullet = Instantiate(bulletParryed, point.position, point.rotation);
            Rigidbody2D rbLaser = laserBullet.GetComponent<Rigidbody2D>();
            rbLaser.AddForce(point.up * laserBulletForce, ForceMode2D.Impulse);
        }else
        {
            saberHit.Play();
        }
    }
}
