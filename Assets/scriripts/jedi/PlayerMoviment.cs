using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float velocidadeMovi = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //movimentação
        rb.MovePosition(rb.position + movement * velocidadeMovi * Time.fixedDeltaTime);
    }
}
