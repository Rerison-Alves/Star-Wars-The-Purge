using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    // Movimentação
    public float velocidadeMovi = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    // Animação
    public SpriteRenderer sprite;
    public Animator animator;
    public float idleHorizontal = 0;
    public float idleVertical = 0;
    

    // Attack
    public float delay = 0.3f;
    public bool attackblock;



    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator=GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
        // input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Animator
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        Flip(movement.x);

        SetIdle();
        animator.SetFloat("IdleHorizontal", idleHorizontal);
        animator.SetFloat("IdleVertical", idleVertical);

        Attack();
    }

    void FixedUpdate()
    {
        //movimentação
        rb.MovePosition(rb.position + movement * velocidadeMovi * Time.fixedDeltaTime);
    }


    public void Flip(float horizontal)
    {
        if (horizontal>=0 && idleHorizontal>=0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX= true;
        }
    }

    public void SetIdle()
    {
        if (movement.sqrMagnitude != 0)
        {
            if (movement.x != 0)
            {
                idleHorizontal = movement.x;
                idleVertical = 0;
            }
            if (movement.y != 0)
            {
                idleVertical = movement.y;
                idleHorizontal = 0;
            }
        }
    }
    public void Attack()
    {
        if (Input.GetMouseButtonDown(0)) 
        { 
            if (attackblock) return;
            animator.SetTrigger("Attack");
            attackblock = true;
            StartCoroutine(DelayAttacked());
        }
    }

    private IEnumerator DelayAttacked()
    {
        yield return new WaitForSeconds(delay);
        attackblock = false;
    }
}
