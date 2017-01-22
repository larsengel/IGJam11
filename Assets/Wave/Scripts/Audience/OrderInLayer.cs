using System.Collections;
using System.Collections.Generic;
using Spriter2UnityDX;
using UnityEngine;

public class OrderInLayer : MonoBehaviour {

    static int Offset = 0;

	// Use this for initialization
	void Start ()
	{
	    Offset += 1000;

	    foreach (var renderer in GetComponentsInChildren<Renderer>())
	    {
	        var order = renderer.sortingOrder + Offset;
	        renderer.sortingOrder = order;
	    }

	}
}
