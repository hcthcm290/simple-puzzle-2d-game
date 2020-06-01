using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 movementChange;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movementChange = Vector2.zero;
        movementChange.x = Input.GetAxisRaw("Horizontal");
        movementChange.y = Input.GetAxisRaw("Vertical");

        ApplyVelocity();

        if(movementChange != Vector3.zero)
        {
            animator.SetFloat("moveX", movementChange.x);
            animator.SetFloat("moveY", movementChange.y);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void ApplyVelocity()
    {
        //myRigidBody.MovePosition(transform.position + movementChange * speed * Time.deltaTime);
        myRigidBody.velocity = movementChange * speed;
    }
}
