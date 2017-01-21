using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchildAnimation : MonoBehaviour {

    private void OnEnable()
    {
        transform.GetComponent<Animator>().SetTrigger("start");
    }

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
