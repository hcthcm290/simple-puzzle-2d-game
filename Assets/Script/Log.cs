using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    Animator animator;
    private Transform target;
    public float chasingRadius;
    public float atkRadius;
    private Vector3 homePosition;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        homePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null && ContinueChasing() && animator.GetBool("Chasing"))
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            Vector3 targetPosition = transform.position + Vector3.Normalize(target.position - transform.position) * (distanceToTarget - atkRadius);
            Debug.Log(targetPosition);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else if (target == null && transform.position != homePosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, homePosition, speed * Time.deltaTime);
        }
        UpdateAnimation();

    }

    void UpdateAnimation()
    {
        if (target != null && ContinueChasing())
        {
            animator.SetBool("Moving", true);
            animator.SetFloat("MoveX", target.position.x - transform.position.x);
            animator.SetFloat("MoveY", target.position.y - transform.position.y);
        }
        else if (target == null && transform.position != homePosition)
        {
            animator.SetBool("Moving", true);
            animator.SetFloat("MoveX", homePosition.x - transform.position.x);
            animator.SetFloat("MoveY", homePosition.y - transform.position.y);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    override protected void TakenDamage(int dmg)
    {
        health -= dmg;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(!animator.GetBool("WakeUp"))
            {
                animator.SetBool("WakeUp", true);
            }

            target = other.gameObject.transform;
        }
    }

    bool ContinueChasing()
    {
        if(Vector3.Distance(transform.position, homePosition) > chasingRadius)
        {
            target = null;
            return false;
        }
        return true;
    }

    void StartChasing()
    {
        animator.SetBool("Chasing", true);
    }
}
