using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour, Breakable
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Break()
    {
        animator.SetBool("ATKed", true);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}