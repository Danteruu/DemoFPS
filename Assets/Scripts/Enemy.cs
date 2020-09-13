using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private bool up = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !up)
        {
            up = true;
            animator.SetBool("Up", true);
        }
        else if (other.gameObject.tag == "projectile" && up)
        {
            up = false;
            animator.SetBool("Up", false);
        }
    }   
}