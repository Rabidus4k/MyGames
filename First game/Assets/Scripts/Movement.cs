using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector3(8, 8, 0);
        } else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector3(-8, 8, 0);
        } else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
