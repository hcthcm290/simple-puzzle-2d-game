using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 movementChange;
    private Animator animator;
    private bool canMove;
    private bool canATK;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        canMove = true;
        canATK = true;
    }

    // Update is called once per frame
    void Update()
    {
        movementChange = Vector2.zero;
        movementChange.x = Input.GetAxisRaw("Horizontal");
        movementChange.y = Input.GetAxisRaw("Vertical");


        if (canMove)
        {
            ApplyVelocity();

            if (movementChange != Vector3.zero)
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

        // update atk statement //
        if(
            Input.GetKey(KeyCode.C) &&
            canATK
           )
        {
            animator.SetBool("ATKing", true);
        }
        else
        {
            animator.SetBool("ATKing", false);
        }
    }

    void ApplyVelocity()
    {
        myRigidBody.MovePosition(transform.position + movementChange * speed * Time.deltaTime);
        //myRigidBody.velocity = movementChange * speed;
    }

    public void BlockMoving()
    {
        canMove = false;
    }

    public void UnblockMoving()
    {
        canMove = true;
    }

    public void BlockATK()
    {
        canATK = false;
    }

    public void UnblockATK()
    {
        canATK = true;
    }
}
