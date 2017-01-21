using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceAnimations : MonoBehaviour
{
    private Animator animator;

	// Use this for initialization
	void Start ()
	{
	    var speed = Random.Range(.6f, 1);
	    animator = gameObject.GetComponent<Animator>();
	    animator.speed = speed;

	    var state = Random.Range(1, 4);
	    switch (state)
	    {
	        case 1:
	            SetIdle();
	            break;
	        case 2:
	            SetWave("left");
	            break;
	        case 3:
	            SetWave("right");
	            break;
	    }
	}

    public void SetWave(string direction)
    {
        if (direction == "left")
        {
            animator.SetTrigger("wave_left");
        } else if (direction == "right")
        {
            animator.SetTrigger("wave_right");
        }
    }

    public void SetIdle()
    {
        animator.SetTrigger("idle");
    }
}
