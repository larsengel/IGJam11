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
	            animator.SetTrigger("idle");
	            break;
	        case 2:
	            animator.SetTrigger("wave_left");
	            break;
	        case 3:
	            animator.SetTrigger("wave_right");
	            break;
	    }
	    state = 0;
	}
}
