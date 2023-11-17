using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class CloneAim : MonoBehaviour
{
    //Mecânica de mirar
    private Transform aimTransform;
    private Animator aimAnimator;
    private SpriteRenderer spriteArma;

    //Area de detecção do player
    public DetectionController detectionArea;

    //Mecânica de atirar
    private Transform firePoint;
    public GameObject laserPrefab;
    public float laserBulletForce = 20f;
    private float delay = 0;

    // Sonorizção
    public AudioSource audiosource;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        firePoint = aimTransform.Find("FirePoint");
        aimAnimator = aimTransform.Find("effect").GetComponent<Animator>();
        spriteArma = aimTransform.Find("arma_2").GetComponent<SpriteRenderer>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectionArea.detectedObjs.Count > 0)
        {
            Vector3 playerPosition = detectionArea.detectedObjs[0].transform.position;

            HandleAim(playerPosition);
            HandleShooting(playerPosition);
        }
    }

    private void HandleAim(Vector3 playerPosition)
    {
        Vector3 aimDirection = (playerPosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Flip(angle);
    }

    private void HandleShooting(Vector3 playerPosition)
    {
        delay += Time.deltaTime;
        if (delay >2)
        {
            delay = 0;
            aimAnimator.SetTrigger("Shoot");
            GameObject laserBullet = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rbLaser = laserBullet.GetComponent<Rigidbody2D>();
            rbLaser.AddForce(firePoint.up * laserBulletForce, ForceMode2D.Impulse);
            audiosource.Play();
        }
    }

    public void Flip(float angle)
    {
        if(angle > 90 || angle < (-90))
        {
            spriteArma.flipY = true;
        }
        else
        {
            spriteArma.flipY = false;
        }
    }
}
