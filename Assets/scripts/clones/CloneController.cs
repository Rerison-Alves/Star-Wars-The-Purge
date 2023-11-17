using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{

    //// Movimentação
    //public float speed = 3.5f, initialSpeed = 3.5f;
    //public Rigidbody2D rb;
    //Vector2 cloneDirection;
    //public float distance;

    //public DetectionController detectionArea;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    // input
    //    cloneDirection.x = Input.GetAxisRaw("Horizontal");
    //    cloneDirection.y = Input.GetAxisRaw("Vertical");
    //}

    //private void FixedUpdate()
    //{
    //    if (detectionArea.detectedObjs.Count > 0)
    //    {
    //        distance = (detectionArea.detectedObjs[0].transform.position - transform.position).sqrMagnitude;
    //        if (distance > 22)
    //        {
    //            cloneDirection = (detectionArea.detectedObjs[0].transform.position - transform.position).normalized;
    //            rb.MovePosition(rb.position + cloneDirection * speed * Time.fixedDeltaTime);
    //        }
    //    }
    //}
}
