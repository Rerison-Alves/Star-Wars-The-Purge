using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    // Movimentação
    public float speed = 5f, initialSpeed = 5f;
    public Rigidbody2D rb;
    
    private Vector2 movement;
    private Vector2 fixedMove;
    private bool walking = false;

    // Animação
    private SpriteRenderer sprite;
    public Animator animator;
    private float idleHorizontal = 0;
    private float idleVertical = 0;
    

    // Attack
    public float delayAttack = 0.3f;
    public bool attackblock;
    public GameObject hitBoxes;

    // Dash
    public AudioSource whoosh;
    public float activeMoveSpeed;
    public float dashspeed;
    private float dashLenght = .3f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    // Som
    public AudioSource sabreSwing;
    public AudioSource walkingSound;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator=GetComponent<Animator>();

        activeMoveSpeed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        
        // input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        fixedMove = new Vector2 (movement.x, movement.y).normalized;
        rb.velocity = fixedMove * activeMoveSpeed;

        // Animator
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        Flip(movement.x);

        SetIdle();
        animator.SetFloat("IdleHorizontal", idleHorizontal);
        animator.SetFloat("IdleVertical", idleVertical);

        Attack();
        Dash();

        setWalkingSound();
    }

    void FixedUpdate()
    {
        //movimentação
        //rb.MovePosition(rb.position + fixedMove * speed * Time.fixedDeltaTime);
    }


    public void Flip(float horizontal)
    {
        if (horizontal>=0 && idleHorizontal>=0)
        {
            sprite.flipX = false;
            hitBoxes.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            sprite.flipX= true;
            hitBoxes.transform.localScale = new Vector3(-1, 1, 1);
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
            Vector2 diferenca = getMouseDifference();
            idleHorizontal = diferenca.x;
            idleVertical = diferenca.y;
            if (attackblock) return;
            sabreSwing.Play();
            animator.SetTrigger("Attack");
            attackblock = true;
            speed = 0;
            activeMoveSpeed = 0;
            StartCoroutine(DelayStop(delayAttack));
        }
    }

    public IEnumerator DelayStop(float delay)
    {
        yield return new WaitForSeconds(delay);
        attackblock = false;
        speed = initialSpeed;
        activeMoveSpeed = initialSpeed;
    }

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && activeMoveSpeed!=0)
        {
            if (dashCoolCounter<=0 && dashCounter<=0)
            {
                activeMoveSpeed = dashspeed;
                dashCounter = dashLenght;
                whoosh.Play();
            }
        }

        if(dashCounter>0)
        {
            dashCounter  -= Time.deltaTime;

            if (dashCounter<=0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter>0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    private Vector2 getMouseDifference()
    {
        Vector3 posicaoObjeto = transform.position;

        // Obter a posição do mouse em coordenadas de mundo
        Vector3 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcular a diferença entre a posição do objeto e a posição do mouse
        Vector2 diferenca = new Vector2(posicaoMouse.x - posicaoObjeto.x, posicaoMouse.y - posicaoObjeto.y).normalized;

        diferenca.x = (float)Math.Round(diferenca.x);
        diferenca.y = (float)Math.Round(diferenca.y);

        return diferenca;
    }

    private void setWalkingSound()
    {
        if (!walking && movement.sqrMagnitude != 0 && speed != 0)
        {
            walking = true;
            walkingSound.Play();
        }

        if (walking && movement.sqrMagnitude == 0)
        {
            walking = false;
            walkingSound.Stop();
        }
    }
}
