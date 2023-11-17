using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CloneAI : MonoBehaviour
{
    public DetectionController detectionArea;
    public Transform target;

    private float magnitude = 0;
    public float speed = 200f;
    public float nextWaypointUpdate = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Animação
    SpriteRenderer spriteRenderer;
    public Animator animator;
    public float idleHorizontal = 0;
    public float idleVertical = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 1f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone() && target!=null)
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Flip();
        if (detectionArea.detectedObjs.Count > 0)
        {
            
            target = detectionArea.detectedObjs[0].transform;

            if (path==null) { return; }

            if(currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath=true;
                return;
            }
            else
            {
                reachedEndOfPath=false;
            }

            magnitude = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).sqrMagnitude;

            if (magnitude >= 8f)
            {
                Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position);
                Vector2 force = direction.normalized * speed * Time.deltaTime;

                rb.AddForce(force);

                // Animator
                animator.SetFloat("Horizontal", direction.x);
                animator.SetFloat("Vertical", direction.y);
                animator.SetBool("isRunning", true);
                SetIdle(direction);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointUpdate)
            {
                currentWaypoint++;
            }

        }
        else
        {
            target = null;
        }

        animator.SetFloat("IdleHorizontal", idleHorizontal);
        animator.SetFloat("IdleVertical", idleVertical);
    }

    public void SetIdle(Vector2 movement)
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
    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Flip()
    {
        if (rb.velocity.x >= 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if (rb.velocity.x <= -0.01f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
