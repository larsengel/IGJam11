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
            var enabled = Random.Range(1, 10) <=3 ;
            Search(transform, "schild_left").GetComponent<SpriteRenderer>().enabled = enabled;
            Search(transform, "text_left").GetComponent<MeshRenderer>().enabled = enabled;
        } else if (direction == "right")
        {
            var enabled = Random.Range(1, 10) <=3 ;
            Search(transform, "schild_right").GetComponent<SpriteRenderer>().enabled = enabled;
            Search(transform, "text_right").GetComponent<MeshRenderer>().enabled = enabled;

            animator.SetTrigger("wave_right");
        }
    }

    public void SetIdle()
    {
        animator.SetTrigger("idle");
    }

    public static Transform Search(Transform target, string name)
    {
        if (target.name == name) return target;

        for (int i = 0; i < target.childCount; ++i)
        {
            var result = Search(target.GetChild(i), name);

            if (result != null) return result;
        }

        return null;
    }
}
